import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './components/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';
import { NakesComponent } from './components/memberNakes/nakes/nakes.component';
import { SharedModule } from './_modules/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TestErrorsComponent } from './components/errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './components/errors/not-found/not-found.component';
import { ServerErrorComponent } from './components/errors/server-error/server-error.component';
import { NakesCardComponent } from './components/memberNakes/nakes-card/nakes-card.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { NakesDetailComponent } from './components/memberNakes/nakes-detail/nakes-detail.component';
import { NakesEditComponent } from './components/memberNakes/nakes-edit/nakes-edit.component';
import { FooterComponent } from './components/footer/footer.component';
import { AnakComponent } from './components/memberAnak/anak/anak.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AnakDetailComponent } from './components/memberAnak/anak-detail/anak-detail.component';
import { AnakAddComponent } from './components/memberAnak/anak-add/anak-add.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AnakEditComponent } from './components/memberAnak/anak-edit/anak-edit.component';
import { AnakPemeriksaanComponent } from './components/memberAnak/anak-pemeriksaan/anak-pemeriksaan.component';
import { ModalBeratBadanComponent } from './components/memberAnak/modals/modal-berat-badan/modal-berat-badan.component';

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
    ModalBeratBadanComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    ReactiveFormsModule,

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
