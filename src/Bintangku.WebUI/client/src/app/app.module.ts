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
import { HomesComponent } from './homes/homes.component';
import { HeaderComponent } from './navigation/header/header.component';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { BeratBadanComponent } from './contents/memberAnak/dialogs/berat-badan/berat-badan.component';
import { TinggiBadanComponent } from './contents/memberAnak/dialogs/tinggi-badan/tinggi-badan.component';
import { LingkarKepalaComponent } from './contents/memberAnak/dialogs/lingkar-kepala/lingkar-kepala.component';
import { KpspComponent } from './contents/memberAnak/dialogs/kpsp/kpsp.component';

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
    HomesComponent,
    HeaderComponent,
    SidenavListComponent,
    BeratBadanComponent,
    TinggiBadanComponent,
    LingkarKepalaComponent,
    KpspComponent,
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
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
