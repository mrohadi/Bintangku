import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GiziBbTb } from 'src/app/_models/kesehatan-fisik/gizi-bb-tb';
import { GiziBbTbService } from 'src/app/_services/kesehatan-fisik/gizi-bb-tb.service';

@Component({
  selector: 'app-gizi-bb-tb-show',
  templateUrl: './gizi-bb-tb-show.component.html',
  styleUrls: ['./gizi-bb-tb-show.component.css'],
})
export class GiziBbTbShowComponent implements OnInit {
  public dataAnakId: number = this.data.dataAnakId;
  public resultGiziBbTb: GiziBbTb[];

  constructor(
    private _giziBbTbService: GiziBbTbService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.getGiziIpTb();
  }

  public getGiziIpTb() {
    this._giziBbTbService
      .getGiziBbTb(this.dataAnakId)
      .subscribe((gizi) => (this.resultGiziBbTb = gizi));
  }
}
