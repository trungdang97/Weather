import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { NewsCategoryService } from '../../../../services/newscategory/newscategory.service';
import { Subscription } from 'rxjs';

import { DemoUserId } from 'src/app/app.config';
import { Notification } from '../../../../../_layout/utils/common-functions'
import { ModalItemData } from 'src/app/_layout/utils/common-classes';
import { NewsCategoryFilter, NewsCategory } from 'src/app/CMS/services/newscategory/newscategory.model';
import { NotificationService } from 'src/app/_layout/services/notification.service';

@Component({
  selector: 'app-theloaitin-modal-item',
  templateUrl: './theloaitin-modal-item.component.html',
  styleUrls: ['./theloaitin-modal-item.component.css']
})
export class TheloaitinModalItemComponent implements OnInit {

  constructor(
    private dialogRef: MatDialogRef<TheloaitinModalItemComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ModalItemData,
    private NewsCategoryService: NewsCategoryService,
    private NotificationService: NotificationService,
    private dialog: MatDialog,
    
  ) { }
  private notification = new Notification(this.dialog);
  
  public model: NewsCategory = new NewsCategory(); //= {

  public title = '';
  public titles = [
    'Thêm mới thể loại tin',
    'Cập nhật thể loại tin'
  ]
  public types = [
    {
      Value: null,
      Name: 'Chọn kiểu tin...',
      Disabled: true,
      Selected: true
    },
    {
      Value: 'TT',
      Name: 'Tin tức',
      Disabled: false,
      Selected: false
    },
    {
      Value: 'CM',
      Name: 'Chuyên mục',
      Disabled: false,
      Selected: false
    }
  ];

  Submit(form) {
    //debugger;
    if (!form.dirty || form.invalid) {
      return;
    }
    else {
      if (this.data.IsUpdate) {
        this.model.LastEditedByUserId = DemoUserId;
        this.NewsCategoryService.Update(this.model).subscribe(response => {
          if (response['Status'] == 1) {
            this.dialogRef.close(true);
          }
          else {
            this.NotificationService.ForUpdate(false);
          }
        });
      }
      else {
        //debugger;
        this.model.CreatedByUserId = DemoUserId;
        this.NewsCategoryService.Create(this.model).subscribe(response => {
          if (response['Status'] == 1) {
            this.dialogRef.close(true);
          }
          else {
            this.NotificationService.ForCreate(false);
          }
        });
      }
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
    if (!this.data.IsUpdate) {
      this.title = this.titles[0];
    }
    else {
      //debugger;
      this.title = this.titles[1];
      let filter = new NewsCategoryFilter();
      filter.NewsCategoryId = this.data.Id;
      this.NewsCategoryService.GetFilter(filter).subscribe(response => {
        this.model = response['Data'][0];
        //console.log(model);
      });
    }
  }



}
