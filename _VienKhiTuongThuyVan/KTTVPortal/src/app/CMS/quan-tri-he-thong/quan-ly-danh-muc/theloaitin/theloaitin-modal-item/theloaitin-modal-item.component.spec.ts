import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TheloaitinModalItemComponent } from './theloaitin-modal-item.component';

describe('TheloaitinModalItemComponent', () => {
  let component: TheloaitinModalItemComponent;
  let fixture: ComponentFixture<TheloaitinModalItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TheloaitinModalItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TheloaitinModalItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
