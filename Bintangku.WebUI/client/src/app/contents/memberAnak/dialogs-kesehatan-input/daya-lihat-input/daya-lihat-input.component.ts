import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { DayaLihatService } from 'src/app/_services/kesehatan-fisik/daya-lihat.service';

@Component({
  selector: 'app-daya-lihat-input',
  templateUrl: './daya-lihat-input.component.html',
  styleUrls: ['./daya-lihat-input.component.css'],
})
export class DayaLihatInputComponent implements OnInit {
  private dataAnakId: number = this.data.dataAnakId;
  public value = { satu: 0, dua: 1, tiga: 2, empat: 3 };

  formDayaLihat = this.formBuilder.group({
    mataKanan: Number,
    mataKiri: Number,
  });

  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private _dayaLihatService: DayaLihatService
  ) {}

  ngOnInit(): void {}

  /**
   * postDayaLihat
   */
  public postDayaLihat() {
    this._dayaLihatService
      .postDayaLihat(this.dataAnakId, this.formDayaLihat.value)
      .subscribe(
        () => {
          this.dialog.closeAll();
          this.toastr.success('Data Daya Lihat Added Successfully!');
        },
        (error) => {
          this.toastr.error(error);
        }
      );
  }
}
