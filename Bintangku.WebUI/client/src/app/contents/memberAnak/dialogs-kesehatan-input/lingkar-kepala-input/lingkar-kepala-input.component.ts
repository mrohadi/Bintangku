import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { LingkatKepalaService } from 'src/app/_services/kesehatan-fisik/lingkat-kepala.service';

@Component({
  selector: 'app-lingkar-kepala-input',
  templateUrl: './lingkar-kepala-input.component.html',
  styleUrls: ['./lingkar-kepala-input.component.css'],
})
export class LingkarKepalaInputComponent implements OnInit {
  private dataAnakId: number = this.data.dataAnakId;

  formLingkarKepala = this.formBuilder.group({
    lingkarKepala: Number,
    kurva: Number,
  });

  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private _lingkarKepalaservice: LingkatKepalaService
  ) {}

  ngOnInit(): void {}

  /**
   * postGiziImtU
   */
  public postLingkarKepala() {
    this._lingkarKepalaservice
      .postLingkarKepala(this.dataAnakId, this.formLingkarKepala.value)
      .subscribe(
        () => {
          this.dialog.closeAll();
          this.toastr.success('Data Lingkar Kepala Added Successfully!');
        },
        (error) => {
          this.toastr.error(error);
        }
      );
  }
}
