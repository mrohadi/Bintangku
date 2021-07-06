import { Component, OnInit } from '@angular/core';
import { PRIMARY_OUTLET, Router, UrlSegment, UrlSegmentGroup, UrlTree } from '@angular/router';
import { RiwayatKelahiran } from 'src/app/_models/riwayatKelahiran';
import { RiwayatKelahiranService } from 'src/app/_services/riwayat-kelahiran.service';

@Component({
  selector: 'app-riwayat-kelahiran-tab',
  templateUrl: './riwayat-kelahiran-tab.component.html',
  styleUrls: ['./riwayat-kelahiran-tab.component.css'],
})
export class RiwayatKelahiranTabComponent implements OnInit {
  riwayatKelahiran: RiwayatKelahiran;
  tableRow = ["beratBadan", "panjangLahir", "apgarScore", "kelahiranDibantuOleh", "lainLain"];
  objRow = {
    beratBadan: "Berat Badan",
    panjangLahir: "Panjang Lahir",
    apgarScore: "Apgar Score",
    kelahiranDibantuOleh: "Dibantu Oleh",
    lainLain: "Lain-lain"
  }

  constructor(
    private _kelahiranService: RiwayatKelahiranService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    const s: UrlSegment[] = g.segments;
    this.getRiwayatKelahiran(+s[1].path);
  }

  /**
   * getRiwayatKelahiran
   */
getRiwayatKelahiran(id:number) {
    this._kelahiranService
      .getRiwayatKelahiran(id)
      .subscribe((result) => (this.riwayatKelahiran = result));
  }
}
