import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './contents/nav/nav.component';
import { HomeComponent } from './contents/home/home.component';
import { LoginComponent } from './contents/account/login/login.component';
import { RegisterComponent } from './contents/account/register/register.component';
import { NakesComponent } from './contents/memberNakes/nakes/nakes.component';
import { SharedModule } from './_modules/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TestErrorsComponent } from './contents/errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './contents/errors/not-found/not-found.component';
import { ServerErrorComponent } from './contents/errors/server-error/server-error.component';
import { NakesCardComponent } from './contents/memberNakes/nakes-card/nakes-card.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { NakesDetailComponent } from './contents/memberNakes/nakes-detail/nakes-detail.component';
import { NakesEditComponent } from './contents/memberNakes/nakes-edit/nakes-edit.component';
import { FooterComponent } from './contents/footer/footer.component';
import { AnakComponent } from './contents/memberAnak/anak/anak.component';
import { DashboardComponent } from './contents/dashboard/dashboard.component';
import { AnakDetailComponent } from './contents/memberAnak/anak-detail/anak-detail.component';
import { AnakAddComponent } from './contents/memberAnak/anak-add/anak-add.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AnakEditComponent } from './contents/memberAnak/anak-edit/anak-edit.component';
import { AnakPemeriksaanComponent } from './contents/memberAnak/anak-pemeriksaan/anak-pemeriksaan.component';
import { MaterialModule } from './_modules/material.module';
import { LayoutComponent } from './layout/layout.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HeaderComponent } from './navigation/header/header.component';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { BeratBadanComponent } from './contents/memberAnak/dialogs/berat-badan/berat-badan.component';
import { TinggiBadanComponent } from './contents/memberAnak/dialogs/tinggi-badan/tinggi-badan.component';
import { LingkarKepalaComponent } from './contents/memberAnak/dialogs/lingkar-kepala/lingkar-kepala.component';
import { KpspComponent } from './contents/memberAnak/dialogs/kpsp/kpsp.component';
import { MAT_RADIO_DEFAULT_OPTIONS } from '@angular/material/radio';
import { ImtComponent } from './contents/memberAnak/dialogs/imt/imt.component';
import { DayaDengarComponent } from './contents/memberAnak/dialogs/daya-dengar/daya-dengar.component';
import { DayaLihatComponent } from './contents/memberAnak/dialogs/daya-lihat/daya-lihat.component';
import { KmpeComponent } from './contents/memberAnak/dialogs/kmpe/kmpe.component';
import { GpphComponent } from './contents/memberAnak/dialogs/gpph/gpph.component';
import { AdminPanelComponent } from './contents/admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directive/has-role.directive';
import { UploadPhotoAnakComponent } from './contents/memberAnak/upload-photo-anak/upload-photo-anak.component';
import { UploadTtdComponent } from './contents/memberAnak/upload-ttd/upload-ttd.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { KesehatanTabComponent } from './contents/memberAnak/tabs/kesehatan-tab/kesehatan-tab.component';
import { GpphShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/gpph-show/gpph-show.component';
import { KmpeShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/kmpe-show/kmpe-show.component';
import { MchatShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/mchat-show/mchat-show.component';
import { JadwalImunisasiTabComponent } from './contents/memberAnak/tabs/jadwal-imunisasi-tab/jadwal-imunisasi-tab.component';
import { RiwayatOrangTuaTabComponent } from './contents/memberAnak/tabs/riwayat-orang-tua-tab/riwayat-orang-tua-tab.component';
import { RiwayatKelahiranTabComponent } from './contents/memberAnak/tabs/riwayat-kelahiran-tab/riwayat-kelahiran-tab.component';
import { DayaLihatShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/daya-lihat-show/daya-lihat-show.component';
import { DayaDengarShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/daya-dengar-show/daya-dengar-show.component';
import { KpspShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/kpsp-show/kpsp-show.component';
import { GiziBbTbShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/gizi-bb-tb-show/gizi-bb-tb-show.component';
import { GiziImtUShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/gizi-imt-u-show/gizi-imt-u-show.component';
import { GiziIpTbShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/gizi-ip-tb-show/gizi-ip-tb-show.component';
import { GiziLingkarKepalaShowComponent } from './contents/memberAnak/dialogs-kesehatan-show/gizi-lingkar-kepala-show/gizi-lingkar-kepala-show.component';
import { MchatInputComponent } from './contents/memberAnak/dialogs-kesehatan-input/mchat-input/mchat-input.component';
import { GpphInputComponent } from './contents/memberAnak/dialogs-kesehatan-input/gpph-input/gpph-input.component';
import { KmpeInputComponent } from './contents/memberAnak/dialogs-kesehatan-input/kmpe-input/kmpe-input.component';
import { DayaLihatInputComponent } from './contents/memberAnak/dialogs-kesehatan-input/daya-lihat-input/daya-lihat-input.component';
import { GiziIpTbInputComponent } from './contents/memberAnak/dialogs-kesehatan-input/gizi-ip-tb-input/gizi-ip-tb-input.component';
import { GiziImtUComponent } from './contents/memberAnak/dialogs-kesehatan-input/gizi-imt-u/gizi-imt-u.component';
import { GiziBbTbInputComponent } from './contents/memberAnak/dialogs-kesehatan-input/gizi-bb-tb-input/gizi-bb-tb-input.component';
import { LingkarKepalaInputComponent } from './contents/memberAnak/dialogs-kesehatan-input/lingkar-kepala-input/lingkar-kepala-input.component';
import { GridComponent } from './components/grid/grid.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    NakesComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    NakesCardComponent,
    NakesDetailComponent,
    NakesEditComponent,
    FooterComponent,
    AnakComponent,
    DashboardComponent,
    AnakDetailComponent,
    AnakAddComponent,
    AnakEditComponent,
    AnakAddComponent,
    AnakPemeriksaanComponent,
    LayoutComponent,
    HeaderComponent,
    SidenavListComponent,
    BeratBadanComponent,
    TinggiBadanComponent,
    LingkarKepalaComponent,
    KpspComponent,
    ImtComponent,
    DayaDengarComponent,
    DayaLihatComponent,
    KmpeComponent,
    GpphComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UploadPhotoAnakComponent,
    UploadTtdComponent,
    KesehatanTabComponent,
    GpphShowComponent,
    KmpeShowComponent,
    MchatShowComponent,
    JadwalImunisasiTabComponent,
    RiwayatOrangTuaTabComponent,
    RiwayatKelahiranTabComponent,
    DayaLihatShowComponent,
    DayaDengarShowComponent,
    KpspShowComponent,
    GiziBbTbShowComponent,
    GiziImtUShowComponent,
    GiziIpTbShowComponent,
    GiziLingkarKepalaShowComponent,
    MchatInputComponent,
    GpphInputComponent,
    KmpeInputComponent,
    DayaLihatInputComponent,
    GiziIpTbInputComponent,
    GiziImtUComponent,
    GiziBbTbInputComponent,
    LingkarKepalaInputComponent,
    GridComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    ReactiveFormsModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    SharedModule,
    NgxSpinnerModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    [
      {
        provide: MAT_RADIO_DEFAULT_OPTIONS,
        useValue: { color: 'primary' },
      },
    ],
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
