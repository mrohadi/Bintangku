import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PemeriksaanKesehatanMchat } from 'src/app/_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-mchat';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PemeriksaanKesehatanEmosionalMchatService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   * getPemeriksaanMchat
   */
  public getPemeriksaanMchat(
    dataAnakId: number
  ): Observable<PemeriksaanKesehatanMchat[]> {
    return this.http.get<PemeriksaanKesehatanMchat[]>(
      this.baseUrl + 'pemeriksaanmchat/' + dataAnakId
    );
  }

  /**
   * postPemeriksaanMchat
   */
  public postPemeriksaanMchat(dataAnakId: number, model: any) {
    this.http.post(this.baseUrl + 'pemeriksaanmchat/' + dataAnakId, model);
  }
}
