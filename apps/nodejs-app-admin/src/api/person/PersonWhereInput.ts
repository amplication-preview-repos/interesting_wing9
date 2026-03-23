import { IntNullableFilter } from "../../util/IntNullableFilter";
import { StringFilter } from "../../util/StringFilter";

export type PersonWhereInput = {
  age?: IntNullableFilter;
  id?: StringFilter;
};
