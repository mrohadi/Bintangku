import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import * as EventEmitter from 'events';
import { ToastrService } from 'ngx-toastr';
import { MemberAnakService } from 'src/app/_services/member-anak.service';

@Component({
  selector: 'app-anak-add',
  templateUrl: './anak-add.component.html',
  styleUrls: ['./anak-add.component.css'],
})
export class AnakAddComponent implements OnInit {
  jenisKelamins = ['None', 'Laki-Laki', 'Perempuan'];
  pekerjaan = [
    'None',
    'Petani',
    'Nelayan',
    'Pedagang',
    'Karyawan',
    'Guru',
    'PNS',
    'Wirwaswasta',
  ];
  PostDataAnak = this.formBuilder.group({
    namaLengkap: ''.toUpperCase(),
    nik: Number,
    jenisKelaminAnak: '',
    tanggalLahirAnak: '',
    alamat: '',
    kontak: '',
    jumlahSaudara: Number,
    photoAnakUrl: '',
    beratBadan: Number,
    panjangLahir: Number,
    apgarScore: Number,
    kelahiranDibantuOleh: '',
    lainLain: '',
    namaAyah: '',
    tanggalLahirAyah: '',
    pekerjaanAyah: '',
    namaIbu: '',
    tanggalLahirIbu: '',
    pekerjaanIbu: '',
    penghasilanOrangTua: Number,
    anggotaRumahTangga: Number,
    tandaTanganOrangTua: '',
  });
  cancel = new EventEmitter();

  constructor(
    private formBuilder: FormBuilder,
    private memberAnakService: MemberAnakService,
    private route: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  addDataAnak(): void {
    // this.memberAnakService.addMemberAnak(this.addAnakForm.value).subscribe(
    //   () => {
    //     this.toastr.success('Data Anak Added Successfully');
    //     this.route.navigateByUrl('/anak-members');
    //   },
    //   (error) => console.log(error)
    // );
    console.log(this.PostDataAnak);
  }

  cancelAddAnak() {
    this.route.navigateByUrl('/anak-members');
  }
}
