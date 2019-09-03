using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAM.Business_V1
{
    public static class ConfigType
    {
        public const int STATUS_OK = 1;
        public const int STATUS_NOTOK = 0;

        public const int STATUS_ACTIVE = 1;
        public const int STATUS_DEACTIVE = 0;

        public const int SUCCESS = 1;
        public const int ERROR = -1;
        public const int NODATA = 0;
        public const int DATA_IS_EXIST = 2;
        public const bool BOOL_SUCCESS = true;
        public const bool BOOL_ERROR = false;

        public const int MENU_STATUS_ACTIVE = 1;
        public const int MENU_STATUS_DEACTIVE = 1;

        public const int HOI_DONG_CUC = 1;
        public const int HOI_DONG_TRUNG_TAM = 0;

        public const int VIDEO_DISPLAY_SHOW = 1;
        public const int VIDEO_DISPLAY_HIDE = 0;

        public const string ACION_CREATE = "CREATE";
        public const string ACION_UPDATE = "UPDATE";

        public const string ORGANIZATIONS_TYPE_THUOC_CUC = "TRUC_THUOC_CUC";

        public const string ATTACHMENT_TYPE_INSTRUCTION_DOCUMENT = "ARM_INSTRUCTION_DOCUMENT";
        public const string ATTACHMENT_TYPE_RECORD = "ARM_RECORD";
        public const string ATTACHMENT_TYPE_RECORD_DOCUMENT = "ARM_RECORD_DOCUMENT";
        public const string ATTACHMENT_TYPE_ORTHER_DOCUMENT = "ARM_ORTHER_DOCUMENT";

        public const string CATALOG_CODE_NATIONALITY = "NATIONALITY";
        public const string CATALOG_CODE_READEROBJECT = "doi-tuong-doc-gia";

        public const string ORGANIZATIONS_CODE_DOCGIA = "DOC_GIA_KHAI_THAC";
        public const string ORGANIZATIONS_CODE_CONGBO = "CONG_BO";

        public const bool ACCOUNT_ACTIVE = true;
        public const bool ACCOUNT_DEACTIVE = false;
        public const bool ACCOUNT_IS_LOCKED = true;
        public const bool ACCOUNT_ISNOT_LOCKED = false;
        public const bool ACCOUNT_REGISTER_CV = false;
        public const bool ACCOUNT_REGISTER_ONLINE = true;

        public const int USER_TYPE_EMPLOYEE = 1;
        public const int USER_TYPE_SYSUSER = 0;

        public const bool FONDPROFILE_HOSOTHAMDINH = true;
        public const bool FONDPROFILE_HOSOPHONG = false;

        public const int DISPLAY_ACTIVE = 1;
        public const int DISPLAY_DEACTIVE = 0;

        public const int COUPONWOODBLOCKATRIBUTE_TYPE_FACEA = 0;
        public const int COUPONWOODBLOCKATRIBUTE_TYPE_FACEB = 1;

        public const int COUPONWOODBLOCKATRIBUTE_ISOTHER_NORMAL = 1;
        public const int COUPONWOODBLOCKATRIBUTE_ISOTHER_DIFFERENT = 2;

        public const int BOX_STATUS_NORMAL = 1;
        public const int BOX_STATUS_REVOKE = 0;//bỏ không sử dụng
        public const int BOX_TYPE_ISFULLBOX = 99;//Hộp đầy


        public const int READER_RECORD_REQUEST_STATUS_TIEPNHAN = 1;//Hộp đầy
        public const int READER_RECORD_REQUEST_STATUS_TRAKETQUA = -1;//Hộp đầy

        public const int BOXRECORDRELATIONSHIP_STATUS_NOBOX = 1;//chưa có hộp
        public const int BOXRECORDRELATIONSHIP_STATUS_ONBOX = 2;//Đang trong hộp
        public const int BOXRECORDRELATIONSHIP_STATUS_OUTSIDE = 3;//Đã được rút ra ngoài

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

        //get random password
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
        public static string PasswordGenerateHMAC(string clearMessage, string secretKeyString)
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
    }
}
