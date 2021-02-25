import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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
  addAnakForm = this.formBuilder.group({
    namaLengkap: ''.toLowerCase(),
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
    this.memberAnakService.addMemberAnak(this.addAnakForm.value).subscribe(
      () => {
        this.toastr.success('Data Anak Berhasil Ditambahkan!');
        this.route.navigateByUrl('/anak-members');
      },
      (error) => console.log(error)
    );
    console.log(this.addAnakForm.value);
  }

  cancelAddAnak() {
    // this.cancel.emit();
  }
}
