import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MemberAnak } from 'src/app/_models/memberAnak';
import { PemeriksaanKesehatanGpph } from 'src/app/_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-gpph';
import { MemberAnakService } from 'src/app/_services/member-anak.service';
import { PemeriksaanKesehatanEmosionalGpphService } from 'src/app/_services/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-emosional-gpph.service';

@Component({
  selector: 'app-anak-detail',
  templateUrl: './anak-detail.component.html',
  styleUrls: ['./anak-detail.component.css'],
})
export class AnakDetailComponent implements OnInit {
  public dataAnakId: number = parseInt(this.route.snapshot.paramMap.get('id'));
  public memberAnak: MemberAnak;
  public pemeriksaanGpph: PemeriksaanKesehatanGpph[];

  constructor(
    public memberAnakService: MemberAnakService,
    private gpphService: PemeriksaanKesehatanEmosionalGpphService,
    private _toastr: ToastrService,
    private location: Location,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadMemberAnak();
    this.loadPemeriksaanGpph();
  }

  public loadMemberAnak() {
    this.memberAnakService
      .getMemberAnak(this.dataAnakId)
      .subscribe((memberAnak) => (this.memberAnak = memberAnak));
  }

  /**
   * loadPemeriksaanGpph
   */
  public loadPemeriksaanGpph() {
    this.gpphService
      .getPemeriksaanGpph(this.dataAnakId)
      .subscribe((gpph) => (this.pemeriksaanGpph = gpph));
  }

  public delete(): any {
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
