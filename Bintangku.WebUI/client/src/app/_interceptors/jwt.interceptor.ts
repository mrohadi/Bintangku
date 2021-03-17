import { Injectable } from "@angular/core";
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from "@angular/common/http";
import { Observable } from "rxjs";
import { AccountServices } from "../_services/account.service";
import { User } from "../_models/user";
import { take } from "rxjs/operators";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private accountService: AccountServices) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    let currentNakesUser: User;

    this.accountService.currentUser$
      .pipe(take(1))
      .subscribe((nakesUser) => (currentNakesUser = nakesUser));

    if (currentNakesUser) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentNakesUser.token}`,
        },
      });
    }

    return next.handle(request);
  }
}
