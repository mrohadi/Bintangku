import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { MemberAnak } from 'src/app/_models/memberAnak';
import { MemberAnakService } from 'src/app/_services/member-anak.service';

@Component({
  selector: 'app-anak-edit',
  templateUrl: './anak-edit.component.html',
  styleUrls: ['./anak-edit.component.css'],
})
export class AnakEditComponent implements OnInit {
  formGroup: FormGroup;
  dataAnak: Observable<MemberAnak>;
  id = parseInt(this.route.snapshot.paramMap.get('id'));

  constructor(
    private _memberAnakService: MemberAnakService,
    private _toastr: ToastrService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    //
    this.formGroup = this.formBuilder.group({
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

    this.dataAnak = this._memberAnakService
      .getMemberAnak(this.id)
      .pipe(tap((anak) => this.formGroup.patchValue(anak)));
  }

  submit() {
    if (this.formGroup.valid) {
      console.log(this.formGroup.value);
    }
  }

  editDataAnak(): void {
    this._memberAnakService
      .updateMemberAnak(this.id, this.formGroup.value)
      .subscribe(
        () => {
          this._toastr.success('Data Anak Updated Succesfully');
          this.location.back();
        },
        (error) => {
          this._toastr.error(error);
        }
      );
  }

  cancel() {
    this.location.back();
  }
}
