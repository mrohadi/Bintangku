import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RiwayatOrangTua } from 'src/app/_models/riwayatOrangTua';
import { RiwayatOrangTuaService } from 'src/app/_services/riwayat-orang-tua.service';

@Component({
  selector: 'app-riwayat-orang-tua-tab',
  templateUrl: './riwayat-orang-tua-tab.component.html',
  styleUrls: ['./riwayat-orang-tua-tab.component.css'],
})
export class RiwayatOrangTuaTabComponent implements OnInit {
  private dataAnakId: number = parseInt(this.route.snapshot.paramMap.get('id'));
  public riwayatOrangTua: RiwayatOrangTua;

  constructor(
    private route: ActivatedRoute,
    private _orangTuaService: RiwayatOrangTuaService
  ) {}

  ngOnInit(): void {
    // this.getRiwayatOrangTua();
    console.log('jalan')
  }

  private getRiwayatOrangTua() {
    this._orangTuaService
      .getRiwayatOrangTua(1)
      .subscribe((result) => (this.riwayatOrangTua = result));
  }
}
