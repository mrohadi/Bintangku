import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DialogData } from 'src/app/contents/memberNakes/nakes-detail/nakes-detail.component';
import { LingkatKepalaService } from 'src/app/_services/kesehatan-fisik/lingkat-kepala.service';

@Component({
  selector: 'app-lingkar-kepala',
  templateUrl: './lingkar-kepala.component.html',
  styleUrls: ['./lingkar-kepala.component.css'],
})
export class LingkarKepalaComponent {
  formLinkar: FormGroup;

  formLingkarKepala = this.fb.group({
    lingkarKepala: Number,
    kurva: Number,
  });

  constructor(
    private route: ActivatedRoute,
    private _lingkarKepalaService: LingkatKepalaService,
    private _toastr: ToastrService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<LingkarKepalaComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any
  ) {
    this.formLinkar = fb.group({
      head_circum: ['', [Validators.required, Validators.pattern('^[1-9]')]],
      curva: ['', [Validators.required, Validators.pattern('^[1-9]')]],
    });
  }


  /**
   * Method to input Pemeriksaan Lingkar Kepala
   */
  public postLingkarKepala(form:FormGroup) {
    this._lingkarKepalaService
      .postLingkarKepala(this.data.id, form.value)
      .subscribe(
        () => {
          this.dialogRef.close('update');
          this._toastr.success('Data Lingkar Kepala Added Successfully!');
        },
        (err) => console.log(err)
      );
  }
}
