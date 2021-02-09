import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AccountServices } from "src/app/_services/account.service";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"],
})
export class RegisterComponent implements OnInit {
  model: any = {};

  constructor(
    private accountService: AccountServices,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  register() {
    this.accountService.registerService(this.model).subscribe(
      (response) => {
        console.log(response);
        this.router.navigateByUrl("/");
      },
      (error) => {
        console.log(error);
        this.toastr.error(error.error.errors.Password);
      }
    );
  }

  cancel(): void {
    console.log("Canceled");
  }
}
