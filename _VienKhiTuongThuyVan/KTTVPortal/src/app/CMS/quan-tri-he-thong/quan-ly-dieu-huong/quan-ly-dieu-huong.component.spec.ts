import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanLyDieuHuongComponent } from './quan-ly-dieu-huong.component';

describe('QuanLyDieuHuongComponent', () => {
  let component: QuanLyDieuHuongComponent;
  let fixture: ComponentFixture<QuanLyDieuHuongComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuanLyDieuHuongComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanLyDieuHuongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
