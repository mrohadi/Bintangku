import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LingkatKepalaService } from 'src/app/_services/kesehatan-fisik/lingkat-kepala.service';

@Component({
  selector: 'app-lingkar-kepala',
  templateUrl: './lingkar-kepala.component.html',
  styleUrls: ['./lingkar-kepala.component.css'],
})
export class LingkarKepalaComponent implements OnInit {
  formLinkar: FormGroup;
  public dataAnakId: number = parseInt(this.route.snapshot.paramMap.get('id'));

  formLingkarKepala = this.fb.group({
    lingkarKepala: Number,
    kurva: Number,
  });

  constructor(
    private route: ActivatedRoute,
    private _lingkarKepalaService: LingkatKepalaService,
    private _toastr: ToastrService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<LingkarKepalaComponent>
  ) {
    this.formLinkar = fb.group({
      head_circum: ['', [Validators.required, Validators.pattern('^[1-9]')]],
      curva: ['', [Validators.required, Validators.pattern('^[1-9]')]],
    });
  }

  ngOnInit(): void {
    this.dataAnakId = parseInt(this.route.snapshot.paramMap.get('id'));
    console.log(this.dataAnakId);
  }

  /**
   * Method to input Pemeriksaan Lingkar Kepala
   */
  public postLingkarKepala() {
    this._lingkarKepalaService
      .postLingkarKepala(this.dataAnakId, this.formLingkarKepala.value)
      .subscribe(
        () => {
          this.dialogRef.close();
          this._toastr.success('Data Lingkar Kepala Added Successfully!');
        },
        (err) => console.log(err)
      );
  }
}
