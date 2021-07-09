import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-kesehatan-tab',
  templateUrl: './kesehatan-tab.component.html',
  styleUrls: ['./kesehatan-tab.component.css'],
})
export class KesehatanTabComponent {
  public dataAnakId: number = parseInt(this.route.snapshot.paramMap.get('id'));
  constructor(private dialog: MatDialog, private route: ActivatedRoute) {}
}
