import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ErrorsService } from '../_services/errors.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  constructor(public errorsService: ErrorsService) { }

  ngOnInit(): void {
    const isError = (window.location.pathname === '/server-error');
    this.errorsService.changeStatus(isError);
  }

}
