import { FieldDefinition } from './fieldDefinition';

export interface FormDefinition extends Readonly<{
  id: string;
  name: string;
  description: string;
  fields: FieldDefinition[];
}> { }
