import { TestBed } from '@angular/core/testing';

import { NewsCategoryService } from './newscategory.service';

describe('NewscategoriesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NewsCategoryService = TestBed.get(NewsCategoryService);
    expect(service).toBeTruthy();
  });
});
