import { BaseQueryFilter } from 'src/app/_layout/utils/common-classes';

export class NewsCategory {
    NewsCategoryId: string;
    Name:string;
    Description:string;
    Type: string = null;
    Order: number;
    CreatedOnDate: string;
    LastEditedOnDate: string;
    CreatedByUserId: string;
    LastEditedByUserId: string;  
  }
  export class NewsCategoryFilter extends BaseQueryFilter{
    NewsCategoryId: string = null;
    Type: string = null;
  }
  export class NewsCategoryCreateRequestModel {
    Name: string;
    Description: string;
    Type: string;
    Order: number;
    CreatedByUserId: string = null;
  }
  export class NewsCategoryUpdateRequestModel {
    NewsCategoryId: string = null;
    Name: string;
    Description: string;
    Type: string;
    Order: number;
    LastEditedByUserId: string = null;
  }