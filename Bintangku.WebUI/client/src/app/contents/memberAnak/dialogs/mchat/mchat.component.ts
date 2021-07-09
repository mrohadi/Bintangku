import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PemeriksaanKesehatanService } from 'src/app/_services/pemeriksaan-kesehatan.service';

@Component({
  selector: 'app-mchat',
  templateUrl: './mchat.component.html',
  styleUrls: ['./mchat.component.scss'],
})
export class MchatComponent {
  public value = { yes: true, no: false };
  public total: number;

  formMchat = this.formBuilder.group({
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
    question15: Boolean,
    question16: Boolean,
    question17: Boolean,
    question18: Boolean,
    question19: Boolean,
    question20: Boolean,
    question21: Boolean,
    question22: Boolean,
    question23: Boolean,
  });

  constructor(
    private formBuilder: FormBuilder,
    private _pemeriksaanService: PemeriksaanKesehatanService,
    public dialogRef: MatDialogRef<MchatComponent>,
    private _toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) private data: any
  ) {}

  /**
   *
   * @param form
   */
  submit(form: FormGroup) {
    this._pemeriksaanService
      .postPemeriksaanMchat(this.data.id, form.value)
      .subscribe(() => {
        this.dialogRef.close('update');
        this._toastr.success('Berhasil Menambahkan Pemeriksaan M-Chat');
      });
  }
}
