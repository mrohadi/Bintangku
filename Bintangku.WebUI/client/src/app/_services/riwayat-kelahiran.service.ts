import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RiwayatKelahiran } from '../_models/riwayatKelahiran';

@Injectable({
  providedIn: 'root',
})
export class RiwayatKelahiranService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   * getRiwayatKelahiran
dataAnakId:number   */
  public getRiwayatKelahiran(dataAnakId: number): Observable<RiwayatKelahiran> {
    return this.http.get<RiwayatKelahiran>(
      this.baseUrl + 'riwayatkelahiran/' + dataAnakId
    );
  }
}
