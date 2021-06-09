import { Component, Input, OnInit } from "@angular/core";
import { MemberNakes } from "src/app/_models/memberNakes";

@Component({
  selector: "app-nakes-card",
  templateUrl: "./nakes-card.component.html",
  styleUrls: ["./nakes-card.component.scss"],
})
export class NakesCardComponent {
  @Input() memberNakes: MemberNakes;

  constructor() {}

}
