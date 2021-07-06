import { Component, OnInit } from '@angular/core';

interface Items {
  title: string;
  desc: string;
  imgPath: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  registerMode = false;
  items: Items[] = [
    {
      title: 'Riwayat kesehatan digital',
      desc: 'Kemudahan dalam pencatatan riwayat kesehatan, tumbuh kembang, nutrisi, dan imunisasi setiap anak',
      imgPath: '',
    },
    {
      title: 'Pengingat imunisasi',
      desc: 'Otomatisasi pengiriman pesan singkat ke setiap orang tua sebagai pengingat jadwal imunisasi',
      imgPath: '',
    },
    {
      title: 'Konsultasi dengan Ahli',
      desc: 'Konsultasi masalah kesehatan dan pertumbuhan anak dengan ahli',
      imgPath: '',
    },
    {
      title: 'Edukasi dan Komunitas',
      desc: 'Konsultasi masalah kesehatan dan pertumbuhan anak dengan ahli',
      imgPath: '',
    },
  ];

  constructor() {}

  ngOnInit(): void {}

  registerToggle() {
    this.registerMode = !this.registerMode;
  }
}
