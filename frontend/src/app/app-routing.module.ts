import { AuthGuard } from './guards/auth.guard';
import { RegisterComponent } from './components/register/register.component';
import { OccurrenceComponent } from './components/occurrence/occurrence.component';
import { LoginComponent } from './components/login/login.component';
import { ListOccurrenceComponent } from './components/list-occurrence/list-occurrence.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'list-occurrence', component: ListOccurrenceComponent},
  {path: 'login', component: LoginComponent},
  {path: 'occurrence', component: OccurrenceComponent, canActivate: [AuthGuard]},
  {path: 'register', component: RegisterComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
