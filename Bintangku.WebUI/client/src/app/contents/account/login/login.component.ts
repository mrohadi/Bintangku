import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountServices } from 'src/app/_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  model: any = {};
  form: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  constructor(
    public accountService: AccountServices,
    private router: Router,
    private toastr: ToastrService
  ) {}

  login() {
    this.accountService.loginService(this.form.value).subscribe((response) => {
      console.log(response);
      this.router.navigateByUrl('/');
      this.toastr.success('Nakes Login Successfully');
    });
  }
}
