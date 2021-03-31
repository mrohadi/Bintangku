import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RiwayatOrangTua } from '../_models/riwayatOrangTua';

@Injectable({
  providedIn: 'root',
})
export class RiwayatOrangTuaService {
  private baseUrl: string = environment.apiUrl;
  private riwayatOrangTua: RiwayatOrangTua;

  constructor(private http: HttpClient) {}

  /**
   * getRiwayatOrangTua
   */
  public getRiwayatOrangTua(dataAnakId): Observable<RiwayatOrangTua> {
    return this.http.get<RiwayatOrangTua>(
      this.baseUrl + 'riwayatorangtua/' + dataAnakId
    );
  }
}
