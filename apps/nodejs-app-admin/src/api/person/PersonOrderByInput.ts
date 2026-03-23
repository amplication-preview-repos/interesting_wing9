import { SortOrder } from "../../util/SortOrder";

export type PersonOrderByInput = {
  age?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  updatedAt?: SortOrder;
};
