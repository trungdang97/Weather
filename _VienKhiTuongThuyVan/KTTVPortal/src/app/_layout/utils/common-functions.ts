import { throwError } from 'rxjs';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import { ConfirmDialogData } from './common-classes';


export function simpleErrorHandler(error) {
    alert("Kết nối tới máy chủ bị gián đoạn");
    return throwError("Kết nối tới máy chủ bị gián đoạn");
}

export class Notification {
    constructor(private dialog: MatDialog) {

    }
    private notificationDialogConfig: MatDialogConfig<ConfirmDialogData> = {
        width: '20%',
        position: { top: '5%' },
        backdropClass: ''
    }
    private title = {
        Error: "Lỗi",
        Notification: "Thông báo"
    }
    ConfirmDialogCreateNotification(isSuccess: boolean) {
        let dialogConfig = this.notificationDialogConfig;
        let message = {
            CreateSuccess: "Tạo bản ghi thành công",
            CreateFailed: "Tạo bản ghi thất bại"
        }
        if (isSuccess) {
            dialogConfig.data = new ConfirmDialogData(this.title.Notification, message.CreateSuccess, false, false);
            let dialogRef = this.dialog.open(ConfirmDialogComponent, dialogConfig);
        }
        else {
            dialogConfig.data = new ConfirmDialogData(this.title.Error, message.CreateFailed, false, true);
            let dialogRef = this.dialog.open(ConfirmDialogComponent, dialogConfig);
        }
    }
    ConfirmDialogUpdateNotification(isSuccess: boolean) {
        let dialogConfig = this.notificationDialogConfig;
        let message = {
            UpdateSuccess: "Cập nhật bản ghi thành công",
            UpdateFailed: "Cập nhật bản ghi thất bại"
        }
        if (isSuccess) {
            dialogConfig.data = new ConfirmDialogData(this.title.Notification, message.UpdateSuccess, false, false);
            let dialogRef = this.dialog.open(ConfirmDialogComponent, dialogConfig);
        }
        else {
            dialogConfig.data = new ConfirmDialogData(this.title.Error, message.UpdateFailed, false, true);
            let dialogRef = this.dialog.open(ConfirmDialogComponent, dialogConfig);
        }
    }
    ConfirmDialogDeleteNotification(isSuccess: boolean) {
        let dialogConfig = this.notificationDialogConfig;
        let message = {
            DeleteSuccess: "Xóa bản ghi thành công",
            DeleteFailed: "Xóa bản ghi thất bại: bản ghi có phụ thuộc hoặc đã được xóa"
        }
        if (isSuccess) {
            dialogConfig.data = new ConfirmDialogData(this.title.Notification, message.DeleteSuccess, false, false);
            let dialogRef = this.dialog.open(ConfirmDialogComponent, dialogConfig);
        }
        else {
            dialogConfig.data = new ConfirmDialogData(this.title.Error, message.DeleteFailed, false, true);
            let dialogRef = this.dialog.open(ConfirmDialogComponent, dialogConfig);
        }
    }
}

/**
 * 
 * @param object Passed object need to have IsCheck:boolean property
 */
export function CheckboxCheckAll(array: Array<any>, isCheckAll: boolean) {

    // if(isUndefined(object.IsCheck)){
    //     console.error("Object passed to DoCheck cannot be undefined");
    //     return;
    // }
    // if(typeof object.IsCheck != "boolean"){
    //     console.error("Object's IsCheck property passed to DoCheck must be boolean");
    //     return;
    // }
    let result = {
        IsCheckAll: isCheckAll,
        IsDeleteMany: isCheckAll
    };
    if (isCheckAll) {
        array.forEach(element => {
            element.IsCheck = true;
        });
    }
    else {
        array.forEach(element => {
            element.IsCheck = false;
        });
    }
    return result;
}

export function CheckboxCheck(array: Array<any>) {

    // if(isUndefined(object.IsCheck)){
    //     console.error("Object passed to DoCheck cannot be undefined");
    //     return;
    // }
    // if(typeof object.IsCheck != "boolean"){
    //     console.error("Object's IsCheck property passed to DoCheck must be boolean");
    //     return;
    // }
    let result = {
        IsCheckAll: true,
        IsDeleteMany: false
    };
    for (let i = 0; i < array.length; i++) {
        if (!array[i].IsCheck) {
            result.IsCheckAll = false;
            if (i > 0) {
                result.IsDeleteMany = true;
                break;
            }
            else { // i == 0
                for (let j = i + 1; j < array.length; j++) {
                    if (array[j].IsCheck) {
                        result.IsDeleteMany = true;
                        break;
                    }
                }
            }
            break;
        }
    }
    if (result.IsCheckAll) {
        result.IsDeleteMany = result.IsCheckAll;
    }
    return result;
}

export function GetListSelectedId(array: Array<any>, propertyIdName: string): string[] {
    let listId: string[];
    array.forEach(element => {
        if (element.IsCheck == undefined) {
            console.error("Element doesn't have IsCheck property.");
            console.error(element);
            return;
        }
        else {
            if (element.IsCheck) {
                listId.push(element[propertyIdName]);
            }
        }
    });
    return listId;
}