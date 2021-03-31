import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DayaLihat } from 'src/app/_models/kesehatan-fisik/data-lihat';
import { DayaLihatService } from 'src/app/_services/kesehatan-fisik/daya-lihat.service';

@Component({
  selector: 'app-daya-lihat-show',
  templateUrl: './daya-lihat-show.component.html',
  styleUrls: ['./daya-lihat-show.component.css'],
})
export class DayaLihatShowComponent implements OnInit {
  public dataAnakId: number = this.data.dataAnakId;
  public resultDayaLihat: DayaLihat[];

  constructor(
    private _dayaLihatservice: DayaLihatService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.getResultDayaLihat();
  }

  public getResultDayaLihat() {
    this._dayaLihatservice
      .getDayaLihat(this.dataAnakId)
      .subscribe((dayaLihat) => (this.resultDayaLihat = dayaLihat));
  }
}
