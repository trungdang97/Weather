import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutCmsComponent } from './layout-cms.component';

describe('LayoutCmsComponent', () => {
  let component: LayoutCmsComponent;
  let fixture: ComponentFixture<LayoutCmsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LayoutCmsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LayoutCmsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
