import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PemeriksaanKesehatanMchat } from 'src/app/_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-mchat';
import { PemeriksaanKesehatanEmosionalMchatService } from 'src/app/_services/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-emosional-mchat.service';

@Component({
  selector: 'app-mchat-show',
  templateUrl: './mchat-show.component.html',
  styleUrls: ['./mchat-show.component.css'],
})
export class MchatShowComponent implements OnInit {
  public dataAnakId: number = this.data.dataAnakId;
  public resultMchat: PemeriksaanKesehatanMchat[];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _mchatService: PemeriksaanKesehatanEmosionalMchatService
  ) {}

  ngOnInit(): void {
    this.getPemeriksaanMchat();
  }

  /**
   * getPemeriksaanMchat
   */
  public getPemeriksaanMchat() {
    this._mchatService
      .getPemeriksaanMchat(this.dataAnakId)
      .subscribe((mchat) => (this.resultMchat = mchat));
  }
}
