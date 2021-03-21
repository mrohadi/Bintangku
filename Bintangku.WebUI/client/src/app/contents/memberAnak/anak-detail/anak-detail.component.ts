import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MemberAnak } from 'src/app/_models/memberAnak';
import { MemberAnakService } from 'src/app/_services/member-anak.service';

@Component({
  selector: 'app-anak-detail',
  templateUrl: './anak-detail.component.html',
  styleUrls: ['./anak-detail.component.css'],
})
export class AnakDetailComponent implements OnInit {
  memberAnak: MemberAnak;

  constructor(
    public memberAnakService: MemberAnakService,
    private _toastr: ToastrService,
    private location: Location,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadMemberAnak();
  }

  loadMemberAnak() {
    this.memberAnakService
      .getMemberAnak(parseInt(this.route.snapshot.paramMap.get('id')))
      .subscribe((memberAnak) => (this.memberAnak = memberAnak));
  }

  delete(): any {
    this.memberAnakService
      .deleteMemberAnak(parseInt(this.route.snapshot.paramMap.get('id')))
      .subscribe(() => {
        this._toastr.success('Data Anak Deleted Successfully');
        this.location.back();
      });
  }

  public executeSelectedChange = (event) => {
    console.log(event);
  };
}
