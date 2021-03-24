import { Component, OnInit } from '@angular/core';
import {
  DateAdapter,
  MAT_DATE_FORMATS,
  MAT_DATE_LOCALE,
} from '@angular/material/core';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatDialog } from '@angular/material/dialog';
import { BeratBadanComponent } from '../dialogs/berat-badan/berat-badan.component';
import { GpphComponent } from '../dialogs/gpph/gpph.component';
import { KpspComponent } from '../dialogs/kpsp/kpsp.component';
import { LingkarKepalaComponent } from '../dialogs/lingkar-kepala/lingkar-kepala.component';
import { TinggiBadanComponent } from '../dialogs/tinggi-badan/tinggi-badan.component';

export const MY_FORMATS = {
  parse: {
    dateInput: 'LL',
  },
  display: {
    dateInput: 'YYYY-MM-DD',
    monthYearLabel: 'YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'YYYY',
  },
};

@Component({
  selector: 'app-anak-pemeriksaan',
  templateUrl: './anak-pemeriksaan.component.html',
  styleUrls: ['./anak-pemeriksaan.component.css'],
  providers: [
    // `MomentDateAdapter` can be automatically provided by importing `MomentDateModule` in your
    // application's root module. We provide it at the component level here, due to limitations of
    // our example generation script.
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE],
    },

    { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
  ],
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

  openGpph() {
    const dialogRef = this.dialog.open(GpphComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
    });
  }

  ngOnInit(): void {}
}
