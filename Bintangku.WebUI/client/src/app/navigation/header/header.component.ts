import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IsActiveMatchOptions, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountServices } from 'src/app/_services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  animations: [
    trigger('flyInOut', [
      state('in', style({ transform: 'translateX(0)' })),
      transition('void => *', [
        style({ transform: 'translateX(-100%)' }),
        animate(100)
      ]),
      transition('* => void', [
        animate(100, style({ transform: 'translateX(-100%)' }))
      ])
    ]),
    trigger('flyOutIn', [
      state('in', style({ transform: 'translateY(0)' })),
      transition('void => *', [
        style({ transform: 'translateY(100%)' }),
        animate(100)
      ]),
      transition('* => void', [
        animate(100, style({ transform: 'translateY(-100%)' }))
      ]),
    ])
  ]
})
export class HeaderComponent {
  model: any = {};
  @Output() public sidenavToggle = new EventEmitter();
  flexDir = 'col-col';

  iSactive: IsActiveMatchOptions ={
    matrixParams: 'exact',
    queryParams: 'exact',
    paths: 'exact',
    fragment: 'exact'
  }

  constructor(
    public accountService: AccountServices,
    private router: Router,
    private toastr: ToastrService
  ) {}

  login() {
    this.accountService.loginService(this.model).subscribe(
      (response) => {
        console.log(response);
        this.router.navigateByUrl('/');
        this.toastr.success('Nakes Login Successfully');
      },
      (error) => {
        console.log(error.error);
      }
    );
    console.log(this.model);
  }

  logout() {
    this.flexDir = 'col-re';
    this.toastr.success('Nakes Logout Successfully');
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  };
}
