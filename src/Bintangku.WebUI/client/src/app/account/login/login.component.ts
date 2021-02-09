import { Component, OnInit } from "@angular/core";
import { AccountServices } from "src/app/_services/account.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(public accountService: AccountServices) {}

  ngOnInit(): void {}

  login() {
    this.accountService.loginService(this.model).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error.error);
      }
    );
  }
}
