import { BaseQueryFilter } from 'src/app/_layout/utils/common-classes';

export class IdmRight {
    public RightCode:string = '';
    public RightName:string = '';
    public Description:string = '';
    public Status:boolean = true;
    public Order:number = null;
    public IsGroup: boolean = false;
    public Level:number = null;
    public GroupCode:string = null;
    public CreatedOnDate: string;
    public ModifiedOnDate: string;
    public CreatedByUserId: string;
    public LastModifiedByUserId: string;

    public InverseGroupCodeNavigation: Array<IdmRight>;
}

export class IdmRightFilter extends BaseQueryFilter{
    RightCode:string = null;
}

export class IdmRightCreateRequestModel {
    public RightCode: string;
    public RightName: string;
    public Description: string;
    public Status: boolean;
    public Order: number;
    public IsGroup: boolean;
    public Level: number;
    public GroupCode: string;
    public CreatedByUserId: string;
}
export class IdmRightUpdateRequestModel {
    public RightCode: string;
    public RightName: string;
    public Description: string;
    public Status: boolean;
    public Order: number;
    //public IsGroup: boolean;
    public Level: number;
    public GroupCode: string;
    public LastModifiedByUserId: string;
}
