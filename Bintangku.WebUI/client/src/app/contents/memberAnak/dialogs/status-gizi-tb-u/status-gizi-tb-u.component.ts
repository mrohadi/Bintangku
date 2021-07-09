import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PemeriksaanKesehatanService } from 'src/app/_services/pemeriksaan-kesehatan.service';

@Component({
  selector: 'app-status-gizi-tb-u',
  templateUrl: './status-gizi-tb-u.component.html',
  styleUrls: ['./status-gizi-tb-u.component.scss'],
})
export class StatusGiziTbUComponent {
  formStatusGiziTbU = this.fb.group({
    tinggiBadan: Number,
    indeksPanjang: Number,
    zCode: Number,
  });

  constructor(
    private _toastr: ToastrService,
    private fb: FormBuilder,
    private _pemeriksaanService: PemeriksaanKesehatanService,
    public dialogRef: MatDialogRef<StatusGiziTbUComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any
  ) {}

  /**
   *
   * @param form
   */
  postStatusGiziTbU(form: FormGroup) {
    this._pemeriksaanService
      .postGiziIpTb(this.data.id, form.value)
      .subscribe(() => {
        this.dialogRef.close('update');
        this._toastr.success(
          'Berhasil Menambahkan Pemeriksaan Status Gizi TB/U'
        );
      });
  }
}
