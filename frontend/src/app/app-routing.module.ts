import { ContributorEditComponent } from './components/contributor-edit/contributor-edit.component';
import { OccurranceDetailsComponent } from './components/occurrance-details/occurrance-details.component';
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
  {path: 'occurrence', component: OccurrenceComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'occurrence-details', component: OccurranceDetailsComponent},
  {path: 'register-occurrence', component: RegisterComponent},
  {path: 'contributor-edit', component: ContributorEditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
