import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DayaLihat } from '../_models/kesehatan-fisik/data-lihat';
import { GiziBbTb } from '../_models/kesehatan-fisik/gizi-bb-tb';
import { GiziImtU } from '../_models/kesehatan-fisik/gizi-imt-u';
import { GiziIpTb } from '../_models/kesehatan-fisik/gizi-ip-tb';
import { LingkarKepala } from '../_models/kesehatan-fisik/lingkar-kepala';
import { PemeriksaanKesehatanGpph } from '../_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-gpph';
import { PemeriksaanKesehatanKmpe } from '../_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-kmpe';
import { PemeriksaanKesehatanMchat } from '../_models/pemeriksaan-kesehatan-emosional/pemeriksaan-kesehatan-mchat';

@Injectable({
  providedIn: 'root',
})
export class PemeriksaanKesehatanService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /**
   *
   * @param dataAnakId
   * @returns
   */
  public getLingkarKepala(dataAnakId: number): Observable<LingkarKepala[]> {
    return this.http.get<LingkarKepala[]>(
      this.baseUrl + 'pemeriksaanlingkarkepala/' + dataAnakId
    );
  }

  /**
   *
   * @param dataAnakId
   * @param model
   * @returns
   */
  public postLingkarKepala(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaanlingkarkepala/' + dataAnakId,
      model
    );
  }

  /**
   *
   * @param dataAnakId
   * @returns
   */
  public getGiziBbTb(dataAnakId: number): Observable<GiziBbTb[]> {
    return this.http.get<GiziBbTb[]>(
      this.baseUrl + 'pemeriksaanstatusgizibbtb/' + dataAnakId
    );
  }

  /**
   *
   * @param dataAnakId
   * @param model
   * @returns
   */
  public postGiziBbTb(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaanstatusgizibbtb/' + dataAnakId,
      model
    );
  }

  /**
   *
   * @param dataAnakId
   * @returns
   */
  public getGiziImtU(dataAnakId: number): Observable<GiziImtU[]> {
    return this.http.get<GiziImtU[]>(
      this.baseUrl + 'pemeriksaanstatusgiziimtu/' + dataAnakId
    );
  }

  /**
   *
   * @param dataAnakId
   * @param model
   * @returns
   */
  public postGiziImtU(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaanstatusgiziimtu/' + dataAnakId,
      model
    );
  }

  /**
   *
   * @param dataAnakId
   * @returns
   */
  public getGiziIpTb(dataAnakId: number): Observable<GiziIpTb[]> {
    return this.http.get<GiziIpTb[]>(
      this.baseUrl + 'PemeriksaanStatusGiziIpTb/' + dataAnakId
    );
  }

  /**
   *
   * @param dataAnakId
   * @param model
   * @returns
   */
  public postGiziIpTb(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'PemeriksaanStatusGiziIpTb/' + dataAnakId,
      model
    );
  }

  /**
   *
   * @param dataAnakId
   * @returns
   */
  public getDayaLihat(dataAnakId: number): Observable<DayaLihat[]> {
    return this.http.get<DayaLihat[]>(
      this.baseUrl + 'pemeriksaandayalihat/' + dataAnakId
    );
  }

  /**
   *
   * @param dataAnakId
   * @param model
   * @returns
   */
  public postDayaLihat(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaandayalihat/' + dataAnakId,
      model
    );
  }

  /**
   *
   * @param dataAnakId
   * @returns
   */
  public getPemeriksaanGpph(
    dataAnakId: number
  ): Observable<PemeriksaanKesehatanGpph[]> {
    return this.http.get<PemeriksaanKesehatanGpph[]>(
      this.baseUrl + 'pemeriksaangpph/' + dataAnakId
    );
  }

  /**
   *
   * @param dataAnakId
   * @param model
   * @returns
   */
  public postPemeriksaanGpph(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaangpph/' + dataAnakId,
      model
    );
  }

  /**
   *
   * @param dataAnakId
   * @returns
   */
  public getPemeriksaanKmpe(
    dataAnakId: number
  ): Observable<PemeriksaanKesehatanKmpe[]> {
    return this.http.get<PemeriksaanKesehatanKmpe[]>(
      this.baseUrl + 'pemeriksaankmpe/' + dataAnakId
    );
  }

  /**
   *
   * @param dataAnakId
   * @param model
   * @returns
   */
  public postPemeriksaanKmpe(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaankmpe/' + dataAnakId,
      model
    );
  }

  /**
   *
   * @param dataAnakId
   * @returns
   */
  public getPemeriksaanMchat(
    dataAnakId: number
  ): Observable<PemeriksaanKesehatanMchat[]> {
    return this.http.get<PemeriksaanKesehatanMchat[]>(
      this.baseUrl + 'pemeriksaanmchat/' + dataAnakId
    );
  }

  /**
   *
   * @param dataAnakId 
   * @param model
   * @returns
   */
  public postPemeriksaanMchat(dataAnakId: number, model: any) {
    return this.http.post(
      this.baseUrl + 'pemeriksaanmchat/' + dataAnakId,
      model
    );
  }
}
