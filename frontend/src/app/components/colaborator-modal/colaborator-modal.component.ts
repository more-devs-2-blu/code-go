import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'colaborator-modal',
  templateUrl: './colaborator-modal.component.html',
  styleUrls: ['./colaborator-modal.component.css']
})
export class ColaboratorModalComponent implements OnInit {
  title = 'Modal';
  
  constructor() { }

  ngOnInit(): void {
  }

  openModal() {
    const modal = document.querySelector('.modal');
    modal.style.display = 'block';
  }

  closeModal() {
    const modal = document.querySelector('.modal');
    modal.style.display = 'none';
  }

  onSave() {
    // Adicione aqui a lógica para salvar os dados do formulário
    this.closeModal();
  }
}
