import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PemeriksaanKesehatanEmosionalMchatService } from 'src/app/_services/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-emosional-mchat.service';

@Component({
  selector: 'app-mchat-input',
  templateUrl: './mchat-input.component.html',
  styleUrls: ['./mchat-input.component.css'],
})
export class MchatInputComponent implements OnInit {
  private dataAnakId: number = this.data.dataAnakId;
  public value = { yes: true, no: false };

  formMchat = this.formBuilder.group({
    question1: Boolean,
    question2: Boolean,
    question3: Boolean,
    question4: Boolean,
    question5: Boolean,
    question6: Boolean,
    question7: Boolean,
    question8: Boolean,
    question9: Boolean,
    question10: Boolean,
    question11: Boolean,
    question12: Boolean,
    question13: Boolean,
    question14: Boolean,
    question15: Boolean,
    question16: Boolean,
    question17: Boolean,
    question18: Boolean,
    question19: Boolean,
    question20: Boolean,
    question21: Boolean,
    question22: Boolean,
    question23: Boolean,
  });

  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private _mchatService: PemeriksaanKesehatanEmosionalMchatService
  ) {}

  ngOnInit(): void {}

  /**
   * postMchat
   */
  public postMchat(): void {
    this._mchatService
      .postPemeriksaanMchat(this.dataAnakId, this.formMchat.value)
      .subscribe(
        () => {
          this.dialog.closeAll();
          this.toastr.success('Data M-CHAT Added Successfully!');
        },
        (error) => {
          this.toastr.error(error);
        }
      );
  }
}
