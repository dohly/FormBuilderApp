import { Component, Input } from '@angular/core';
import { FieldValue, OptionsFieldDefinition } from '../models/fieldValue';
import { FormGroup } from '@angular/forms';
import { FieldDefinition, FieldType } from '../models/fieldDefinition';

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
  public getInputType = (fd: FieldDefinition) => {
    const map: { [key in FieldType]: string } = {
      Date: 'date',
      Number: 'number',
      Text: 'text',
      Dropdown: null,
      Checkbox: null,
      Radio: null,
    };
    return map[this.field.type];
  }
}
