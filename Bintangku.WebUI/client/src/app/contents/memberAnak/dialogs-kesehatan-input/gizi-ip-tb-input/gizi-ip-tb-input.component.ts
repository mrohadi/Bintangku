import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { GiziIpTbService } from 'src/app/_services/kesehatan-fisik/gizi-ip-tb.service';

@Component({
  selector: 'app-gizi-ip-tb-input',
  templateUrl: './gizi-ip-tb-input.component.html',
  styleUrls: ['./gizi-ip-tb-input.component.css'],
})
export class GiziIpTbInputComponent implements OnInit {
  private dataAnakId: number = this.data.dataAnakId;

  formGiziIpTb = this.formBuilder.group({
    tinggiBadan: Number,
    indeksPanjang: Number,
    zCode: Number,
  });

  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private _giziIpTbService: GiziIpTbService
  ) {}

  ngOnInit(): void {}

  /**
   * postDayaLihat
   */
  public postDayaLihat() {
    this._giziIpTbService
      .postGiziIpTb(this.dataAnakId, this.formGiziIpTb.value)
      .subscribe(
        () => {
          this.dialog.closeAll();
          this.toastr.success('Data Gizi IP/TB Added Successfully!');
        },
        (error) => {
          this.toastr.error(error);
        }
      );
  }
}
