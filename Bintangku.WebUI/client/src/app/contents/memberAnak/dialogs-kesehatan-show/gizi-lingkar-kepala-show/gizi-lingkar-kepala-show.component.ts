import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LingkarKepala } from 'src/app/_models/kesehatan-fisik/lingkar-kepala';
import { LingkatKepalaService } from 'src/app/_services/kesehatan-fisik/lingkat-kepala.service';

@Component({
  selector: 'app-gizi-lingkar-kepala-show',
  templateUrl: './gizi-lingkar-kepala-show.component.html',
  styleUrls: ['./gizi-lingkar-kepala-show.component.css'],
})
export class GiziLingkarKepalaShowComponent implements OnInit {
  public dataAnakId: number = this.data.dataAnakId;
  public resultLingkarKepala: LingkarKepala[];

  constructor(
    private _lingkarKepalaService: LingkatKepalaService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.getGiziIpTb();
  }

  public getGiziIpTb() {
    this._lingkarKepalaService
      .getLingkarKepala(this.dataAnakId)
      .subscribe((gizi) => (this.resultLingkarKepala = gizi));
  }
}
