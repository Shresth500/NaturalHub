import { TestBed } from '@angular/core/testing';

import { HealthTipsService } from './health-tips.service';

describe('HealthTipsService', () => {
  let service: HealthTipsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HealthTipsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
