import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import * as EventEmitter from 'events';
import { ToastrService } from 'ngx-toastr';
import { MemberAnakService } from 'src/app/_services/member-anak.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-anak-add',
  templateUrl: './anak-add.component.html',
  styleUrls: ['./anak-add.component.css'],
})
export class AnakAddComponent implements OnInit {
  baseUrl: string = environment.apiUrl;
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
  public responseImage: { url: '' };
  public responseTtd: { url: '' };

  PostDataAnak = this.formBuilder.group({
    namaLengkap: ''.toUpperCase(),
    nik: Number,
    jenisKelaminAnak: '',
    tanggalLahirAnak: '',
    alamat: '',
    kontak: '',
    jumlahSaudara: Number,
    imagePath: { url: '' },
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
    tandaTanganPath: { url: '' },
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
    this.PostDataAnak.patchValue({ imagePath: this.responseImage.url });
    this.PostDataAnak.patchValue({ tandaTanganPath: this.responseTtd.url });
    this.memberAnakService.addMemberAnak(this.PostDataAnak.value).subscribe(
      () => {
        this.toastr.success('Data Anak Added Successfully');
        this.route.navigateByUrl('/anak-members');
      },
      (error) => console.log(error)
    );
    console.log(this.PostDataAnak);
  }

  public uploadFinished = (event) => {
    this.responseImage = event;
  };

  public uploadTtdFinished = (event) => {
    this.responseTtd = event;
  };

  cancelAddAnak() {
    this.route.navigateByUrl('/anak-members');
  }
}
