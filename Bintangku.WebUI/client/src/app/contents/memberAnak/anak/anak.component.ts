import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { MemberAnak } from 'src/app/_models/memberAnak';
import { MemberAnakService } from 'src/app/_services/member-anak.service';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];



@Component({
  selector: 'app-anak',
  templateUrl: './anak.component.html',
  styleUrls: ['./anak.component.scss'],
  // encapsulation: ViewEncapsulation.None,
})
export class AnakComponent implements OnInit {
  memberAnaks: MemberAnak[];
  panelOpenState = false;
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;
  anakColumns: string[] = ['nama','nik', 'kelamin', 'ttl', 'nama_ayah', 'nama_ibu', 'pengimput', 'aksi']
  selected = '1';
  constructor(public memberAnakService: MemberAnakService,private router:Router) {}

  ngOnInit(): void {
    this.loadMemberAnaks();
  }

  loadMemberAnaks() {
    const today = new Date();
    this.memberAnaks = [
      {
        dataAnakId: 1234,
        namaLengkap: 'nama lengkap',
        nik: 123456789,
        jenisKelaminAnak: 'laki-laki',
        tanggalLahirAnak: today,
        alamat: 'jakarta',
        kontak: '0886576576',
        jumlahSaudara: 3,
        imagePath: '',
        namaNakes: 'veronica',
        nakesPhoto: [],
        riwayatOrangTua: null,
      },
      {
        dataAnakId: 1234,
        namaLengkap: 'nama lengkap',
        nik: 123456789,
        jenisKelaminAnak: 'laki-laki',
        tanggalLahirAnak: today,
        alamat: 'jakarta',
        kontak: '0886576576',
        jumlahSaudara: 3,
        imagePath: '',
        namaNakes: 'veronica',
        nakesPhoto: [],
        riwayatOrangTua: null,
      },
      {
        dataAnakId: 1234,
        namaLengkap: 'nama lengkap',
        nik: 123456789,
        jenisKelaminAnak: 'laki-laki',
        tanggalLahirAnak: today,
        alamat: 'jakarta',
        kontak: '0886576576',
        jumlahSaudara: 3,
        imagePath: '',
        namaNakes: 'veronica',
        nakesPhoto: [],
        riwayatOrangTua: null,
      },
    ];
    // this.memberAnakService
    //   .getMemberAnaks()
    //   .subscribe((memberAnaks) => (this.memberAnaks = memberAnaks));
  }
  clickRow(row:MemberAnak){
    this.router.navigate(['anak-members',row.dataAnakId]);
  }
}
