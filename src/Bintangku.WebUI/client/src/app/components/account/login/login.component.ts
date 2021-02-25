import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AccountServices } from "src/app/_services/account.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(
    public accountService: AccountServices,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  login() {
    this.accountService.loginService(this.model).subscribe((response) => {
      console.log(response);
      this.router.navigateByUrl("/");
    });
  }
}
