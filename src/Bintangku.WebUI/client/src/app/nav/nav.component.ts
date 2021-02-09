import { Component, OnInit } from "@angular/core";
import { AccountServices } from "../_services/account.service";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"],
})
export class NavComponent implements OnInit {
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

  logout() {
    this.accountService.logout();
  }
}
