import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PemeriksaanKesehatanService } from 'src/app/_services/pemeriksaan-kesehatan.service';

@Component({
  selector: 'app-kmpe',
  templateUrl: './kmpe.component.html',
  styleUrls: ['./kmpe.component.css'],
})
export class KmpeComponent {
  public value = { yes: true, no: false };
  public total: number;

  formKmpe = this.formBuilder.group({
    question1: Boolean,
    question2: Boolean,
    question3: Boolean,
    question4: Boolean,
    question5: Boolean,
    question6: Boolean,
    question7: Boolean,
    question8: Boolean,
    question9: Boolean,
    question10: Boolean,
    question11: Boolean,
    question12: Boolean,
    question13: Boolean,
    question14: Boolean,
  });

  constructor(
    private formBuilder: FormBuilder,
    private _pemeriksaanService: PemeriksaanKesehatanService,
    public dialogRef: MatDialogRef<KmpeComponent>,
    private _toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) private data: any
  ) {}

  /**
   *
   * @param form
   */
  submit(form: FormGroup) {
    this._pemeriksaanService
      .postPemeriksaanKmpe(this.data.id, form.value)
      .subscribe(() => {
        this.dialogRef.close('update');
        this._toastr.success('Berhasil Menambahkan Pemeriksaan KMPE');
      });
  }
}
