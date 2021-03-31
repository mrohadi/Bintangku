import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LingkarKepala } from 'src/app/_models/kesehatan-fisik/lingkar-kepala';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class LingkatKepalaService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   * getGiziIpTb
   */
  public getLingkarKepala(dataAnakId: number): Observable<LingkarKepala[]> {
    return this.http.get<LingkarKepala[]>(
      this.baseUrl + 'pemeriksaanlingkarkepala/' + dataAnakId
    );
  }

  /**
   * postGiziIpTb
   */
  public postLingkarKepala(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaanlingkarkepala/' + dataAnakId,
      model
    );
  }
}
