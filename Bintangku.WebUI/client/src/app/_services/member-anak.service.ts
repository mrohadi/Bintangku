import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MemberAnak } from '../_models/memberAnak';

@Injectable({
  providedIn: 'root',
})
export class MemberAnakService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addMemberAnak(PostDataAnak: any) {
    return this.http.post(this.baseUrl + 'dataanak', PostDataAnak);
  }

  getMemberAnaks(): Observable<MemberAnak[]> {
    return this.http.get<MemberAnak[]>(this.baseUrl + 'dataanak');
  }

  getMemberAnak(id: number): Observable<MemberAnak> {
    return this.http.get<MemberAnak>(this.baseUrl + 'dataanak/' + id);
  }

  updateMemberAnak(id: number, model: any) {
    return this.http.put(this.baseUrl + 'dataanak/' + id, model);
  }

  deleteMemberAnak(id: number) {
    return this.http.delete(this.baseUrl + 'dataanak/' + id);
  }

  public createImgPath = (serverPath: string) => {
    return `https://localhost:5001/${serverPath}`;
  };
}
