import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountServices } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'Bintangku';
  nakesUsers: any;

  constructor(private accountServie: AccountServices) {}

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user') ?? '{}');
    this.accountServie.setCurrentUser(user);
  }
  onActivate(event) {
    window.scroll(0, 0);
  }
}
