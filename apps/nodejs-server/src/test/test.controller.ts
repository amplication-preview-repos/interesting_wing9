import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { TestService } from "./test.service";
import { TestControllerBase } from "./base/test.controller.base";

@swagger.ApiTags("tests")
@common.Controller("tests")
export class TestController extends TestControllerBase {
  constructor(protected readonly service: TestService) {
    super(service);
  }
}
