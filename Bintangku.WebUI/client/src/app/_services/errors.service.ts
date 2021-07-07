import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({providedIn: 'root'})
export class ErrorsService {
  isError$ = new BehaviorSubject(false);
  constructor() {}
  changeStatus(condition: boolean){
    this.isError$.next(!condition)
  }
}
