import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GiziIpTb } from 'src/app/_models/kesehatan-fisik/gizi-ip-tb';
import { GiziIpTbService } from 'src/app/_services/kesehatan-fisik/gizi-ip-tb.service';

@Component({
  selector: 'app-gizi-ip-tb-show',
  templateUrl: './gizi-ip-tb-show.component.html',
  styleUrls: ['./gizi-ip-tb-show.component.css'],
})
export class GiziIpTbShowComponent implements OnInit {
  public dataAnakId: number = this.data.dataAnakId;
  public resultGiziIpTb: GiziIpTb[];

  constructor(
    private _giziIpTbService: GiziIpTbService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.getGiziIpTb();
  }

  public getGiziIpTb() {
    this._giziIpTbService
      .getGiziIpTb(this.dataAnakId)
      .subscribe((gizi) => (this.resultGiziIpTb = gizi));
  }
}
