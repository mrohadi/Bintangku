import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PemeriksaanKesehatanKmpe } from 'src/app/_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-kmpe';
import { PemeriksaanKesehatanKmpeService } from 'src/app/_services/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-kmpe.service';

@Component({
  selector: 'app-kmpe-show',
  templateUrl: './kmpe-show.component.html',
  styleUrls: ['./kmpe-show.component.css'],
})
export class KmpeShowComponent implements OnInit {
  public dataAnakId: number = this.data.dataAnakId;
  public resultKmpe: PemeriksaanKesehatanKmpe[];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _kmpeService: PemeriksaanKesehatanKmpeService
  ) {}

  ngOnInit(): void {
    this.getResultKmpe();
  }

  /**
   * getResultKmpe
   */
  public getResultKmpe() {
    this._kmpeService.getPemeriksaanKmpe(this.dataAnakId).subscribe((kmpe) => {
      this.resultKmpe = kmpe;
    });
  }
}
