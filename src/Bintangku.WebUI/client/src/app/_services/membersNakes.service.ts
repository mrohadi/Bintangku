import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { MemberNakes } from "../_models/memberNakes";

@Injectable({
  providedIn: "root",
})
export class MembersNakesService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getMembersNakes(): Observable<MemberNakes[]> {
    return this.http.get<MemberNakes[]>(this.baseUrl + "nakesusers");
  }

  getMemberNakes(username: string): Observable<MemberNakes> {
    return this.http.get<MemberNakes>(this.baseUrl + "nakesusers/" + username);
  }
}
