import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  title = "Bintangku";
  nakesUsers: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getUser();
  }

  getUser() {
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
