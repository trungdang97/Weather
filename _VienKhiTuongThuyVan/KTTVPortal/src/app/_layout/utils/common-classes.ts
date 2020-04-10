import { MatDialogConfig } from '@angular/material';

export const enum Status{
    SUCCESS = 1,
    FAILED = -1
}

export class BaseQueryFilter {
    PageSize: number = 10;
    PageNumber: number = 1;
    FromDate: string = null;
    ToDate: string = null;
    FilterText: string = null;
}
export class ModalItemData {
    IsUpdate: boolean;
    Id: string;

    constructor(IsUpdate: boolean, Id: string) {
        this.IsUpdate = IsUpdate;
        this.Id = Id;
    }
}

export class ConfirmDialogData {
    title: string;
    message: string;
    hasDeny: boolean;
    isError: boolean;

    constructor(title: string, message: string, hasDeny: boolean, isError: boolean) {
        this.title = title;
        this.message = message;
        this.hasDeny = hasDeny;
        this.isError = isError;
    }
}

export const notificationDialogConfig: MatDialogConfig = {
    width: '20%',
    data: ConfirmDialogData,
    position: { 'top': '5%' },
    backdropClass: ''
}

/**
 * 
 * @param data Data to inject into component
 */
export function getModalItemDialogConfig(data): MatDialogConfig {
    let dialogConfig: MatDialogConfig = {
        width: '50%',
        data: data,
        position: { 'top': '5%' },
        backdropClass: ''
    }
    return dialogConfig;
}

export class GlobalOptions {
    static pageSizeOptions: number[] = [5, 10, 25, 50];
    static defaultPageSize: number = GlobalOptions.pageSizeOptions[1];
}

export class Guid {
    static Empty: string = '00000000-0000-0000-0000-000000000000';
}