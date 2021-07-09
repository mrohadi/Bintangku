import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { GiziBbTbService } from 'src/app/_services/kesehatan-fisik/gizi-bb-tb.service';

@Component({
  selector: 'app-status-gizi-bb-tb',
  templateUrl: './status-gizi-bb-tb.component.html',
  styleUrls: ['./status-gizi-bb-tb.component.scss'],
})
export class StatusGiziBbTbComponent {
  formStatusGiziBbTb = this.fb.group({
    beratBadan: Number,
    tinggiBadan: Number,
    zCode: Number,
  });

  constructor(
    private _toastr: ToastrService,
    private fb: FormBuilder,
    private _pemeriksaanService: GiziBbTbService,
    public dialogRef: MatDialogRef<StatusGiziBbTbComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any
  ) {}

  /**
   *
   * @param form
   */
  postStatusGiziBbTb(form: FormGroup) {
    this._pemeriksaanService
      .postGiziBbTb(this.data.id, form.value)
      .subscribe(() => {
        this.dialogRef.close('update');
        this._toastr.success(
          'Berhasil Menambahkan Pemeriksaan Status Gizi BB/TB'
        );
      });
  }
}
