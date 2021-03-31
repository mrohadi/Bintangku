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
  public dataAnakId: number = parseInt(this.route.snapshot.paramMap.get('id'));
  public memberAnak: MemberAnak;

  constructor(
    public memberAnakService: MemberAnakService,
    private _toastr: ToastrService,
    private location: Location,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadMemberAnak();
    console.log(this.dataAnakId);
  }

  public loadMemberAnak() {
    this.memberAnakService
      .getMemberAnak(this.dataAnakId)
      .subscribe((memberAnak) => (this.memberAnak = memberAnak));
  }

  public delete(): any {
    this.memberAnakService
      .deleteMemberAnak(parseInt(this.route.snapshot.paramMap.get('id')))
      .subscribe(() => {
        this._toastr.success('Data Anak Deleted Successfully');
        this.location.back();
      });
  }

  public executeSelectedChange = () => {};
}
