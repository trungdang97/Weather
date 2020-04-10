import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanLyQuyenNguoiDungComponent } from './quan-ly-quyen-nguoi-dung.component';

describe('QuanLyQuyenNguoiDungComponent', () => {
  let component: QuanLyQuyenNguoiDungComponent;
  let fixture: ComponentFixture<QuanLyQuyenNguoiDungComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuanLyQuyenNguoiDungComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanLyQuyenNguoiDungComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
