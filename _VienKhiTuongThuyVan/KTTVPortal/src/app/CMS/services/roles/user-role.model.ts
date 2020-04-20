import { BaseQueryFilter } from 'src/app/_layout/utils/common-classes';

export class UserRole {
    public RoleId: string;
    public RoleName: string;
    public LoweredRoleName: string;
    public Description: string;
    public EnableDelete: boolean;
    public CreatedByUserId: string;
    public CreatedOnDate: string;
    public LastModifiedByUserId: string;
    public LastModifiedOnDate: string;
    public IdmRightsInRole: Array<any>;
    public RightList: Array<string>;
}

export class UserRoleFilter extends BaseQueryFilter {
    public RoleId: string = null;
}

export class UserRoleCreateRequestModel {
    public RoleName: string;
    public Description: string;
    public CreatedByUserId: string;
    public RightList: Array<string>;
}
export class UserRoleUpdateRequestModel {
    public RoleId: string;
    public RoleName: string;
    public Description: string;
    public LastModifiedByUserId: string;
    public RightList: Array<string>;
}
