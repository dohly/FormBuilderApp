import { Component, Input } from '@angular/core';
import { FieldValue, OptionsFieldDefinition } from '../models/fieldValue';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-field-wrapper',
  templateUrl: './field-wrapper.component.html',
  styleUrls: ['./field-wrapper.component.scss']
})
export class FieldWrapperComponent {
  @Input() public field: FieldValue<any>;
  @Input() public form: FormGroup;
  public get isValid() { return this.form.controls[this.field.fieldKey].valid; }
  public getOptions = (fd: OptionsFieldDefinition) => fd.avalableOptions;

}
