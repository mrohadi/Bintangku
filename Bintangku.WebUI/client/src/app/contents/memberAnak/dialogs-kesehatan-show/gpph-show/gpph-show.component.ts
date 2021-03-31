import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PemeriksaanKesehatanGpph } from 'src/app/_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-gpph';
import { PemeriksaanKesehatanEmosionalGpphService } from 'src/app/_services/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-emosional-gpph.service';

@Component({
  selector: 'app-gpph-show',
  templateUrl: './gpph-show.component.html',
  styleUrls: ['./gpph-show.component.css'],
})
export class GpphShowComponent implements OnInit {
  public dataAnakId: number = this.data.dataAnakId;
  public resultGpph: PemeriksaanKesehatanGpph[];

  constructor(
    private _gpph: PemeriksaanKesehatanEmosionalGpphService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.getResultGpph();
  }

  getResultGpph() {
    this._gpph.getPemeriksaanGpph(this.dataAnakId).subscribe((gpph) => {
      this.resultGpph = gpph;
    });
  }
}
