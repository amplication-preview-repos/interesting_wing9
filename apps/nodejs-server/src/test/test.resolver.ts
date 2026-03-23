import * as graphql from "@nestjs/graphql";
import { TestResolverBase } from "./base/test.resolver.base";
import { Test } from "./base/Test";
import { TestService } from "./test.service";

@graphql.Resolver(() => Test)
export class TestResolver extends TestResolverBase {
  constructor(protected readonly service: TestService) {
    super(service);
  }
}
