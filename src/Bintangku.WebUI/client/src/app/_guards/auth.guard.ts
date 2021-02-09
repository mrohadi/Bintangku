import { Injectable } from "@angular/core";
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
} from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { AccountServices } from "../_services/account.service";

@Injectable({
  providedIn: "root",
})
export class AuthGuard implements CanActivate {
  constructor(
    private accountService: AccountServices,
    private toastrService: ToastrService
  ) {}

  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map((user) => {
        if (user) return true;
        this.toastrService.error("You shall not pass!");
      })
    );
  }
}
