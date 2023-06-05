import { TestBed } from '@angular/core/testing';

import { ApplicationFileService } from './application-file.service';

describe('ApplicationFileService', () => {
  let service: ApplicationFileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApplicationFileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
