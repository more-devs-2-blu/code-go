import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOccurrenceComponent } from './add-occurrence.component';

describe('AddOccurrenceComponent', () => {
  let component: AddOccurrenceComponent;
  let fixture: ComponentFixture<AddOccurrenceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddOccurrenceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddOccurrenceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
