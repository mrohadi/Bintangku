import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountServices } from '../_services/account.service';

@Injectable({
  providedIn: 'root',
})
export class AdminGuard implements CanActivate {
  constructor(
    private _accountService: AccountServices,
    private _toastr: ToastrService
  ) {}

  canActivate(): Observable<boolean> {
    return this._accountService.currentUser$.pipe(
      map((user) => {
        if (user.roles.includes('Admin') || user.roles.includes('Puskesmas')) {
          return true;
        }
        this._toastr.error('You cannot enter this area');
        return false;
      })
    );
  }
}
