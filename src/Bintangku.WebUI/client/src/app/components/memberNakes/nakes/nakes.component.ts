import { Component, OnInit } from '@angular/core';
import { MemberNakes } from 'src/app/_models/memberNakes';
import { MembersNakesService } from 'src/app/_services/membersNakes.service';

@Component({
  selector: 'app-nakes',
  templateUrl: './nakes.component.html',
  styleUrls: ['./nakes.component.css'],
})
export class NakesComponent implements OnInit {
  memberNakes: MemberNakes[];

  constructor(private memberNakesServices: MembersNakesService) {}

  ngOnInit(): void {
    this.loadMembersNakes();
  }

  loadMembersNakes() {
    this.memberNakesServices.getMembersNakes().subscribe((membersNakes) => {
      this.memberNakes = membersNakes;
    });
  }
}
