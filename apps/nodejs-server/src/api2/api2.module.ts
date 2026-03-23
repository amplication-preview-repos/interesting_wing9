import { Module } from "@nestjs/common";
import { Api2Service } from "./api2.service";
import { Api2Controller } from "./api2.controller";
import { Api2Resolver } from "./api2.resolver";

@Module({
  controllers: [Api2Controller],
  providers: [Api2Service, Api2Resolver],
  exports: [Api2Service],
})
export class Api2Module {}
