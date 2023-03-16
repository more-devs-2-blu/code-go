import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OccurranceDetailsComponent } from './occurrance-details.component';

describe('OccurranceDetailsComponent', () => {
  let component: OccurranceDetailsComponent;
  let fixture: ComponentFixture<OccurranceDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OccurranceDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OccurranceDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
