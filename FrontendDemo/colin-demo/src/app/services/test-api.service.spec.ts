import { TestBed } from '@angular/core/testing';

import { TestAPIService } from './test-api.service';

describe('TestAPIService', () => {
  let service: TestAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
