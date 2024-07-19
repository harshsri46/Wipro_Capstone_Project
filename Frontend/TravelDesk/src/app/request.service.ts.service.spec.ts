import { TestBed } from '@angular/core/testing';

import { RequestServiceTsService } from './request.service.ts.service';

describe('RequestServiceTsService', () => {
  let service: RequestServiceTsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RequestServiceTsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
