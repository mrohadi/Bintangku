import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { AccountServices } from "../_services/account.service";

@Component({
  selector: "app-nakes",
  templateUrl: "./nakes.component.html",
  styleUrls: ["./nakes.component.css"],
})
export class NakesComponent implements OnInit {
  nakesUsers: any;

  constructor(
    private accountService: AccountServices,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.getNakesUsers();
  }

  getNakesUsers() {
    this.http.get("https://localhost:5001/api/nakesusers").subscribe(
      (response) => {
        this.nakesUsers = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
