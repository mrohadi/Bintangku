import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberAnak } from 'src/app/_models/memberAnak';
import { MemberAnakService } from 'src/app/_services/member-anak.service';

@Component({
  selector: 'app-anak',
  templateUrl: './anak.component.html',
  styleUrls: ['./anak.component.css'],
})
export class AnakComponent implements OnInit {
  memberAnaks: MemberAnak[];

  constructor(private memberAnakService: MemberAnakService) {}

  ngOnInit(): void {
    this.loadMemberAnaks();
  }

  loadMemberAnaks() {
    this.memberAnakService
      .getMemberAnaks()
      .subscribe((memberAnaks) => (this.memberAnaks = memberAnaks));
  }
}
