//import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TinTucComponent } from './tin-tuc/tin-tuc.component';
import { TrangChuComponent } from './trang-chu/trang-chu.component';
import { DashboardComponent } from './CMS/dashboard/dashboard.component';
import { CmsComponent } from './CMS/cms.component';
import { QuanLyCauHinhComponent } from './CMS/quan-tri-he-thong/quan-ly-cau-hinh.component';
import { QuanLyTaiKhoanComponent } from './CMS/quan-tri-he-thong/quan-ly-tai-khoan/quan-ly-tai-khoan.component';
import { QuanLyTinBaiComponent } from './CMS/quan-ly-tin-bai/quan-ly-tin-bai.component';
import { QuanLyTinVideoComponent } from './CMS/quan-ly-tin-video/quan-ly-tin-video.component';
import { AppComponent } from './app.component';
import { LayoutMainComponent } from './_layout/layout-main/layout-main.component';
import { LayoutCmsComponent } from './_layout/layout-cms/layout-cms.component';
import { TheloaitinComponent } from './CMS/quan-tri-he-thong/quan-ly-danh-muc/theloaitin/theloaitin.component';
import { QuanLyDieuHuongComponent } from './CMS/quan-tri-he-thong/quan-ly-dieu-huong/quan-ly-dieu-huong.component';
import { QuanLyNhomNguoiDungComponent } from './CMS/quan-tri-he-thong/quan-ly-nhom-nguoi-dung/quan-ly-nhom-nguoi-dung.component';
import { QuanLyQuyenNguoiDungComponent } from './CMS/quan-tri-he-thong/quan-ly-quyen-nguoi-dung/quan-ly-quyen-nguoi-dung.component';


const routes: Routes = [
  // front page
  {
    path: '',
    component: LayoutMainComponent,
    children: [
      { path: '', redirectTo: 'trang-chu', pathMatch: 'full' },
      { path: 'trang-chu', component: TrangChuComponent },
      { path: 'tin-tuc', component: TinTucComponent },
    ]
  },
  //CMS
  {
    path: 'cms',
    component: LayoutCmsComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      {
        path: 'quan-ly-danh-muc', component: QuanLyCauHinhComponent, children: [
          { path: 'the-loai-tin', component: TheloaitinComponent },
        ]
      },
      {
        path: 'quan-tri-he-thong', component: QuanLyCauHinhComponent, children: [
          { path: 'quan-ly-dieu-huong', component: QuanLyDieuHuongComponent },
          { path: 'quan-ly-nhom-nguoi-dung', component: QuanLyNhomNguoiDungComponent },
          { path: 'quan-ly-tai-khoan', component: QuanLyTaiKhoanComponent },
          { path: 'quan-ly-quyen-nguoi-dung', component: QuanLyQuyenNguoiDungComponent },
        ]
      },

      { path: 'quan-ly-tin-bai', component: QuanLyTinBaiComponent },
      { path: 'quan-ly-tin-video', component: QuanLyTinVideoComponent },
    ]
  },
  // redirect
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

export const routing = RouterModule.forRoot(routes);
// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
