import { FieldDefinition } from './fieldDefinition';

export interface FieldValue<TValue> extends FieldDefinition {
  value: TValue;
}
