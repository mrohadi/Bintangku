import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GiziImtU } from 'src/app/_models/kesehatan-fisik/gizi-imt-u';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GiziImtUService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   * getGiziImtU
   */
  public getGiziImtU(dataAnakId: number): Observable<GiziImtU[]> {
    return this.http.get<GiziImtU[]>(
      this.baseUrl + 'pemeriksaanstatusgiziimtu/' + dataAnakId
    );
  }

  /**
   * postGiziIpTb
   */
  public postGiziImtU(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaanstatusgiziimtu/' + dataAnakId,
      model
    );
  }
}
