import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { GiziBbTbService } from 'src/app/_services/kesehatan-fisik/gizi-bb-tb.service';

@Component({
  selector: 'app-gizi-bb-tb-input',
  templateUrl: './gizi-bb-tb-input.component.html',
  styleUrls: ['./gizi-bb-tb-input.component.css'],
})
export class GiziBbTbInputComponent implements OnInit {
  private dataAnakId: number = this.data.dataAnakId;

  formGiziBbTb = this.formBuilder.group({
    beratBadan: Number,
    tinggiBadan: Number,
    zCode: Number,
  });

  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private _giziBbTbService: GiziBbTbService
  ) {}

  ngOnInit(): void {}

  /**
   * postDayaLihat
   */
  public postGiziBbTb() {
    this._giziBbTbService
      .postGiziBbTb(this.dataAnakId, this.formGiziBbTb.value)
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
