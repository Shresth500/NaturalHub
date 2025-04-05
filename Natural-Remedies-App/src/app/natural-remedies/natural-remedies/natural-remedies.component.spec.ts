import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NaturalRemediesComponent } from './natural-remedies.component';

describe('NaturalRemediesComponent', () => {
  let component: NaturalRemediesComponent;
  let fixture: ComponentFixture<NaturalRemediesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NaturalRemediesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NaturalRemediesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
