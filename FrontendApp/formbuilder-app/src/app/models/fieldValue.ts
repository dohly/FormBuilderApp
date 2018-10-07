import { FieldDefinition } from './fieldDefinition';

export interface FieldValue<TValue> extends FieldDefinition {
  value: TValue;
}
export interface TextFieldDefinition extends FieldValue<string>, Readonly<{
  minLength: number;
  maxLength: number;
}> { }

export interface NumberFieldDefinition extends FieldValue<number>, Readonly<{
  min: number;
  max: number;
}> { }
export interface OptionsFieldDefinition extends FieldValue<string> {
  avalableOptions: { value: string; text: string; }[];
}
