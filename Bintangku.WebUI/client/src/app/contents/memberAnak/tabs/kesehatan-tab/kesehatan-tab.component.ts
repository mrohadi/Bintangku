import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { DayaLihatInputComponent } from '../../dialogs-kesehatan-input/daya-lihat-input/daya-lihat-input.component';
import { GiziBbTbInputComponent } from '../../dialogs-kesehatan-input/gizi-bb-tb-input/gizi-bb-tb-input.component';
import { GiziImtUComponent } from '../../dialogs-kesehatan-input/gizi-imt-u/gizi-imt-u.component';
import { GiziIpTbInputComponent } from '../../dialogs-kesehatan-input/gizi-ip-tb-input/gizi-ip-tb-input.component';
import { GpphInputComponent } from '../../dialogs-kesehatan-input/gpph-input/gpph-input.component';
import { KmpeInputComponent } from '../../dialogs-kesehatan-input/kmpe-input/kmpe-input.component';
import { LingkarKepalaInputComponent } from '../../dialogs-kesehatan-input/lingkar-kepala-input/lingkar-kepala-input.component';
import { MchatInputComponent } from '../../dialogs-kesehatan-input/mchat-input/mchat-input.component';
import { DayaDengarShowComponent } from '../../dialogs-kesehatan-show/daya-dengar-show/daya-dengar-show.component';
import { DayaLihatShowComponent } from '../../dialogs-kesehatan-show/daya-lihat-show/daya-lihat-show.component';
import { GiziBbTbShowComponent } from '../../dialogs-kesehatan-show/gizi-bb-tb-show/gizi-bb-tb-show.component';
import { GiziImtUShowComponent } from '../../dialogs-kesehatan-show/gizi-imt-u-show/gizi-imt-u-show.component';
import { GiziIpTbShowComponent } from '../../dialogs-kesehatan-show/gizi-ip-tb-show/gizi-ip-tb-show.component';
import { GiziLingkarKepalaShowComponent } from '../../dialogs-kesehatan-show/gizi-lingkar-kepala-show/gizi-lingkar-kepala-show.component';
import { GpphShowComponent } from '../../dialogs-kesehatan-show/gpph-show/gpph-show.component';
import { KmpeShowComponent } from '../../dialogs-kesehatan-show/kmpe-show/kmpe-show.component';
import { KpspShowComponent } from '../../dialogs-kesehatan-show/kpsp-show/kpsp-show.component';
import { MchatShowComponent } from '../../dialogs-kesehatan-show/mchat-show/mchat-show.component';

@Component({
  selector: 'app-kesehatan-tab',
  templateUrl: './kesehatan-tab.component.html',
  styleUrls: ['./kesehatan-tab.component.css'],
})
export class KesehatanTabComponent implements OnInit {
  public dataAnakId: number = parseInt(this.route.snapshot.paramMap.get('id'));
  constructor(private dialog: MatDialog, private route: ActivatedRoute) {}

  ngOnInit(): void {}

  /**
   * openGpphShow
   */
  public openGpphShow() {
    const dialogRef = this.dialog.open(GpphShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openKmpeShow
   */
  public openKmpeShow() {
    const dialogRef = this.dialog.open(KmpeShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openMchatShow
   */
  public openMchatShow() {
    const dialogRef = this.dialog.open(MchatShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openDayaLihat
   */
  public openDayaLihat() {
    const dialogRef = this.dialog.open(DayaLihatShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openDayaDengar
   */
  public openDayaDengar() {
    const dialogRef = this.dialog.open(DayaDengarShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openKpsp
   */
  public openKpsp() {
    const dialogRef = this.dialog.open(KpspShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openStatusGiziBbTb
   */
  public openStatusGiziBbTb() {
    const dialogRef = this.dialog.open(GiziBbTbShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openStatusGiziImtU
   */
  public openStatusGiziImtU() {
    const dialogRef = this.dialog.open(GiziImtUShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openStatusGiziImtU
   */
  public openStatusGiziIpTb() {
    const dialogRef = this.dialog.open(GiziIpTbShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openLingkarKepala
   */
  public openLingkarKepala() {
    const dialogRef = this.dialog.open(GiziLingkarKepalaShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openGiziBbTbShow
   */
  public openGiziBbTbShow() {
    const dialogRef = this.dialog.open(GiziBbTbShowComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  // Open Input Dialog

  /**
   * openGpphInput
   */
  public openGpphInput() {
    const dialogRef = this.dialog.open(GpphInputComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openKmpeInput
   */
  public openKmpeInput() {
    const dialogRef = this.dialog.open(KmpeInputComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openMchatInput
   */
  public openMchatInput() {
    const dialogRef = this.dialog.open(MchatInputComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openDayaLihatInput
   */
  public openDayaLihatInput() {
    const dialogRef = this.dialog.open(DayaLihatInputComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * openGiziIpTbInput
   */
  public openGiziIpTbInput() {
    const dialogRef = this.dialog.open(GiziIpTbInputComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * oepnGiziItmU
   */
  public oepnGiziItmUInput() {
    const dialogRef = this.dialog.open(GiziImtUComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * oepnGiziItmU
   */
  public oepnGiziBbTbInput() {
    const dialogRef = this.dialog.open(GiziBbTbInputComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }

  /**
   * oepnGiziItmU
   */
  public oepnLingkarKepalaInput() {
    const dialogRef = this.dialog.open(LingkarKepalaInputComponent, {
      data: { dataAnakId: this.dataAnakId },
    });

    dialogRef.afterClosed().subscribe(() => {});
  }
}
