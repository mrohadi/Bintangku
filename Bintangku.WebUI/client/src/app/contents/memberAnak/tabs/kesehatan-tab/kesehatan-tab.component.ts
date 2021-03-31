import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { GpphShowComponent } from '../../dialogs-kesehatan-show/gpph-show/gpph-show.component';
import { KmpeShowComponent } from '../../dialogs-kesehatan-show/kmpe-show/kmpe-show.component';
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
}
