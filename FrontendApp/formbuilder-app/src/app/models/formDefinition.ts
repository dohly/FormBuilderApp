export type FieldType = 'Text' | 'DateTime';
export interface FieldDefinition extends Readonly<{
  formDefinitionId: string;
  optional: boolean;
  fieldKey: string;
  fieldName: string;
  displayOrder: number;
  type: FieldType;
}> { }
export interface FormDefinition extends Readonly<{
  id: string;
  name: string;
  fields: FieldDefinition[];
}> { }
