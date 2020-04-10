import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TheloaitinComponent } from './theloaitin.component';

describe('TheloaitinComponent', () => {
  let component: TheloaitinComponent;
  let fixture: ComponentFixture<TheloaitinComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TheloaitinComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TheloaitinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
