
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { FieldValue, TextFieldDefinition } from './models/fieldValue';
import { FieldType } from './models/fieldDefinition';
export const gettoken = () => localStorage.getItem('token');

const textControl = (field: TextFieldDefinition) => {
  let validators = [];
  if (field.required) {
    validators = [Validators.required];
  }
  if (field.maxLength) {
    validators = [...validators, Validators.maxLength(field.maxLength)];
  }
  if (field.minLength) {
    validators = [...validators, Validators.minLength(field.minLength)];
  }
  return new FormControl(field.value || '', validators);
};
const checkboxControl = (field: FieldValue<boolean>) =>
  new FormControl(field.value, field.required ? Validators.requiredTrue : undefined);
const radioControl = (field: FieldValue<string>) =>
  new FormControl(field.value, field.required ? Validators.required : undefined);
const notimplemented = (def) => null as FormControl;
const controlmap: { [type in FieldType]: (def) => FormControl } = {
  Text: textControl,
  Dropdown: notimplemented,
  Date: notimplemented,
  Checkbox: checkboxControl,
  Number: notimplemented,
  Radio: radioControl
};
export function toFormGroup(fields: FieldValue<any>[]) {
  const group: any = {};

  fields.forEach(field => {
    group[field.fieldKey] = controlmap[field.type](field);
  });
  return new FormGroup(group);
}
