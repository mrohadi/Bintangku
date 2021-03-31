import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PemeriksaanKesehatanEmosionalGpphService } from 'src/app/_services/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-emosional-gpph.service';

@Component({
  selector: 'app-gpph-input',
  templateUrl: './gpph-input.component.html',
  styleUrls: ['./gpph-input.component.css'],
})
export class GpphInputComponent implements OnInit {
  private dataAnakId: number = this.data.dataAnakId;
  public value = { satu: 0, dua: 1, tiga: 2, empat: 3 };

  formGpph = this.formBuilder.group({
    question1: Number,
    question2: Number,
    question3: Number,
    question4: Number,
    question5: Number,
    question6: Number,
    question7: Number,
    question8: Number,
    question9: Number,
    question10: Number,
    question11: Number,
    question12: Number,
    question13: Number,
    question14: Number,
  });

  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private _kmpeService: PemeriksaanKesehatanEmosionalGpphService
  ) {}

  ngOnInit(): void {}

  /**
   * postMchat
   */
  public postGpph(): void {
    this._kmpeService
      .postPemeriksaanGpph(this.dataAnakId, this.formGpph.value)
      .subscribe(
        () => {
          this.dialog.closeAll();
          this.toastr.success('Data GPPH Added Successfully!');
        },
        (error) => {
          this.toastr.error(error);
        }
      );
  }
}
