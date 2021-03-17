import { Component, OnInit } from "@angular/core";
import { take } from "rxjs/operators";
import { MemberNakes } from "src/app/_models/memberNakes";
import { User } from "src/app/_models/user";
import { AccountServices } from "src/app/_services/account.service";
import { MembersNakesService } from "src/app/_services/membersNakes.service";

@Component({
  selector: "app-nakes-edit",
  templateUrl: "./nakes-edit.component.html",
  styleUrls: ["./nakes-edit.component.css"],
})
export class NakesEditComponent implements OnInit {
  memberNakes: MemberNakes;
  userNakes: User;

  constructor(
    private accountService: AccountServices,
    private membersNakesService: MembersNakesService
  ) {
    this.accountService.currentUser$
      .pipe(take(1))
      .subscribe((userNakes) => (this.userNakes = userNakes));
  }

  ngOnInit(): void {
    this.loadMemberNakes();
  }

  loadMemberNakes() {
    this.membersNakesService
      .getMemberNakes(this.userNakes.username)
      .subscribe((memberNakes) => (this.memberNakes = memberNakes));
  }
}
