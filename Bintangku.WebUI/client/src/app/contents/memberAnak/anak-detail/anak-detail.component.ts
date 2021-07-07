import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MemberAnak } from 'src/app/_models/memberAnak';
import { MemberAnakService } from 'src/app/_services/member-anak.service';

@Component({
  selector: 'app-anak-detail',
  templateUrl: './anak-detail.component.html',
  styleUrls: ['./anak-detail.component.scss'],
})
export class AnakDetailComponent {
  public memberAnak: MemberAnak;

  constructor(
    public memberAnakService: MemberAnakService,
    private _toastr: ToastrService,
    private location: Location,
    private route: ActivatedRoute
  ) {
    this.loadMemberAnak(+route.snapshot.paramMap.get('id'));
  }

  public loadMemberAnak(id: number) {
    this.memberAnakService.getMemberAnak(id).subscribe(
      (memberAnak) => (this.memberAnak = memberAnak),
      (err) => console.log(err),
      () => console.log(this.memberAnak)
  );
  }

  public delete(): any {
    this.memberAnakService
      .deleteMemberAnak(parseInt(this.route.snapshot.paramMap.get('id')))
      .subscribe(() => {
        this._toastr.success('Data Anak Deleted Successfully');
        this.location.back();
      });
  }
  ageCalculator(date:Date = new Date()){
    const convertAge = new Date(date);
    const timeDiff = Math.abs(Date.now() - convertAge.getTime());
    const tahun = Math.floor((timeDiff / (1000 * 3600 * 24))/365.25);
    const bulan = Math.floor((timeDiff / (1000 * 3600 * 24))/30.4375);
    return tahun > 0 ? `${tahun} tahun` : `${bulan} bulan`;
  }
}
