import { PersonService } from './../../services/person.service';
import { Login } from './../../models/login';
import { Person } from './../../models/person';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  formulario: any;
  formularioLogin: any;
  // @Input() register?: Person;
  // @Input() login?: Login;

  // @Output() personsUpdated = new EventEmitter<Person[]>();

  constructor(public service: PersonService) { }

  ngOnInit(): void {

    this.formulario = new FormGroup({
      name: new FormControl(null),
      birth: new FormControl(null),
      email: new FormControl(null),
      password: new FormControl(null),
      phone: new FormControl(null),
      cpf: new FormControl(null),
      type: new FormControl(null),
      createdOn: new FormControl(null),
    })

    this.formularioLogin = new FormGroup({
      email: new FormControl(null),
      password: new FormControl(null),
    })


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

  enviarCadastro():void{
    const person: Person = this.formulario.value;
    this.service.postPerson(person).subscribe(resp=>{
      alert('Pessoa inserida com sucesso');
    })
  }

  enviarLogin():void{
    
  }

  // createPerson(person: Person){
  //   this.service.postPerson(person).subscribe(
  //       (resp: Person[]) =>
  //         this.personsUpdated.emit(resp)

  //   );
  }


