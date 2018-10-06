
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { FieldValue } from './models/fieldValue';
export const gettoken = () => localStorage.getItem('token');
export function toFormGroup(fields: FieldValue<any>[]) {
  const group: any = {};

  fields.forEach(field => {
    group[field.fieldKey] = field.required ?
      new FormControl(field.value || '', Validators.required)
      : new FormControl(field.value || '');
  });
  return new FormGroup(group);
}
