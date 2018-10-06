import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FieldWrapperComponent } from './field-wrapper.component';

describe('FieldWrapperComponent', () => {
  let component: FieldWrapperComponent;
  let fixture: ComponentFixture<FieldWrapperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FieldWrapperComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FieldWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
