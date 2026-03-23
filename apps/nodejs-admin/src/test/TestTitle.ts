import { Test as TTest } from "../api/test/Test";

export const TEST_TITLE_FIELD = "age";

export const TestTitle = (record: TTest): string => {
  return record.age?.toString() || String(record.id);
};
