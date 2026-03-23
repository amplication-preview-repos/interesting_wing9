import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as errors from "../errors";
import { Api2Service } from "./api2.service";

@swagger.ApiTags("api2s")
@common.Controller("api2s")
export class Api2Controller {
  constructor(protected readonly service: Api2Service) {}
}
