import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { MatPaginatorModule, MatPaginatorIntl } from '@angular/material/paginator'

import { routing } from './app-routing';

import { AppComponent } from './app.component';
import { TinTucComponent } from './tin-tuc/tin-tuc.component';
import { TrangChuComponent } from './trang-chu/trang-chu.component';

import { CmsModule } from './CMS/cms.module';

import { LayoutMainComponent } from './_layout/layout-main/layout-main.component';
import { LayoutCmsComponent } from './_layout/layout-cms/layout-cms.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { getVietnamesePaginatorIntl } from './vietnamese-mat-paginator';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material';
import { ConfirmDialogComponent } from './_layout/confirm-dialog/confirm-dialog.component';
import { APP_CONFIG, AppConfig, DemoUserId } from './app.config';
import { NotifierModule } from 'angular-notifier';




@NgModule({
  declarations: [
    AppComponent,
    TinTucComponent,
    TrangChuComponent,
    LayoutMainComponent,
    LayoutCmsComponent,
    ConfirmDialogComponent,

  ],
  imports: [
    BrowserModule,
    routing,
    HttpClientModule,
    //AppRoutingModule,
    CmsModule,
    BrowserAnimationsModule,
    MatPaginatorModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    NotifierModule,
    
  ],
  providers: [
    { provide: APP_CONFIG, useValue: AppConfig },
    { provide: MatPaginatorIntl, useValue: getVietnamesePaginatorIntl() },
    { provide: DemoUserId, useValue: DemoUserId }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
