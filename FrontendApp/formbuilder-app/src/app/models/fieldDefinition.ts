
export type FieldType = 'Text' | 'Dropdown' | 'Date' | 'Radio' | 'Checkbox' | 'Number';
export interface FieldDefinition extends Readonly<{
  formDefinitionId: string;
  required: boolean;
  fieldKey: string;
  fieldName: string;
  displayOrder: number;
  type: FieldType;
}> { }
