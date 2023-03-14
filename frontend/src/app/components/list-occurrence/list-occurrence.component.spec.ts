import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOccurrenceComponent } from './list-occurrence.component';

describe('ListOccurrenceComponent', () => {
  let component: ListOccurrenceComponent;
  let fixture: ComponentFixture<ListOccurrenceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListOccurrenceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListOccurrenceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
