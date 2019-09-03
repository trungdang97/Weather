using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Weather.Data.V1
{
    public static class AsyncHelper
    {
        // AsyncHelper.RunSync(() => DoAsyncStuff());  
        private static readonly TaskFactory _taskFactory = new
            TaskFactory(CancellationToken.None,
                        TaskCreationOptions.None,
                        TaskContinuationOptions.None,
                        TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        public static void RunSync(Func<Task> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
    public class ObjectScore
    {
        public object Value { get; set; }
        public int Score { get; set; } = 1;
    }
    public partial class Utils
    {
        public static bool IsValidJsonObject(string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return false;
            }

            var value = stringValue.Trim();

            if (value.StartsWith("{") && value.EndsWith("}"))
            {
                try
                {
                    JToken.Parse(value);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
            }

            return false;
        }
        public static bool IsValidJsonArray(string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return false;
            }

            var value = stringValue.Trim();

            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                try
                {
                    JToken.Parse(value);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
            }

            return false;
        }
        //   public DateTime? StartDateOfYear { get; set; } // Ngay trong nam
        // public int? StartDayOfWeek { get; set; } =2; // Thứ 2,3,4,5,6,7,8(cn) 
        // public int? StartDateOfMonth { get; set; } =1; // Ngày 1,2,3,4,5,6,7,8,9...31
        // public int TimeType { get; set; } = 1; // 1: Giờ trong ngày | 2: Ngày trong tuần | 3: Ngày trong tháng | 4: Ngày trong năm

        public static DateTime? GetNextValidateTime(int timeType, DateTime? startTime, DateTime? startDayOfYear, int? startDayOfWeek, int? startDateOfMonth)
        {
            try
            {
                var resultDate = DateTime.Now;
                int subDay = 0;
                switch (timeType)
                {
                    case 1:
                        if (DateTime.Now.TimeOfDay > startTime.Value.TimeOfDay)
                        {
                            resultDate = resultDate.AddDays(1);
                        }
                        return new DateTime(
                                      resultDate.Year,
                                      resultDate.Month,
                                      resultDate.Day,
                                      startTime.Value.Hour,
                                      startTime.Value.Minute,
                                      startTime.Value.Second,
                                      startTime.Value.Millisecond,
                                      startTime.Value.Kind);
                    case 2:
                        if (DateTime.Now.DayOfWeek.GetHashCode() + 1 > startDayOfWeek.Value)
                        {
                            resultDate = resultDate.AddDays(7- startDayOfWeek.Value);
                        }
                        return new DateTime(
                                      resultDate.Year,
                                      resultDate.Month,
                                      resultDate.Day,
                                      startTime.Value.Hour,
                                      startTime.Value.Minute,
                                      startTime.Value.Second,
                                      startTime.Value.Millisecond,
                                      startTime.Value.Kind);


                    case 3:
                        if (DateTime.Now.Day > startDateOfMonth.Value)
                        {
                            resultDate = resultDate.AddMonths(1);
                        }
                        return new DateTime(
                                      resultDate.Year,
                                      resultDate.Month,
                                      startDateOfMonth.Value,
                                      startTime.Value.Hour,
                                      startTime.Value.Minute,
                                      startTime.Value.Second,
                                      startTime.Value.Millisecond,
                                      startTime.Value.Kind);
                    case 4:
                        var date = new DateTime(
                                      startDayOfYear.Value.Year,
                                      startDayOfYear.Value.Month,
                                      startDayOfYear.Value.Day,
                                      startTime.Value.Hour,
                                      startTime.Value.Minute,
                                      startTime.Value.Second,
                                      startTime.Value.Millisecond,
                                      startTime.Value.Kind);
                        if (DateTime.Now < date)
                        {
                            date.AddYears(1);
                        }
                        return date;
                    default:
                        if (DateTime.Now.TimeOfDay > startTime.Value.TimeOfDay)
                        {
                            resultDate = resultDate.AddDays(1);
                        }
                        return new DateTime(
                                      resultDate.Year,
                                      resultDate.Month,
                                      resultDate.Day,
                                      startTime.Value.Hour,
                                      startTime.Value.Minute,
                                      startTime.Value.Second,
                                      startTime.Value.Millisecond,
                                      startTime.Value.Kind);
                }
            }
            catch (System.Exception)
            {
                return null;

            }

        }


        public static string GetConfig(string code)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                // var getconfig = unitOfWork.GetRepository<BsdParameter>().Get(sp => sp.Name == code).FirstOrDefault();
                // if (getconfig != null)
                // {
                //     return getconfig.Value;
                // }
                // else
                // {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                                                                  .AddJsonFile($"appsettings.{AppConstants.EnvironmentName}.json",
                                                                   optional: true, reloadOnChange: false)
                                                                  .Build();
                var value = configuration[code];
                return value;
                // }
            }
        }
        public static string ReOrderPemission(string permissionString)
        {

            var listPermission = permissionString.ToList();
            var nuberPermission = new List<ObjectScore>();
            foreach (var item in listPermission)
            {
                switch (item)
                {
                    case 'r':
                        nuberPermission.Add(new ObjectScore
                        {
                            Score = 1,
                            Value = item
                        });
                        break;
                    case 'w':
                        nuberPermission.Add(new ObjectScore
                        {
                            Score = 1,
                            Value = item
                        });
                        break;
                    case 'e':
                        nuberPermission.Add(new ObjectScore
                        {
                            Score = 1,
                            Value = item
                        });
                        break;
                    case 'd':
                        nuberPermission.Add(new ObjectScore
                        {
                            Score = 1,
                            Value = item
                        });
                        break;
                    case 'f':
                        nuberPermission.Add(new ObjectScore
                        {
                            Score = 1,
                            Value = item
                        });
                        break;
                    default:
                        break;
                }
            }
            nuberPermission.OrderBy(s => s.Score);
            return string.Join("", nuberPermission.Select(s => s.Value.ToString()));
        }
        private static readonly string[] VietnameseSigns = new string[]
        {
        "aAeEoOuUiIdDyY ",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ",
        " "
        };
        public static string RemoveVietnameseSign(string str)
        {

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }

            return str;

        }
        public static string BuildVietnameseSign(string str)
        {

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[0][i - 1], VietnameseSigns[i][j]);

            }

            return str;

        }
        public static List<Guid> GetListIdFromCommaString(string listId)
        {
            var listIdObj = new List<Guid>();

            var spilit = listId.Split(',');

            foreach (var item in spilit)
            {
                try
                {
                    Guid newGuid = Guid.Parse(item);
                    listIdObj.Add(newGuid);
                }
                catch (Exception)
                {
                    return new List<Guid>();
                }
            }

            return listIdObj;

        }
        /// <summary>
        /// Convert url title
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ConvertToUrlTitle(string name)
        {
            string strNewName = name;

            #region Replace unicode chars
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = name.Normalize(NormalizationForm.FormD);
            strNewName = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            #endregion

            #region Replace special chars
            string strSpecialString = "~\"“”#%&*:;<>?/\\{|}.+_@$^()[]`,!-'";

            foreach (char c in strSpecialString.ToCharArray())
            {
                strNewName = strNewName.Replace(c, ' ');
            }
            #endregion

            #region Replace space

            // Create the Regex.
            var r = new Regex(@"\s+");
            // Strip multiple spaces.
            strNewName = r.Replace(strNewName, @" ").Replace(" ", "-").Trim('-');

            #endregion)

            return strNewName;
        }
        /// <summary>
        /// Check if a string is a guid or not
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static bool IsGuid(string inputString)
        {
            try
            {
                var guid = new Guid(inputString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsNumber(string inputString)
        {
            try
            {
                var guid = int.Parse(inputString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string GeneratePageUrl(string pageTitle)
        {
            var result = RemoveVietnameseSign(pageTitle);

            // Replace spaces
            result = result.Replace(" ", "-");

            // Replace double spaces
            result = result.Replace("--", "-");

            // Remove triple spaces
            result = result.Replace("---", "-");

            return result;

        }
        /// <summary>
        /// Tạo chuỗi 6 chữ số
        /// </summary>
        /// <returns></returns>
        public static string GenerateNewRandom()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateNewRandom();
            }
            return r;
        }
        public static string PassowrdRandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        public static string PassowrdCreateSalt512()
        {
            var message = PassowrdRandomString(512, false);
            return BitConverter.ToString((new SHA512Managed()).ComputeHash(Encoding.ASCII.GetBytes(message))).Replace("-", "");
        }
        public static string RandomPassword(int numericLength, int lCaseLength, int uCaseLength, int specialLength)
        {
            Random random = new Random();

            //char set random
            string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
            string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
            string PASSWORD_CHARS_NUMERIC = "1234567890";
            string PASSWORD_CHARS_SPECIAL = "!@#$%^&*()-+<>?";
            if ((numericLength + lCaseLength + uCaseLength + specialLength) < 8)
                return string.Empty;
            else
            {
                //get char
                var strNumeric = new string(Enumerable.Repeat(PASSWORD_CHARS_NUMERIC, numericLength)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                var strUper = new string(Enumerable.Repeat(PASSWORD_CHARS_UCASE, uCaseLength)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                var strSpecial = new string(Enumerable.Repeat(PASSWORD_CHARS_SPECIAL, specialLength)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                var strLower = new string(Enumerable.Repeat(PASSWORD_CHARS_LCASE, lCaseLength)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                //result : ký tự số + chữ hoa + chữ thường + các ký tự đặc biệt > 8
                var strResult = strNumeric + strUper + strSpecial + strLower;
                return strResult;
            }
        }
        public static string PasswordGenerateHmac(string clearMessage, string secretKeyString)
        {
            var encoder = new ASCIIEncoding();
            var messageBytes = encoder.GetBytes(clearMessage);
            var secretKeyBytes = new byte[secretKeyString.Length / 2];
            for (int index = 0; index < secretKeyBytes.Length; index++)
            {
                string byteValue = secretKeyString.Substring(index * 2, 2);
                secretKeyBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            var hmacsha512 = new HMACSHA512(secretKeyBytes);
            byte[] hashValue = hmacsha512.ComputeHash(messageBytes);
            string hmac = "";
            foreach (byte x in hashValue)
            {
                hmac += String.Format("{0:x2}", x);
            }
            return hmac.ToUpper();
        }
        public static Expression<Func<T, bool>> PredicateByName<T>(string propName, object propValue)
        {
            var parameterExpression = Expression.Parameter(typeof(T));
            var propertyOrField = Expression.PropertyOrField(parameterExpression, propName);
            var binaryExpression = Expression.GreaterThan(propertyOrField, Expression.Constant(propValue));
            return Expression.Lambda<Func<T, bool>>(binaryExpression, parameterExpression);
        }

        //public static string TikaExtractor(string filePath)
        //{
        //    var textExtractor = new TextExtractor();

        //    return textExtractor.Extract(filePath).Text;
        //}
        //public static string TikaExtractorFromUe(Uri uri)
        //{
        //    var textExtractor = new TextExtractor();
        //    return textExtractor.Extract(uri).Text;
        //}
    }
    public class TokenRequest
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
    public class TokenInfo
    {
        public Guid ObjectId { get; set; }
        public int Level { get; set; }
        public long Tick { get; set; }
        public DateTime DateTimeExpired { get; set; }
    }
    public static class TokenHelpers
    {
        #region basic token

        /// <summary>
        /// Tạo token theo key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string CreateBasicToken(string key)
        {
            try
            {
                string token = string.Empty;

                byte[] keyData = Encoding.UTF8.GetBytes(key);

                // Token chứa mã đối tượng tải về
                if (keyData != null) token = Convert.ToBase64String(keyData.ToArray());
                //Safe URl
                token = Base64UrlEncoder.Encode(token);
                return token;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Lấy key theo token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetKeyFromBasicToken(string token)
        {
            try
            {
                //Safe URl
                token = Base64UrlEncoder.Decode(token);
                string key = string.Empty;

                if (IsBase64(token))
                {
                    byte[] dataToken = Convert.FromBase64String(token);

                    if (dataToken != null) key = Encoding.UTF8.GetString(dataToken);
                }
                return key;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region token download

        /// <summary>
        /// Tạo token chứa mã đối tượng, thời gian hiệu lực
        /// </summary>
        /// <param name="objectId">mã đối tượng</param>
        /// <param name="ticks">thời gian hiệu lực</param>
        /// <param name="keyEncrypt">khóa mã hóa</param>
        /// <returns></returns>
        public static string CreateUniqueTokenDownload(string objectId, long ticks, string keyEncrypt)
        {
            try
            {
                string token = string.Empty;

                byte[] key = Encoding.UTF8.GetBytes(objectId);
                byte[] time = Encoding.UTF8.GetBytes(ticks.ToString());

                // Token chứa thông tin thời gian hết hạn và mã đối tượng tải về
                if (time.Concat(key) != null) token = Convert.ToBase64String(key.Concat(time).ToArray());

                // Mã hóa token
                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(keyEncrypt)) token = Encrypt.EncryptText(token, keyEncrypt);
                //Safe URl
                token = Base64UrlEncoder.Encode(token);
                return token;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Lấy thời gian hết hạn theo token
        /// </summary>
        /// <param name="token">mã đối tượng</param>
        /// <param name="keyEncrypt">khóa mã hóa</param>
        /// <returns></returns>
        public static DateTime? GetDateTimeExpiredDownload(string token, string keyEncrypt)
        {
            try
            {
                //Safe URl
                token = Base64UrlEncoder.Decode(token);
                // Giải mã chuỗi token nếu dùng mã hóa
                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(keyEncrypt)) token = Encrypt.DecryptText(token, keyEncrypt);
                token = token.Replace("\0", string.Empty);
                DateTime unixYear0 = new DateTime(1970, 1, 1, 0, 0, 1);
                DateTime dateTimeExpired = DateTime.Now;

                string timeTicksExpiredString = string.Empty;

                if (IsBase64(token))
                {
                    byte[] dataToken = Convert.FromBase64String(token);
                    if (dataToken != null)
                    {
                        byte[] dataTick = new byte[dataToken.Length - 36];

                        Array.Copy(dataToken, 36, dataTick, 0, dataToken.Length - 36);
                        if (dataTick != null) timeTicksExpiredString = Encoding.UTF8.GetString(dataTick);
                        if (!string.IsNullOrEmpty(timeTicksExpiredString))
                        {
                            long ticks = long.Parse(timeTicksExpiredString);
                            dateTimeExpired = new DateTime(unixYear0.Ticks + ticks);
                        }
                    }
                    return dateTimeExpired;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Lấy mã đối tượng theo token
        /// </summary>
        /// <param name="token">mã đối tượng</param>
        /// <param name="keyEncrypt">khóa mã hóa</param>
        /// <returns></returns>
        public static Guid GetObjectIdDownload(string token, string keyEncrypt)
        {
            try
            {
                //Safe URl
                token = Base64UrlEncoder.Decode(token);
                // Giải mã chuỗi token nếu sử dụng mã hóa
                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(keyEncrypt)) token = Encrypt.DecryptText(token, keyEncrypt);
                token = token.Replace("\0", string.Empty);
                Guid objectId = Guid.Empty;

                if (IsBase64(token))
                {
                    string objectStringId = string.Empty;
                    byte[] dataToken = Convert.FromBase64String(token);
                    byte[] dataGuid = new byte[36];
                    Array.Copy(dataToken, 0, dataGuid, 0, 36);
                    if (dataGuid != null) objectStringId = Encoding.UTF8.GetString(dataGuid);

                    if (!string.IsNullOrEmpty(objectStringId) && Utils.IsGuid(objectStringId))
                    {
                        objectId = new Guid(objectStringId);
                    }
                }


                return objectId;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        #region token tokenInfo
        /// <summary>
        /// Tạo token
        /// </summary>
        /// <param name="tokenInfo"></param>
        /// <param name="keyEncrypt"></param>
        /// <returns></returns>
        public static string CreateToken(TokenInfo tokenInfo, string keyEncrypt)
        {
            try
            {
                string token = string.Empty;

                byte[] objectId = Encoding.UTF8.GetBytes(tokenInfo.ObjectId.ToString());
                byte[] level = Encoding.UTF8.GetBytes(tokenInfo.Level.ToString());
                byte[] tick = Encoding.UTF8.GetBytes(tokenInfo.Tick.ToString());

                // Token chứa thông tin thời gian hết hạn và mã đối tượng tải về
                if (level.Concat(objectId).Concat(tick) != null) token = Convert.ToBase64String(level.Concat(objectId).Concat(tick).ToArray());
                // Mã hóa token
                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(keyEncrypt)) token = Encrypt.EncryptText(token, keyEncrypt);
                //Safe URl
                token = Base64UrlEncoder.Encode(token);
                return token;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Lấy token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="keyEncrypt"></param>
        /// <returns></returns>
        public static TokenInfo GetToken(string token, string keyEncrypt)
        {
            try
            {
                //Safe URl
                token = Base64UrlEncoder.Decode(token);
                // Giải mã chuỗi token nếu dùng mã hóa
                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(keyEncrypt)) token = Encrypt.DecryptText(token, keyEncrypt);
                token = token.Replace("\0", string.Empty);
                if (IsBase64(token))
                {
                    byte[] dataToken = Convert.FromBase64String(token);
                    if (dataToken != null)
                    {
                        var result = new TokenInfo();
                        byte[] dataLevel = new byte[1];
                        Array.Copy(dataToken, 0, dataLevel, 0, 1);
                        byte[] dataGuid = new byte[36];
                        Array.Copy(dataToken, 1, dataGuid, 0, 36);
                        byte[] dataTick = new byte[dataToken.Length - 37];
                        Array.Copy(dataToken, 37, dataTick, 0, dataToken.Length - 37);
                        if (dataLevel != null && dataGuid != null && dataTick != null)
                        {
                            result.ObjectId = new Guid(Encoding.UTF8.GetString(dataGuid));
                            result.Level = Convert.ToInt16(Encoding.UTF8.GetString(dataLevel));
                            result.Tick = long.Parse(Encoding.UTF8.GetString(dataTick));
                            DateTime unixYear0 = new DateTime(1970, 1, 1, 0, 0, 1);
                            DateTime dateTimeExpired = DateTime.Now;
                            string timeTicksExpiredString = string.Empty;
                            dateTimeExpired = new DateTime(unixYear0.Ticks + result.Tick);
                            result.DateTimeExpired = dateTimeExpired;
                        }
                        return result;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion
        public static bool IsBase64(this string base64String)
        {
            if (base64String == null || base64String.Length == 0 || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception)
            {
                // Handle the exception
            }
            return false;
        }

    }
    public static class Encrypt
    {
        #region Encrypt Function

        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;
                    AES.Padding = PaddingMode.Zeros;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;
                    AES.Padding = PaddingMode.Zeros;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        public static string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }
        public static string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        #endregion
    }
    //public static class Security
    //{
    //    #region Check sum
    //    public static class Algorithms
    //    {
    //        public static readonly HashAlgorithm MD5 = new MD5CryptoServiceProvider();
    //        public static readonly HashAlgorithm SHA1 = new SHA1Managed();
    //        public static readonly HashAlgorithm SHA256 = new SHA256Managed();
    //        public static readonly HashAlgorithm SHA384 = new SHA384Managed();
    //        public static readonly HashAlgorithm SHA512 = new SHA512Managed();
    //        //public static readonly HashAlgorithm RIPEMD160 = new RIPEMD160Managed();
    //    }
    //    public static string GetHashFromFile(string fileName, HashAlgorithm algorithm)
    //    {
    //        using (var stream = new BufferedStream(File.OpenRead(fileName), 100000))
    //        {
    //            return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", string.Empty);
    //        }
    //    }
    //    public static bool VerifyHashFromFile(string fileName, HashAlgorithm algorithm, string hashInput)
    //    {
    //        bool verify = false;
    //        string hashResult = "";

    //        using (var stream = new BufferedStream(File.OpenRead(fileName), 100000))
    //        {
    //            hashResult = BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", string.Empty);
    //            if (hashResult.SequenceEqual(hashInput)) verify = true;
    //        }

    //        return verify;
    //    }
    //    #endregion

    //    #region CheckIOPermission
    //    public static bool HasAccess(DirectoryInfo directory, FileSystemRights right, WindowsIdentity _currentUser, WindowsPrincipal _currentPrincipal)
    //    {
    //        // Get the collection of authorization rules that apply to the directory.
    //        AuthorizationRuleCollection acl = directory.GetAccessControl()
    //            .GetAccessRules(true, true, typeof(SecurityIdentifier));
    //        return HasFileOrDirectoryAccess(right, acl, _currentUser, _currentPrincipal);
    //    }

    //    public static bool HasAccess(FileInfo file, FileSystemRights right, WindowsIdentity _currentUser, WindowsPrincipal _currentPrincipal)
    //    {
    //        // Get the collection of authorization rules that apply to the file.
    //        AuthorizationRuleCollection acl = file.GetAccessControl()
    //            .GetAccessRules(true, true, typeof(SecurityIdentifier));
    //        return HasFileOrDirectoryAccess(right, acl, _currentUser, _currentPrincipal);
    //    }

    //    private static bool HasFileOrDirectoryAccess(FileSystemRights right,
    //                                          AuthorizationRuleCollection acl, WindowsIdentity _currentUser, WindowsPrincipal _currentPrincipal)
    //    {
    //        bool allow = false;
    //        bool inheritedAllow = false;
    //        bool inheritedDeny = false;

    //        for (int i = 0; i < acl.Count; i++)
    //        {
    //            FileSystemAccessRule currentRule = (FileSystemAccessRule)acl[i];
    //            // If the current rule applies to the current user.
    //            if (_currentUser.User.Equals(currentRule.IdentityReference) ||
    //                _currentPrincipal.IsInRole(
    //                                (SecurityIdentifier)currentRule.IdentityReference))
    //            {

    //                if (currentRule.AccessControlType.Equals(AccessControlType.Deny))
    //                {
    //                    if ((currentRule.FileSystemRights & right) == right)
    //                    {
    //                        if (currentRule.IsInherited)
    //                        {
    //                            inheritedDeny = true;
    //                        }
    //                        else
    //                        { // Non inherited "deny" takes overall precedence.
    //                            return false;
    //                        }
    //                    }
    //                }
    //                else if (currentRule.AccessControlType
    //                                                .Equals(AccessControlType.Allow))
    //                {
    //                    if ((currentRule.FileSystemRights & right) == right)
    //                    {
    //                        if (currentRule.IsInherited)
    //                        {
    //                            inheritedAllow = true;
    //                        }
    //                        else
    //                        {
    //                            allow = true;
    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        if (allow)
    //        { // Non inherited "allow" takes precedence over inherited rules.
    //            return true;
    //        }
    //        return inheritedAllow && !inheritedDeny;
    //    }
    //    #endregion
    //}

    public static partial class DateTimeExtensions
    {
        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            var diff = dt.DayOfWeek - DayOfWeek.Monday; // first day of week is Monday
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(6);
        }

        public static DateTime FirstDayOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDayOfNextMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(1);
        }
    }

}
