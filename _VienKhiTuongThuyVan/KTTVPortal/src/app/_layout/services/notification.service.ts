import { Injectable } from '@angular/core';
import { ToastrService, IndividualConfig } from 'ngx-toastr';
import { Toast } from 'ngx-toastr';
@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  constructor(private toastr: ToastrService) { }
  private title = {
    Success: 'Thành công',
    Error: "Lỗi",
    Notification: "Thông báo"
  }
  private toastrConfig : IndividualConfig = {
    toastComponent: Toast,
    closeButton: false,
    timeOut: 5000,
    extendedTimeOut: 1500,
    disableTimeOut: false,
    easing: 'ease-in',
    easeTime: 300,
    enableHtml: true,
    progressBar: true,
    progressAnimation: 'decreasing',
    toastClass: 'ngx-toastr',
    positionClass: 'toast-bottom-right',
    titleClass: 'toast-title',
    messageClass: 'toast-message',
    tapToDismiss: false,
    onActivateTick: false
  }

  ForCreate(isSuccess: boolean):void {
    let message = {
      Success: "Tạo thành công",
      Error: "Tạo thất bại"
    }
    if (isSuccess) {
      this.toastr.success(message.Success, this.title.Success, this.toastrConfig);
    }
    else {
      this.toastr.error(message.Error, this.title.Error, this.toastrConfig);
    }
  }
  ForUpdate(isSuccess: boolean):void {
    let message = {
      Success: "Cập nhật thành công",
      Error: "Cập nhật thất bại"
    }
    if (isSuccess) {
      this.toastr.success(message.Success, this.title.Success, this.toastrConfig);
    }
    else {
      this.toastr.error(message.Error, this.title.Error, this.toastrConfig);
    }
  }
  ForDelete(isSuccess: boolean):void {
    let message = {
      Success: "Xóa thành công",
      Error: "Xóa thất bại"
    }
    if (isSuccess) {
      this.toastr.success(message.Success, this.title.Success, this.toastrConfig);
    }
    else {
      this.toastr.error(message.Error, this.title.Error, this.toastrConfig);
    }
  }
}
