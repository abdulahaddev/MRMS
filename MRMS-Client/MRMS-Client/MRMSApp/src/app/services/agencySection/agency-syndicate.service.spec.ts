import { TestBed } from '@angular/core/testing';

import { AgencySyndicateService } from './agency-syndicate.service';

describe('AgencySyndicateService', () => {
  let service: AgencySyndicateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AgencySyndicateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
