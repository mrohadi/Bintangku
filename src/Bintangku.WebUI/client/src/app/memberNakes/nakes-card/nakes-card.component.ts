import { Component, Input, OnInit } from "@angular/core";
import { MemberNakes } from "src/app/_models/memberNakes";

@Component({
  selector: "app-nakes-card",
  templateUrl: "./nakes-card.component.html",
  styleUrls: ["./nakes-card.component.css"],
})
export class NakesCardComponent implements OnInit {
  @Input() memberNakes: MemberNakes;

  constructor() {}

  ngOnInit(): void {}
}
