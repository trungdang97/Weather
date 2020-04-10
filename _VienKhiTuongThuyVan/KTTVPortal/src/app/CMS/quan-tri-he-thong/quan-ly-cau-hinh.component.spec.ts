import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanLyCauHinhComponent } from './quan-ly-cau-hinh.component';

describe('QuanLyCauHinhComponent', () => {
  let component: QuanLyCauHinhComponent;
  let fixture: ComponentFixture<QuanLyCauHinhComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuanLyCauHinhComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanLyCauHinhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
