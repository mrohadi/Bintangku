import { OnDestroy } from "@angular/core";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ErrorsService } from "src/app/_services/errors.service";

@Component({
  selector: "app-server-error",
  templateUrl: "./server-error.component.html",
  styleUrls: ["./server-error.component.css"],
})
export class ServerErrorComponent implements OnDestroy {
  error: any;

  constructor(private router: Router, private errorsService: ErrorsService) {
    const navigation = this.router.getCurrentNavigation();
    this.error = navigation?.extras?.state?.error;
  }
  ngOnDestroy(){
    this.errorsService.changeStatus(false);
  }
}
