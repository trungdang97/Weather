import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanLyNhomNguoiDungComponent } from './quan-ly-nhom-nguoi-dung.component';

describe('QuanLyNhomNguoiDungComponent', () => {
  let component: QuanLyNhomNguoiDungComponent;
  let fixture: ComponentFixture<QuanLyNhomNguoiDungComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuanLyNhomNguoiDungComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanLyNhomNguoiDungComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
