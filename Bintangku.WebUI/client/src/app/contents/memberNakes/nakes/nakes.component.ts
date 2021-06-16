import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MemberNakes } from 'src/app/_models/memberNakes';
import { MembersNakesService } from 'src/app/_services/membersNakes.service';

@Component({
  selector: 'app-nakes',
  templateUrl: './nakes.component.html',
  styleUrls: ['./nakes.component.scss'],
})
export class NakesComponent implements OnInit {
  memberNakes: MemberNakes[];
  selected = 'option1';
  loading = false;

  constructor(private memberNakesServices: MembersNakesService) {}

  ngOnInit(): void {
    this.loadMembersNakes();
  }

  loadMembersNakes() {
    this.loading = true;
    this.memberNakesServices.getMembersNakes().subscribe(
      (membersNakes) => {
        this.memberNakes = membersNakes;
      },
      () => {
        this.loading = false;
      },
      () => {
        this.loading = false;
        console.log(this.memberNakes);
      }
    );
  }
}
