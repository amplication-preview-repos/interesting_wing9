import { Person as TPerson } from "../api/person/Person";

export const PERSON_TITLE_FIELD = "id";

export const PersonTitle = (record: TPerson): string => {
  return record.id?.toString() || String(record.id);
};
