import { Component} from '@angular/core';
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
export class HomeComponent {
  registerMode = false;
  items: Items[] = [
    {
      title: 'Riwayat Kesehatan Digital',
      desc: 'Kemudahan dalam pencatatan riwayat kesehatan, tumbuh kembang, nutrisi, dan imunisasi setiap anak',
      imgPath: '',
    },
    {
      title: 'Pengingat Imunisasi',
      desc: 'Otomatisasi pengiriman pesan singkat ke setiap orang tua sebagai pengingat jadwal imunisasi',
      imgPath: '',
    },
    {
      title: 'Konsultasi Dengan Ahli',
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

  registerToggle() {
    this.registerMode = !this.registerMode;
  }
}
