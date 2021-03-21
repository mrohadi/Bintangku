import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './contents/account/login/login.component';
import { RegisterComponent } from './contents/account/register/register.component';
import { AdminPanelComponent } from './contents/admin/admin-panel/admin-panel.component';
import { DashboardComponent } from './contents/dashboard/dashboard.component';
import { NotFoundComponent } from './contents/errors/not-found/not-found.component';
import { ServerErrorComponent } from './contents/errors/server-error/server-error.component';
import { TestErrorsComponent } from './contents/errors/test-errors/test-errors.component';
import { HomeComponent } from './contents/home/home.component';
import { AnakAddComponent } from './contents/memberAnak/anak-add/anak-add.component';
import { AnakDetailComponent } from './contents/memberAnak/anak-detail/anak-detail.component';
import { AnakEditComponent } from './contents/memberAnak/anak-edit/anak-edit.component';
import { AnakPemeriksaanComponent } from './contents/memberAnak/anak-pemeriksaan/anak-pemeriksaan.component';
import { AnakComponent } from './contents/memberAnak/anak/anak.component';
import { NakesDetailComponent } from './contents/memberNakes/nakes-detail/nakes-detail.component';
import { NakesEditComponent } from './contents/memberNakes/nakes-edit/nakes-edit.component';
import { NakesComponent } from './contents/memberNakes/nakes/nakes.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
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
      { path: 'anak-members/:id', component: AnakDetailComponent },
      { path: 'anak-member/add', component: AnakAddComponent },
      { path: 'anak-members/edit/:id', component: AnakEditComponent },
      {
        path: 'anak-members/pemeriksaan-kesehatan/:id',
        component: AnakPemeriksaanComponent,
      },
      {
        path: 'admin',
        component: AdminPanelComponent,
        canActivate: [AdminGuard],
      },
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
