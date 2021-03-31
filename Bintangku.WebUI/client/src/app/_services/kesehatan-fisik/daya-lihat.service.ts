import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DayaLihat } from 'src/app/_models/kesehatan-fisik/data-lihat';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DayaLihatService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   * getDayaLihat
   */
  public getDayaLihat(dataAnakId: number): Observable<DayaLihat[]> {
    return this.http.get<DayaLihat[]>(
      this.baseUrl + 'pemeriksaandayalihat/' + dataAnakId
    );
  }

  /**
   * postDayaLihat
   */
  public postDayaLihat(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaandayalihat/' + dataAnakId,
      model
    );
  }
}
