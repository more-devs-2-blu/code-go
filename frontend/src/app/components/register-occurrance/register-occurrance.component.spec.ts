import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterOccurranceComponent } from './register-occurrance.component';

describe('RegisterOccurranceComponent', () => {
  let component: RegisterOccurranceComponent;
  let fixture: ComponentFixture<RegisterOccurranceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterOccurranceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterOccurranceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
