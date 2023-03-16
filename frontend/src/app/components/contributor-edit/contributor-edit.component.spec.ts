import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContributorEditComponent } from './contributor-edit.component';

describe('ContributorEditComponent', () => {
  let component: ContributorEditComponent;
  let fixture: ComponentFixture<ContributorEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContributorEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContributorEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
