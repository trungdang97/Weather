import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanLyTinBaiComponent } from './quan-ly-tin-bai.component';

describe('QuanLyTinBaiComponent', () => {
  let component: QuanLyTinBaiComponent;
  let fixture: ComponentFixture<QuanLyTinBaiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuanLyTinBaiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanLyTinBaiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
