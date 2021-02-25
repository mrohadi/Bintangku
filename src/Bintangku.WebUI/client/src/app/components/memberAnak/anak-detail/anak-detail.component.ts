import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
    private memberAnakService: MemberAnakService,
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
}
