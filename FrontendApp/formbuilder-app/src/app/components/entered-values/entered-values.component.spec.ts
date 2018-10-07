import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnteredValuesComponent } from './entered-values.component';

describe('EnteredValuesComponent', () => {
  let component: EnteredValuesComponent;
  let fixture: ComponentFixture<EnteredValuesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnteredValuesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnteredValuesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
