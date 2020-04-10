import { TestBed } from '@angular/core/testing';

import { IdmRightService } from './idm-right.service';

describe('IdmRightService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: IdmRightService = TestBed.get(IdmRightService);
    expect(service).toBeTruthy();
  });
});
