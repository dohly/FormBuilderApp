import { FieldDefinition } from './fieldDefinition';

export interface FormDefinition extends Readonly<{
  id: string;
  name: string;
  description: string;
  objectsCount: number;
  fields: FieldDefinition[];
}> { }
