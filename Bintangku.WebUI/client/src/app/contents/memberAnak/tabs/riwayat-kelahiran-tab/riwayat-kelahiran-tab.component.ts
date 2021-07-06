import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, PRIMARY_OUTLET, Router, UrlSegment, UrlSegmentGroup, UrlTree } from '@angular/router';
import { RiwayatKelahiran } from 'src/app/_models/riwayatKelahiran';
import { RiwayatKelahiranService } from 'src/app/_services/riwayat-kelahiran.service';

@Component({
  selector: 'app-riwayat-kelahiran-tab',
  templateUrl: './riwayat-kelahiran-tab.component.html',
  styleUrls: ['./riwayat-kelahiran-tab.component.css'],
})
export class RiwayatKelahiranTabComponent implements OnInit {
riwayatKelahiran: RiwayatKelahiran;

  constructor(
    private _kelahiranService: RiwayatKelahiranService,
    private route: ActivatedRoute,
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
      .getRiwayatKelahiran(1)
      .subscribe((result) => (this.riwayatKelahiran = result));
  }
}
