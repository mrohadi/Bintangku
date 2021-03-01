import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BeratBadanComponent } from '../dialogs/berat-badan/berat-badan.component';
import { KpspComponent } from '../dialogs/kpsp/kpsp.component';
import { LingkarKepalaComponent } from '../dialogs/lingkar-kepala/lingkar-kepala.component';
import { TinggiBadanComponent } from '../dialogs/tinggi-badan/tinggi-badan.component';

@Component({
  selector: 'app-anak-pemeriksaan',
  templateUrl: './anak-pemeriksaan.component.html',
  styleUrls: ['./anak-pemeriksaan.component.css'],
})
export class AnakPemeriksaanComponent implements OnInit {
  constructor(public dialog: MatDialog) {}

  openBeratBadan() {
    const dialogRef = this.dialog.open(BeratBadanComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openTinggiBadan() {
    const dialogRef = this.dialog.open(TinggiBadanComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openLingkarKepala() {
    const dialogRef = this.dialog.open(LingkarKepalaComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openKpsp() {
    const dialogRef = this.dialog.open(KpspComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  ngOnInit(): void {}
}
