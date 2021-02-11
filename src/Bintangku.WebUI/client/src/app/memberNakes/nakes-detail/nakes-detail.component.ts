import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { MemberNakes } from "src/app/_models/memberNakes";
import { MembersNakesService } from "src/app/_services/membersNakes.service";

@Component({
  selector: "app-nakes-detail",
  templateUrl: "./nakes-detail.component.html",
  styleUrls: ["./nakes-detail.component.css"],
})
export class NakesDetailComponent implements OnInit {
  memberNakes: MemberNakes;

  constructor(
    private memberNakesService: MembersNakesService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadMemberNakes();
  }

  loadMemberNakes() {
    this.memberNakesService
      .getMemberNakes(this.route.snapshot.paramMap.get("username"))
      .subscribe((memberNakes) => (this.memberNakes = memberNakes));
  }
}
