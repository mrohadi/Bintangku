import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-gpph',
  templateUrl: './gpph.component.html',
  styleUrls: ['./gpph.component.css'],
})
export class GpphComponent implements OnInit {
  public value = { satu: 0, dua: 1, tiga: 2, empat: 3 };
  public total: number;

  formGpph = this.formBuilder.group({
    value1: Number,
    value2: Number,
    value3: Number,
    value4: Number,
    value5: Number,
    value6: Number,
    value7: Number,
    value8: Number,
    value9: Number,
    value10: Number,
  });

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {}

  result() {}

  submit() {
    var result =
      parseInt(this.formGpph.value.value1) +
      parseInt(this.formGpph.value.value2) +
      parseInt(this.formGpph.value.value3) +
      parseInt(this.formGpph.value.value4) +
      parseInt(this.formGpph.value.value5) +
      parseInt(this.formGpph.value.value6) +
      parseInt(this.formGpph.value.value7) +
      parseInt(this.formGpph.value.value8) +
      parseInt(this.formGpph.value.value9) +
      parseInt(this.formGpph.value.value10);
    console.log(result);
  }
}
