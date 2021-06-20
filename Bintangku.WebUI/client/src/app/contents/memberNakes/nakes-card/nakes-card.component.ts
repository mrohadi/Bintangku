import { Component, Input, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { MemberNakes } from "src/app/_models/memberNakes";
import { NakesDetailComponent } from "../nakes-detail/nakes-detail.component";

@Component({
  selector: "app-nakes-card",
  templateUrl: "./nakes-card.component.html",
  styleUrls: ["./nakes-card.component.scss"],
})
export class NakesCardComponent {
  @Input() memberNakes: MemberNakes;
  @Input() skeleton = false;

  constructor(public dialog: MatDialog) {}

  openDialog(username:string): void {
    const dialogRef = this.dialog.open(NakesDetailComponent, {
      width: '767px',
      data: {username},
      panelClass:'custom-modalbox'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}
