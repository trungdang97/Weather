import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { QuanLyTinBaiComponent } from './quan-ly-tin-bai/quan-ly-tin-bai.component';
import { QuanLyTinVideoComponent } from './quan-ly-tin-video/quan-ly-tin-video.component';
import { QuanLyCauHinhComponent } from './quan-tri-he-thong/quan-ly-cau-hinh.component';
import { QuanLyTaiKhoanComponent } from './quan-tri-he-thong/quan-ly-tai-khoan/quan-ly-tai-khoan.component';
import { CmsComponent } from './cms.component';
import { TheloaitinComponent } from './quan-tri-he-thong/quan-ly-danh-muc/theloaitin/theloaitin.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TheloaitinModalItemComponent } from './quan-tri-he-thong/quan-ly-danh-muc/theloaitin/theloaitin-modal-item/theloaitin-modal-item.component';
import { MatDialogModule, MatFormFieldModule, MAT_DIALOG_DATA, MatInputModule, MatTree, MatTreeModule, MatButtonModule, MatIconModule } from '@angular/material';
import { RouterModule } from '@angular/router';
import { ConfirmDialogComponent } from '../_layout/confirm-dialog/confirm-dialog.component';
import { QuanLyDieuHuongComponent } from './quan-tri-he-thong/quan-ly-dieu-huong/quan-ly-dieu-huong.component';
import { QuanLyNhomNguoiDungComponent } from './quan-tri-he-thong/quan-ly-nhom-nguoi-dung/quan-ly-nhom-nguoi-dung.component';
import { QuanLyQuyenNguoiDungComponent } from './quan-tri-he-thong/quan-ly-quyen-nguoi-dung/quan-ly-quyen-nguoi-dung.component';
import { NotifierModule } from 'angular-notifier/angular-notifier'
import { HttpClientModule } from '@angular/common/http';
import { NewsCategoryService } from './services/newscategory/newscategory.service';
import { IdmRightService } from './services/idm-right/idm-right.service';
import { ToastrModule} from 'ngx-toastr'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TreeModule } from 'angular-tree-component';

@NgModule({
  declarations: [
    DashboardComponent,
    QuanLyTinBaiComponent,
    QuanLyTinVideoComponent,
    QuanLyCauHinhComponent,
    QuanLyTaiKhoanComponent,
    CmsComponent,
    TheloaitinComponent,
    TheloaitinModalItemComponent,
    QuanLyDieuHuongComponent,
    QuanLyNhomNguoiDungComponent,
    QuanLyQuyenNguoiDungComponent,
    // ConfirmDialogComponent
  ],
  imports: [
    CommonModule,
    MatPaginatorModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    // MatTreeModule,
    // MatButtonModule,
    // MatIconModule,
    TreeModule.forRoot(),
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    })
  ],
  exports: [
    DashboardComponent,
    QuanLyTinBaiComponent,
    QuanLyTinVideoComponent,
    QuanLyCauHinhComponent,
    QuanLyTaiKhoanComponent,
    TheloaitinComponent
  ],
  entryComponents: [
    TheloaitinModalItemComponent,
    ConfirmDialogComponent
  ],
  providers:[
    { provide: MAT_DIALOG_DATA, useValue: {} },
    NewsCategoryService,
    IdmRightService
  ]
})
export class CmsModule { }
