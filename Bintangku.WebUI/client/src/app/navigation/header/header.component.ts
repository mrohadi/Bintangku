import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountServices } from 'src/app/_services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  model: any = {};
  @Output() public sidenavToggle = new EventEmitter();

  constructor(
    public accountService: AccountServices,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

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
    this.toastr.success('Nakes Logout Successfully');
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  };
}
