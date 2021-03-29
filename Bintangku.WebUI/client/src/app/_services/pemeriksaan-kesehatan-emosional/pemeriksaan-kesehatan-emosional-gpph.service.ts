import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PemeriksaanKesehatanGpph } from 'src/app/_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-gpph';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PemeriksaanKesehatanEmosionalGpphService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   * getPemeriksaanGpph
   */
  public getPemeriksaanGpph(
    dataAnakId: number
  ): Observable<PemeriksaanKesehatanGpph[]> {
    return this.http.get<PemeriksaanKesehatanGpph[]>(
      this.baseUrl + 'pemeriksaangpph/' + dataAnakId
    );
  }

  /**
   * postPemeriksaanGpph
   */
  public postPemeriksaanGpph(dataAnakId: number, model: any) {
    this.http.post(this.baseUrl + 'pemeriksaangpph/' + dataAnakId, model);
  }
}
