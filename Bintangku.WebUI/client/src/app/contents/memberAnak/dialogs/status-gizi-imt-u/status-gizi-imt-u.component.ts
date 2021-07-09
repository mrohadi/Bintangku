import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PemeriksaanKesehatanService } from 'src/app/_services/pemeriksaan-kesehatan.service';

@Component({
  selector: 'app-status-gizi-imt-u',
  templateUrl: './status-gizi-imt-u.component.html',
  styleUrls: ['./status-gizi-imt-u.component.scss'],
})
export class StatusGiziImtUComponent {
  formStatusGiziImtU = this.fb.group({
    beratBadan: Number,
    tinggiBadan: Number,
    umur: Number,
    zCode: Number,
  });

  constructor(
    private _toastr: ToastrService,
    private fb: FormBuilder,
    private _pemeriksaanService: PemeriksaanKesehatanService,
    public dialogRef: MatDialogRef<StatusGiziImtUComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any
  ) {}

  /**
   *
   * @param form
   */
  postStatusGiziImtU(form: FormGroup) {
    this._pemeriksaanService
      .postGiziImtU(this.data.id, form.value)
      .subscribe(() => {
        this.dialogRef.close('update');
        this._toastr.success(
          'Berhasil Menambahkan Pemeriksaan Status Gizi IMT/U'
        );
      });
  }
}
