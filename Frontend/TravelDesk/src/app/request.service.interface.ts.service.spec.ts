import { TestBed } from '@angular/core/testing';

import { RequestServiceInterfaceTsService } from './request.service.interface.ts.service';

describe('RequestServiceInterfaceTsService', () => {
  let service: RequestServiceInterfaceTsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RequestServiceInterfaceTsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
