import { TestBed } from '@angular/core/testing';

import { RemediesService } from './remedies.service';

describe('RemediesService', () => {
  let service: RemediesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RemediesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
