import {
  Component,
  ComponentFactoryResolver,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
  ViewChild,
  ViewContainerRef,
} from '@angular/core';
import { Type } from '@angular/core';

@Component({
  selector: 'dynamic-modal',
  templateUrl: 'dynamic-modal.component.html',
  styleUrls: ['dynamic-modal.component.scss'],
})
export class DynamicModalComponent implements OnInit, OnDestroy {
  constructor(private resolverFactory: ComponentFactoryResolver) {
      
  }
  titulo: string = "Título";
  date: string = "Data";
  street: string = "Rua";
  neighborhood: string = "Bairro";
  city: string = "Município";
  status: string = "Status";

  @Input() title: string = '';
  @Input() body!: Type<unknown>;
  @Output() closeMeEvent = new EventEmitter();
  @Output() confirmEvent = new EventEmitter();

  @ViewChild('viewContainer', {read: ViewContainerRef, static: false}) viewContainer!: ViewContainerRef;

  ngOnInit(): void {
    console.log('Modal init');
  }

  closeMe() {
    this.closeMeEvent.emit();
  }
  confirm() {
    this.confirmEvent.emit();
  }

  ngOnDestroy(): void {
    console.log('Modal destroyed');
  }

  ngAfterViewInit() {
    const factory = this.resolverFactory.resolveComponentFactory(this.body as any);
    this.viewContainer.createComponent(factory);
  }
}
