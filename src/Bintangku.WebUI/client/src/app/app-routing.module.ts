import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./account/login/login.component";
import { RegisterComponent } from "./account/register/register.component";
import { NotFoundComponent } from "./errors/not-found/not-found.component";
import { ServerErrorComponent } from "./errors/server-error/server-error.component";
import { TestErrorsComponent } from "./errors/test-errors/test-errors.component";
import { HomeComponent } from "./home/home.component";
import { NakesComponent } from "./nakes/nakes.component";
import { AuthGuard } from "./_guards/auth.guard";

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  {
    path: "",
    runGuardsAndResolvers: "always",
    canActivate: [AuthGuard],
    children: [
      { path: "nakes", component: NakesComponent, canActivate: [AuthGuard] },
    ],
  },
  { path: "errors", component: TestErrorsComponent },
  { path: "not-found", component: NotFoundComponent },
  { path: "server-error", component: ServerErrorComponent },
  { path: "**", component: NotFoundComponent, pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
