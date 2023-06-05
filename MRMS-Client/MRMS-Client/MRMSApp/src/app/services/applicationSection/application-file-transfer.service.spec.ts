import { TestBed } from '@angular/core/testing';

import { ApplicationFileTransferService } from './application-file-transfer.service';

describe('ApplicationFileTransferService', () => {
  let service: ApplicationFileTransferService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApplicationFileTransferService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
