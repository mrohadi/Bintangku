import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RiwayatKelahiran } from 'src/app/_models/riwayatKelahiran';
import { RiwayatKelahiranService } from 'src/app/_services/riwayat-kelahiran.service';

@Component({
  selector: 'app-riwayat-kelahiran-tab',
  templateUrl: './riwayat-kelahiran-tab.component.html',
  styleUrls: ['./riwayat-kelahiran-tab.component.css'],
})
export class RiwayatKelahiranTabComponent implements OnInit {
  public dataAnakId: number = parseInt(this.route.snapshot.paramMap.get('id'));
  public riwayatKelahiran: RiwayatKelahiran;

  constructor(
    private _kelahiranService: RiwayatKelahiranService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getRiwayatKelahiran();
  }

  /**
   * getRiwayatKelahiran
   */
  public getRiwayatKelahiran() {
    this._kelahiranService
      .getRiwayatKelahiran(this.dataAnakId)
      .subscribe((result) => (this.riwayatKelahiran = result));
  }
}
