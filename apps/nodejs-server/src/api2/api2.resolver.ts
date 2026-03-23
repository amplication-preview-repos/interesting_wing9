import * as graphql from "@nestjs/graphql";
import { Api2Service } from "./api2.service";

export class Api2Resolver {
  constructor(protected readonly service: Api2Service) {}
}
