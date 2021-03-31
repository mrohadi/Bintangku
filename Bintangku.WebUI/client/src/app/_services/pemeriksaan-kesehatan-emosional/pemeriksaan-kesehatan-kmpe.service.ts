import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PemeriksaanKesehatanKmpe } from 'src/app/_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-kmpe';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PemeriksaanKesehatanKmpeService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   * getPemeriksaanKmpe
   */
  public getPemeriksaanKmpe(
    dataAnakId: number
  ): Observable<PemeriksaanKesehatanKmpe[]> {
    return this.http.get<PemeriksaanKesehatanKmpe[]>(
      this.baseUrl + 'pemeriksaankmpe/' + dataAnakId
    );
  }

  /**
   * postPemeriksaanKmpe
   */
  public postPemeriksaanKmpe(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaankmpe/' + dataAnakId,
      model
    );
  }
}
