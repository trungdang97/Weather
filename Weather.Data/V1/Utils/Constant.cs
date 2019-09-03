using System;

namespace Weather.Data.V1
{ 
    public class AppConstants
    {
        public static string EnvironmentName ="production";
        public static Guid TestId1 => new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid TestId2 => new Guid("00000000-0000-0000-0000-000000000002");

        public static Guid RootAppId => new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid TestAppId => new Guid("00000000-0000-0000-0000-000000000002");

        public static Guid APPLICATION_ID => new Guid("48ed5b71-66dc-4725-9604-4c042e45fa3f"); 
        public static Guid ADMINISTRATOR_USER_ID => new Guid("2fb87188-35b5-48d1-b527-58bf3a2b12b2");
        public static Guid ADMINISTRATOR_ROLES_ID => new Guid("e7b2c268-da31-41af-af78-dc5645e51b6d");
    }
    
    public class UserConstants
    {
        public static Guid AdministratorId => new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid UserId => new Guid("00000000-0000-0000-0000-000000000002");
    }
    public class RoleConstants
    {
        public static Guid AdministratorId => new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid UserId => new Guid("00000000-0000-0000-0000-000000000002");
        public static Guid GuestId => new Guid("00000000-0000-0000-0000-000000000002");
    }

    public class RightConstants
    {
        public static Guid AccessAppId => new Guid("00000000-0000-0000-0000-000000000001");
        public static string AccessAppCode = "TRUY_CAP_HE_THONG";

        public static Guid DefaultAppId => new Guid("00000000-0000-0000-0000-000000000002");
        public static string DefaultAppCode = "TRUY_CAP_MAC_DINH";

        public static Guid FileAdministratorId => new Guid("00000000-0000-0000-0000-000000000003");
        public static string FileAdministratorCode = "QUAN_TRI_FILE";


        public static Guid PemissionId => new Guid("00000000-0000-0000-0000-000000000004");
        public static string PemissionCode = "PHAN_QUYEN";

    }
    public class MamConstants
    {
        public static Guid PartitionDefaultId => new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid MetadataTemplateDefaultId => new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid MetadataField1Id => new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid MetadataField2Id => new Guid("00000000-0000-0000-0000-000000000002");
    }
    public class NavigationConstants
    {
        public static Guid SystemNav => new Guid("00000000-0000-0000-0000-000000000001");

        public static Guid RoleNav => new Guid("00000000-0000-0000-0000-000000000011");
        public static Guid RightNav => new Guid("00000000-0000-0000-0000-000000000021");
        public static Guid UserNav => new Guid("00000000-0000-0000-0000-000000000031");
        public static Guid PartitionNav => new Guid("00000000-0000-0000-0000-000000000041");
        public static Guid MetaTemplateNav => new Guid("00000000-0000-0000-0000-000000000051");
        public static Guid PermissionNav => new Guid("00000000-0000-0000-0000-000000000002");
        public static Guid NavNav => new Guid("00000000-0000-0000-0000-000000000012");
        public static Guid RMUNav => new Guid("00000000-0000-0000-0000-000000000022");
        public static Guid NodeNav => new Guid("00000000-0000-0000-0000-000000000003");
    }

    public class SystemTrackingConstants
    {
        public const string TEMPLATE_DELETE = "<span><strong>Xóa:</strong>&nbsp;%content%</span><br />";

        public const string DEFAULT_TRACKING_ZONE = "admin";

        #region Action
        public const string ACTION_ADD = "ADD";
        public const string ACTION_UPDATE = "UPDATE";
        public const string ACTION_DELETE = "DELETE";
        public const string ACTION_LOGIN = "LOGIN";
        public const string ACTION_LOGOUT = "LOGOUT";
        public const string ACTION_DUPLICATE = "DUPLICATE";
        public const string ACTION_SUBMIT = "SUBMIT";
        #endregion

        #region Object
        public const string OBJECT_SYSTEM = "Hệ thống";
        public const string OBJECT_USER = "Người dùng";
        public const string OBJECT_ORGANIZATION = "Đơn vị, phòng ban";
        public const string OBJECT_POSITION = "Chức vụ";
        public const string OBJECT_ROLE = "Nhóm người dùng";
        public const string OBJECT_RIGHT = "Quyền người dùng";
        public const string OBJECT_GIAYMOI = "Giấy mời";
        public const string OBJECT_TAXONOMY = "Taxonomy";
        public const string OBJECT_DMPTSX = "Danh mục phương tiện sản xuất";
        #endregion
    }

    public static class ConfigTypeConstants
    {
        public const int SUCCESS = 1;
        public const int ERROR = -1;
        public const int NODATA = 0;
        #region NodeType
        public const int File = 1;
        public const int Folder = 0;
        #endregion
        #region NodeStatus
        public const int NodeStatusDeleted = -1;
        public const int NodeStatusRecycled = 0;
        public const int NodeStatusReady = 1;
        public const int NodeStatusScaningVirus = 2;
        //Đang xử lý
        public const int NodeStatusProcessing = 13;
        #endregion 
        #region NodeMoving
        public const int NodeMoveValid = 0;
        public const int NodeMoveDuplicateName = 1;
        public const int NodeMoveParentConflict = 2;
        public const int NodeMoveSelf = 3;
        #endregion
        #region NodeProcessCmd
        public const string NodeProcessCmdSuccess = "SUCCESS";
        public const string NodeProcessCmdError = "ERROR";
        public const string NodeProcessCmdSchedule = "SCHEDULE";
        #endregion
    }

    public class DefaultMetadataConstants
    {
        public class File
        {
            public const string FILE_SOURCE_FILE_PREFIX = "FILE_SOURCE_FILE";
        }
    }

    public class Constants
    {
        public const int StatusModifiedEnable = 1;
        public const int StatusModifiedDisable = 0;
        public const int StatusLock = 0;
        public const int StatusUnLock = 1;
        public const int StatusEnable = 1;
        public const int StatusDisable = 0;
        public const int StatusCommentEnable = 1;
        public const int StatusCommentDisable = 0;

        public class TaxonomyVocabularies
        {
            public const string CHUYEN_MUC_TIN = "CHUYEN_MUC_TIN";
            public const string BAN_TIN_PHAT_SONG = "BAN_TIN_PHAT_SONG";
            public const string LINH_VUC_CHUONG_TRINH = "LINH_VUC_CHUONG_TRINH";
            public const string THE_LOAI_CHUONG_TRINH = "THE_LOAI_CHUONG_TRINH";
            public const string PTSX_XE = "PTSX_XE";
            public const string PTSX_MAYQUAY = "PTSX_MAYQUAY";
            public const string NGUONLUC_QUAYPHIM = "NGUONLUC_QUAYPHIM";
            public const string KYTHUATVIEN = "KYTHUATVIEN";
            public const string KHA_NANG_QUAY_PHIM = "KHA_NANG_QUAY_PHIM";
            public const string PHUONGTIENSANXUAT = "PHUONG_TIEN_SAN_XUAT";
            public const string NGUONLUCSANXUAT = "NGUON_LUC_SAN_XUAT";
        }

    }
}
