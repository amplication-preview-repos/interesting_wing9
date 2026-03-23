import * as React from "react";
import { Edit, SimpleForm, EditProps, NumberInput } from "react-admin";

export const PersonEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <NumberInput step={1} label="age" source="age" />
      </SimpleForm>
    </Edit>
  );
};
