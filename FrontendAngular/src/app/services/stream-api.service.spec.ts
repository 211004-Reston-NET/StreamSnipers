import { TestBed } from '@angular/core/testing';

import { StreamAPIService } from './stream-api.service';

describe('StreamAPIService', () => {
  let service: StreamAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StreamAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
