import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PemeriksaanKesehatanKmpeService } from 'src/app/_services/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-kmpe.service';

@Component({
  selector: 'app-kmpe-input',
  templateUrl: './kmpe-input.component.html',
  styleUrls: ['./kmpe-input.component.css'],
})
export class KmpeInputComponent implements OnInit {
  private dataAnakId: number = this.data.dataAnakId;
  public value = { yes: true, no: false };

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
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private _kmpeService: PemeriksaanKesehatanKmpeService
  ) {}

  ngOnInit(): void {}

  /**
   * postMchat
   */
  public postKmpe(): void {
    this._kmpeService
      .postPemeriksaanKmpe(this.dataAnakId, this.formKmpe.value)
      .subscribe(
        () => {
          this.dialog.closeAll();
          this.toastr.success('Data KMPE Added Successfully!');
        },
        (error) => {
          this.toastr.error(error);
        }
      );
  }
}
