import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MemberAnak } from 'src/app/_models/memberAnak';
import { MemberAnakService } from 'src/app/_services/member-anak.service';

@Component({
  selector: 'app-anak',
  templateUrl: './anak.component.html',
  styleUrls: ['./anak.component.scss'],
})
export class AnakComponent implements OnInit {
  memberAnaks: MemberAnak[];
  panelOpenState = false;
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  anakColumns: string[] = [
    'nama',
    'nik',
    'kelamin',
    'ttl',
    'nama_ayah',
    'nama_ibu',
    'pengimput',
    'aksi',
  ];
  selected = '1';
  constructor(
    public memberAnakService: MemberAnakService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadMemberAnaks();
  }

  loadMemberAnaks() {
    this.memberAnakService
      .getMemberAnaks()
      .subscribe((memberAnaks) => (this.memberAnaks = memberAnaks));
  }

  clickRow(row: MemberAnak) {
    this.router.navigate(['anak-members', row.id]);
  }
}
