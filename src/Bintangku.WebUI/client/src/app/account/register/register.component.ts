import { Component, OnInit } from "@angular/core";
import { AccountServices } from "src/app/_services/account.service";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"],
})
export class RegisterComponent implements OnInit {
  model: any = {};

  constructor(private accountService: AccountServices) {}

  ngOnInit(): void {}

  register() {
    this.accountService.registerService(this.model).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  cancel(): void {
    console.log("Canceled");
  }
}
