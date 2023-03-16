import { AuthService } from './../../services/auth.service';
import { PersonService } from './../../services/person.service';
import { Login } from './../../models/login';
import { Person } from './../../models/person';
import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  Type,
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  formulario: any;
  formularioLogin: any;
  // @Input() register?: Person;
  // @Input() login?: Login;

  // @Output() personsUpdated = new EventEmitter<Person[]>();

  constructor(
    public service: PersonService,
    public auth: AuthService,
    public router: Router
  ) {}

  ngOnInit(): void {
    this.formulario = new FormGroup({
      name: new FormControl(null),
      birth: new FormControl(null),
      email: new FormControl(null),
      password: new FormControl(null),
      cpf: new FormControl(null),
      // type: new FormControl(null),
      // createdOn: new FormControl(null),
    });

    this.formularioLogin = new FormGroup({
      email: new FormControl(null),
      password: new FormControl(null),
    });

    const signUpButton: HTMLElement | null = document.getElementById('signUp');
    const signInButton: HTMLElement | null = document.getElementById('signIn');
    const container: HTMLElement | null = document.getElementById('container');

    if (signUpButton && signInButton && container) {
      signUpButton.addEventListener('click', (): void => {
        container.classList.add('right-panel-active');
      });

      signInButton.addEventListener('click', (): void => {
        container.classList.remove('right-panel-active');
      });
    }
  }

  enviarCadastro(): void {
    console.log(this.formulario);
    const person: Person = this.formulario.value;
    person.type = 1;

    console.log(person)
    localStorage.setItem("UserType", "1");
    this.service.postPerson(person).subscribe((resp)=>{
      this.auth.login().then(()=>{
        this.router.navigate(['/list-occurrence'])
      })
    })
  }

  enviarLogin():void{
    const person: Person = this.formularioLogin.value;

    this.service.getLogin(person).subscribe((resp)=>{
      console.log(resp);
      if(resp){
        this.auth.login().then(()=>{
          this.router.navigate(['/list-occurrence'])
        })
      }
    })
  }


  // createPerson(person: Person){
  //   this.service.postPerson(person).subscribe(
  //       (resp: Person[]) =>
  //         this.personsUpdated.emit(resp)

  //   );
}
