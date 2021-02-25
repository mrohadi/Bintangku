import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NotFoundComponent } from './components/errors/not-found/not-found.component';
import { ServerErrorComponent } from './components/errors/server-error/server-error.component';
import { TestErrorsComponent } from './components/errors/test-errors/test-errors.component';
import { HomeComponent } from './components/home/home.component';
import { AnakAddComponent } from './components/memberAnak/anak-add/anak-add.component';
import { AnakDetailComponent } from './components/memberAnak/anak-detail/anak-detail.component';
import { AnakEditComponent } from './components/memberAnak/anak-edit/anak-edit.component';
import { AnakComponent } from './components/memberAnak/anak/anak.component';
import { NakesDetailComponent } from './components/memberNakes/nakes-detail/nakes-detail.component';
import { NakesEditComponent } from './components/memberNakes/nakes-edit/nakes-edit.component';
import { NakesComponent } from './components/memberNakes/nakes/nakes.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'dash-board',
        component: DashboardComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'nakes-members',
        component: NakesComponent,
      },
      { path: 'nakes-members/:username', component: NakesDetailComponent },
      { path: 'nakes-member/edit', component: NakesEditComponent },
      { path: 'anak-members', component: AnakComponent },
      { path: 'anak-members/add', component: AnakAddComponent },
      { path: 'anak-members/edit', component: AnakEditComponent },
      { path: 'anak-members/:id', component: AnakDetailComponent },
    ],
  },
  { path: 'errors', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
