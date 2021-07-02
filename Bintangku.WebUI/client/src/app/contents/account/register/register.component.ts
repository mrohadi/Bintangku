import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountServices } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  formRegister: FormGroup;

  model: any = {};
  validationErrors: string[] = [];

  constructor(
    private accountService: AccountServices,
    private router: Router,
    private toastr: ToastrService,
    fb: FormBuilder
  ) {
    this.formRegister = fb.group({
      email: ['', [Validators.required, Validators.email]],
      username: ['', Validators.required],
      fullname: ['', Validators.required],
      phonenumber: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
      tempatpelayanan: ['', Validators.required],
      nostrtenagakesehatan: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
      password: ['', Validators.required],
    });
  }

  register(form:FormGroup) {
    this.accountService.registerService(form.value).subscribe(
      (response) => {
        console.log(response);
        this.router.navigateByUrl('/');
      },
      (error) => {
        console.log(error);
        // this.toastr.error(error.error.Password);
        this.validationErrors = error;
      }
    );
  }

  cancel(): void {
    console.log('Canceled');
    this.formRegister.reset;
    this.router.navigate(['/']);
  }
  getErrorMessage(field: string) {
    if (this.formRegister.get(field).errors.required) return 'You must enter a value';
    else if (this.formRegister.get(field).errors.email) return 'Not a valid email';
    else if (this.formRegister.get(field).errors.pattern) return 'Not a valid number';
  }
}
