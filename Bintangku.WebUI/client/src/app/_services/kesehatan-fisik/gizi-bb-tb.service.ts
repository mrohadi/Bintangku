import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GiziBbTb } from 'src/app/_models/kesehatan-fisik/gizi-bb-tb';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GiziBbTbService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   * getGiziImtU
   */
  public getGiziBbTb(dataAnakId: number): Observable<GiziBbTb[]> {
    return this.http.get<GiziBbTb[]>(
      this.baseUrl + 'pemeriksaanstatusgizibbtb/' + dataAnakId
    );
  }

  /**
   * postGiziIpTb
   */
  public postGiziBbTb(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaanstatusgizibbtb/' + dataAnakId,
      model
    );
  }
}
