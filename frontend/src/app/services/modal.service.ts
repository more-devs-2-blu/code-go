import {
  ComponentFactoryResolver,
  ComponentRef,
  Injectable,
  ViewContainerRef,
} from '@angular/core';
import { Subject } from 'rxjs';
import { DynamicModalComponent } from '../components/dynamic-modal/dynamic-modal.component';
import { Type } from '@angular/core'; 

@Injectable({ providedIn: 'root' })
export class ModalService {
  private componentRef!: ComponentRef<DynamicModalComponent>;
  private componentSubscriber!: Subject<string>;
  constructor(private resolver: ComponentFactoryResolver) {}

  openModal(entry: ViewContainerRef, modalTitle: string, modalBody: Type<unknown>) {
    let factory = this.resolver.resolveComponentFactory(DynamicModalComponent);
    this.componentRef = entry.createComponent(factory);
    this.componentRef.instance.title = modalTitle;
    this.componentRef.instance.body = modalBody;
    this.componentRef.instance.closeMeEvent.subscribe(() => this.closeModal());
    this.componentRef.instance.confirmEvent.subscribe(() => this.confirm());
    this.componentSubscriber = new Subject<string>();
    return this.componentSubscriber.asObservable();
  }

  closeModal() {
    this.componentSubscriber.complete();
    this.componentRef.destroy();
  }

  confirm() {
    this.componentSubscriber.next('confirm');
    this.closeModal();
  }
}