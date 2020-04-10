import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanLyTinVideoComponent } from './quan-ly-tin-video.component';

describe('QuanLyTinVideoComponent', () => {
  let component: QuanLyTinVideoComponent;
  let fixture: ComponentFixture<QuanLyTinVideoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuanLyTinVideoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanLyTinVideoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
