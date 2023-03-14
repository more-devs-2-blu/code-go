import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    const signUpButton: HTMLElement | null = document.getElementById('signUp');
    const signInButton: HTMLElement | null = document.getElementById('signIn');
    const container: HTMLElement | null = document.getElementById('container');

    if (signUpButton && signInButton && container) {
      signUpButton.addEventListener('click', (): void => {
        container.classList.add("right-panel-active");
      });

      signInButton.addEventListener('click', (): void => {
        container.classList.remove("right-panel-active");
      });
    }
  }

}
