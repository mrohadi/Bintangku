import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

export interface PeriodicElement {
  no: number;
  questioner: string;
  aksi: string;
  option: any;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    no: 1,
    questioner:
      'Pada waktu bayi terlentang, apakah masing-masing lengan dan tungkai bergerak dengan mudah? Jawaban TIDAK bila salah satu atau kedua tungkai atau lengan bayi bergerak tak terarah/tak terkendali',
    aksi: ' Gerak Kasar',
    option: 1,
  },
  {
    no: 2,
    questioner:
      'Pada waktu bayi terlentang apakah ia melihat dan menatap wajah anda?',
    aksi: 'Sosialisasi dan Kemandirian',
    option: 1,
  },
  {
    no: 3,
    questioner:
      'Apakah bayi dapat mengeluarkan suara-suara lain (ngoceh) selain menangis?',
    aksi: 'Bicara dan Bahasa',
    option: 1,
  },
  {
    no: 4,
    questioner:
      'Pada waktu anda mengajak bayi berbicara dan tersenyum, apakah ia tersenyum kembali kepada anda?',
    aksi: 'Sosialisasi dan Kemandirian',
    option: 'Be',
  },
  {
    no: 5,
    questioner:
      'Apakah bayi suka tertawa keras walau tidak digelitik atau diraba−raba?',
    aksi: 'Bicara dan Bahasa',
    option: 'B',
  },
  {
    no: 6,
    questioner:
      'Ambil wool merah, letakkan di atas wajah di depan mata, gerakkan wool dari samping kiri ke kanan kepala. Apakah ia dapat mengikuti gerakan anda dengan menggerakkan kepalanya dari kanan/kiri ke tengah?',
    aksi: 'Gerak Halus',
    option: 'C',
  },
  {
    no: 7,
    questioner:
      'Ambil wool merah, letakkan di atas wajah di depan mata, gerakkan wool dari samping kiri ke kanan kepala. Apakah ia dapat mengikuti gerakan anda dengan menggerakkan kepalanya dari satu sisi hampir sampai pada sisi yang lain?',
    aksi: 'Gerak Halus',
    option: 'N',
  },
  {
    no: 8,
    questioner:
      'Pada waktu bayi telungkup di alas yang datar, apakah ia dapat mengangkat kepalanya seperti pada gambar ini?',
    aksi: 'Gerak Kasar',
    option: 'O',
  },
  {
    no: 9,
    questioner:
      'Pada waktu bayi telungkup di alas yang datar, apakah ia dapat mengangkat kepalanya sehingga membentuk sudut 45 ̊ seperti pada gambar?',
    aksi: 'Gerak Kasar',
    option: 'F',
  },
  {
    no: 10,
    questioner:
      'Pada waktu bayi telungkup di alas yang datar, apakah ia dapat mengangkat kepalanya dengan tegak sddsperti pada gambar?',
    aksi: 'Gerak Kasar',
    option: 'Ne',
  },
];

@Component({
  selector: 'app-kpsp',
  templateUrl: './kpsp.component.html',
  styleUrls: ['./kpsp.component.css'],
})
export class KpspComponent {
  displayedColumns: string[] = ['no', 'questioner', 'aksi', 'option'];
  dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);

  constructor() {}
}
