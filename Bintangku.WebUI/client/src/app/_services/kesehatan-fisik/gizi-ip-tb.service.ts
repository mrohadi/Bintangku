import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GiziIpTb } from 'src/app/_models/kesehatan-fisik/gizi-ip-tb';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GiziIpTbService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   * getGiziIpTb
   */
  public getGiziIpTb(dataAnakId: number): Observable<GiziIpTb[]> {
    return this.http.get<GiziIpTb[]>(
      this.baseUrl + 'PemeriksaanStatusGiziIpTb/' + dataAnakId
    );
  }

  /**
   * postGiziIpTb
   */
  public postGiziIpTb(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'PemeriksaanStatusGiziIpTb/' + dataAnakId,
      model
    );
  }
}
