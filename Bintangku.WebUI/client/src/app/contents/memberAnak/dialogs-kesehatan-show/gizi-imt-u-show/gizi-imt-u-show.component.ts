import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GiziImtU } from 'src/app/_models/kesehatan-fisik/gizi-imt-u';
import { GiziImtUService } from 'src/app/_services/kesehatan-fisik/gizi-imt-u.service';

@Component({
  selector: 'app-gizi-imt-u-show',
  templateUrl: './gizi-imt-u-show.component.html',
  styleUrls: ['./gizi-imt-u-show.component.css'],
})
export class GiziImtUShowComponent implements OnInit {
  public dataAnakId: number = this.data.dataAnakId;
  public resultGiziImtU: GiziImtU[];

  constructor(
    private _giziImtU: GiziImtUService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.getGiziIpTb();
  }

  public getGiziIpTb() {
    this._giziImtU
      .getGiziImtU(this.dataAnakId)
      .subscribe((gizi) => (this.resultGiziImtU = gizi));
  }
}
