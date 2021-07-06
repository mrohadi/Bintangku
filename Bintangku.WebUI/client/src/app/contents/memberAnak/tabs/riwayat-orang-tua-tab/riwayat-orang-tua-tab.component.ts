import { Component, OnInit } from '@angular/core';
import { PRIMARY_OUTLET, Router, UrlSegment, UrlSegmentGroup, UrlTree } from '@angular/router';
import { RiwayatOrangTua } from 'src/app/_models/riwayatOrangTua';
import { RiwayatOrangTuaService } from 'src/app/_services/riwayat-orang-tua.service';

@Component({
  selector: 'app-riwayat-orang-tua-tab',
  templateUrl: './riwayat-orang-tua-tab.component.html',
  styleUrls: ['./riwayat-orang-tua-tab.component.css'],
})
export class RiwayatOrangTuaTabComponent implements OnInit {
  riwayatOrangTua: RiwayatOrangTua;
  tableRow = ["namaAyah","tanggalLahirAyah","pekerjaanAyah","namaIbu","tanggalLahirIbu","pekerjaanIbu","penghasilanOrangTua","anggotaRumahTangga"];
  objRow = {
    namaAyah:'Nama Ayah',
    tanggalLahirAyah:'Tanggal Lahir Ayah',
    pekerjaanAyah:'Pekerjaan Ayah',
    namaIbu:'Nama Ibu',
    tanggalLahirIbu:'Tanggal Lahir Ibu',
    pekerjaanIbu:'pekerjaanIbu',
    penghasilanOrangTua:'Penghasilan Orang Tua',
    anggotaRumahTangga:'Anggota Rumah Tangga'
  }

  constructor(
    private _orangTuaService: RiwayatOrangTuaService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    // this.getRiwayatOrangTua();
    console.log('jalan')
    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    const s: UrlSegment[] = g.segments;
    this.getRiwayatOrangTua(+s[1].path);
  }

  private getRiwayatOrangTua(id:number) {
    this._orangTuaService
      .getRiwayatOrangTua(id)
      .subscribe((result) => (this.riwayatOrangTua = result));
  }
}
