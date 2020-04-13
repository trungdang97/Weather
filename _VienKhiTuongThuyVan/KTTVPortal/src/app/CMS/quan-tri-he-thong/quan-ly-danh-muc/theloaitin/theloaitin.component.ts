import { Component, OnInit, OnDestroy } from '@angular/core';
import { NewsCategoryService } from '../../../services/newscategory/newscategory.service';
import { PageEvent } from '@angular/material/paginator';
import { Subscription } from 'rxjs';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { TheloaitinModalItemComponent } from './theloaitin-modal-item/theloaitin-modal-item.component';
import { ConfirmDialogComponent } from 'src/app/_layout/confirm-dialog/confirm-dialog.component';
import { notificationDialogConfig, ConfirmDialogData, getModalItemDialogConfig, GlobalOptions, ModalItemData } from 'src/app/_layout/utils/common-classes';
import { Notification, CheckboxCheckAll, CheckboxCheck, GetListSelectedId } from '../../../../_layout/utils/common-functions';
import { NewsCategoryFilter } from 'src/app/CMS/services/newscategory/newscategory.model';
import { NotificationService } from 'src/app/_layout/services/notification.service'
@Component({
  selector: 'app-theloaitin',
  templateUrl: './theloaitin.component.html',
  styleUrls: ['./theloaitin.component.css'],
})
export class TheloaitinComponent implements OnInit, OnDestroy {

  constructor(
    private NewsCategoryService: NewsCategoryService,
    private NotificationService: NotificationService,
    public dialog: MatDialog,
  ) { }
  public title = "Quản lý thể loại tin";
  private subscription = new Subscription();
  public categories = {};
  private notification = new Notification(this.dialog);
  public IsCheckAll = false;
  public IsDeleteMany = false;
  public headers = [
    {
      Name: 'Tên loại tin',
      IsVisible: true,
      Class: 'text-center',
      Width: 'auto'
    },
    {
      Name: 'Mô tả',
      IsVisible: true,
      Class: 'text-center',
      Width: '20%'
    },
    {
      Name: 'Kiểu tin',
      IsVisible: true,
      Class: 'text-center',
      Width: 'auto'
    },
    {
      Name: 'Thứ tự',
      IsVisible: true,
      Class: 'text-center',
      Width: 'auto'
    },
    {
      Name: 'Thao tác',
      IsVisible: true,
      Class: 'text-center',
      Width: '10%'
    }
  ];

  public types = [
    {
      Value: null,
      Name: 'Tất cả'
    },
    {
      Value: 'TT',
      Name: 'Tin tức'
    },
    {
      Value: 'CM',
      Name: 'Chuyên mục'
    }
  ];

  public filter = new NewsCategoryFilter();
  public button = {
    Refresh: {
      click: () => {
        //debugger;
        this.filter = {
          PageSize: 10,
          PageNumber: 1,
          FromDate: null,
          ToDate: null,
          FilterText: '',
          NewsCategoryId: '',
          Type: null
        };
        this.getData(undefined);
      }
    },
    Add: {
      click: () => {
        //debugger;
        this.openModalDialog(new ModalItemData(false, null));
      }
    },
    Edit: {
      click: (id) => {
        //debugger;
        this.openModalDialog(new ModalItemData(true, id));
      }
    },
    Delete: {
      click: (id) => {
        let dialogConfig: MatDialogConfig = {
          width: '20%',
          data: new ConfirmDialogData("Xác nhận xóa", "Bạn có chắc chắn muốn xóa bản ghi này?", true, false),
          position: { 'top': '5%' },
          backdropClass: ''
        }
        let dialogRef = this.dialog.open(ConfirmDialogComponent, dialogConfig);
        dialogRef.afterClosed().subscribe(result => {
          //debugger;
          if (result) {
            this.NewsCategoryService.Delete(id).subscribe(response => {
              dialogConfig = notificationDialogConfig;
              if (response['Status'] == 1) {
                this.NotificationService.ForDelete(true);
              }
              else {
                this.NotificationService.ForDelete(false);
              }
              this.getData(undefined);
            });
          }
        });
      }
    },
    DeleteMany: {
      click: () => {
        //let listId = GetListSelectedId(categories['Data'], nameof());
        let listId = [];
        this.categories['Data'].forEach(element => {
          if (element.IsCheck) {
            listId.push(element.NewsCategoryId);
          }
        });
        this.NewsCategoryService.DeleteMany(listId).subscribe(response => {
          if (response['Status'] == 1) {
            this.NotificationService.ForDelete(true);
          }
          else {
            this.NotificationService.ForDelete(false);
          }
          this.getData(undefined);
        });
      }
    }
  };

  doCheckAll() {
    if (this.IsCheckAll) {
      CheckboxCheckAll(this.categories["Data"], true);
    }
    else {
      CheckboxCheckAll(this.categories["Data"], false);
    }
    this.IsDeleteMany = this.IsCheckAll;
  }
  doCheck() {
    let result = CheckboxCheck(this.categories["Data"]);
    this.IsCheckAll = result.IsCheckAll;
    this.IsDeleteMany = result.IsDeleteMany;
  }

  openModalDialog(modalData: ModalItemData) {
    let dialogConfig = getModalItemDialogConfig(modalData);
    let dialogRef = this.dialog.open(TheloaitinModalItemComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      if (typeof result != "boolean") {
        return;
      }
      if (modalData.IsUpdate) {
        this.NotificationService.ForUpdate(result);
      }
      else {
        this.NotificationService.ForCreate(result);
      }
      this.getData(undefined);
    });
  }

  pageSizeOptions = GlobalOptions.pageSizeOptions;
  pageSize = GlobalOptions.defaultPageSize;
  pageEvent: PageEvent;

  getData(event) {
    //debugger;
    if (event != undefined) {
      this.filter.PageSize = event.pageSize;
      this.filter.PageNumber = event.pageIndex + 1;
    }

    this.subscription = this.NewsCategoryService.GetFilter(this.filter).subscribe(
      response => {
        //debugger;
        response['Data'].forEach(element => {
          element.IsCheck = false;
          if (element.Type == 'TT') {
            element.TypeText = 'Tin tức';
          }
          else if (element.Type == 'CM') {
            element.TypeText = 'Chuyên mục';
          }
        });

        this.categories = response;
      }
    )
    // ).unsubscribe();
  }

  ngOnInit() {
    this.getData(undefined);
  }

  ngOnDestroy() {

    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
