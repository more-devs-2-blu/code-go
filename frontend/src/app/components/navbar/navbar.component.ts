import { Router } from '@angular/router';
import { AuthService } from './../../services/auth.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  constructor(public auth: AuthService, public router: Router){}

  logout():void{
    localStorage.removeItem('loggedIn');
    this.router.navigate(['/'])
  }
}
