import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NavComponent } from "./nav/nav.component";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./account/login/login.component";
import { RegisterComponent } from "./account/register/register.component";
import { NakesComponent } from "./memberNakes/nakes/nakes.component";
import { SharedModule } from "./_modules/shared.module";
import { FormsModule } from "@angular/forms";
import { TestErrorsComponent } from "./errors/test-errors/test-errors.component";
import { ErrorInterceptor } from "./_interceptors/error.interceptor";
import { NotFoundComponent } from "./errors/not-found/not-found.component";
import { ServerErrorComponent } from "./errors/server-error/server-error.component";
import { NakesCardComponent } from "./memberNakes/nakes-card/nakes-card.component";
import { JwtInterceptor } from "./_interceptors/jwt.interceptor";
import { NakesDetailComponent } from './memberNakes/nakes-detail/nakes-detail.component';
import { NakesEditComponent } from './memberNakes/nakes-edit/nakes-edit.component';
import { FooterComponent } from './footer/footer.component';
import { AnakComponent } from './memberAnak/anak/anak.component';
import { DashboardComponent } from './dashboard/dashboard.component';

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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
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
