import { BaseQueryFilter } from 'src/app/_layout/utils/common-classes';

export class IdmRight {
    public RightId:string = '';
    public RightName:string = '';
    public Description:string = '';
    public Status:boolean = true;
    public Order:number = null;
    public IsGroup: boolean = false;
    public Level:number = null;
    public GroupId:string = null;
    public CreatedOnDate: string;
    public ModifiedOnDate: string;
    public CreatedByUserId: string;
    public LastModifiedByUserId: string;

    public InverseGroupIdNavigation: Array<IdmRight>;
}

export class IdmRightFilter extends BaseQueryFilter{
    RightId:string = null;
}

export class IdmRightCreateRequestModel {
    public RightId: string;
    public RightName: string;
    public Description: string;
    public Status: boolean;
    public Order: number;
    public IsGroup: boolean;
    public Level: number;
    public GroupId: string;
    public CreatedByUserId: string;
}
export class IdmRightUpdateRequestModel {
    public RightId: string;
    public RightName: string;
    public Description: string;
    public Status: boolean;
    public Order: number;
    public Level: number;
    public GroupId: string;
    public LastModifiedByUserId: string;
}
