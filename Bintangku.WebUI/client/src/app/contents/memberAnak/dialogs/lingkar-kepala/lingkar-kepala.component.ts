import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-lingkar-kepala',
  templateUrl: './lingkar-kepala.component.html',
  styleUrls: ['./lingkar-kepala.component.css']
})
export class LingkarKepalaComponent {
  formLinkar: FormGroup;

  constructor(private fb: FormBuilder,public dialogRef: MatDialogRef<LingkarKepalaComponent>) {

    this.formLinkar = fb.group({
      head_circum:['', [Validators.required, Validators.pattern('^[1-9]')]],
      curva: ['',[Validators.required, Validators.pattern('^[1-9]')]]
    })
  }
}
