import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { GiziImtUService } from 'src/app/_services/kesehatan-fisik/gizi-imt-u.service';

@Component({
  selector: 'app-gizi-imt-u',
  templateUrl: './gizi-imt-u.component.html',
  styleUrls: ['./gizi-imt-u.component.css'],
})
export class GiziImtUComponent implements OnInit {
  private dataAnakId: number = this.data.dataAnakId;

  formGiziImtU = this.formBuilder.group({
    beratBadan: Number,
    tinggiBadan: Number,
    umur: Number,
    zCode: Number,
  });

  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private _giziImtUService: GiziImtUService
  ) {}

  ngOnInit(): void {}

  /**
   * postGiziImtU
   */
  public postGiziImtU() {
    this._giziImtUService
      .postGiziImtU(this.dataAnakId, this.formGiziImtU.value)
      .subscribe(
        () => {
          this.dialog.closeAll();
          this.toastr.success('Data Gizi IMT/U Added Successfully!');
        },
        (error) => {
          this.toastr.error(error);
        }
      );
  }
}
