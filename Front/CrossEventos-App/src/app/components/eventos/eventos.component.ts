
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../../services/Evento.service';
import { Evento } from '../../Models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit{
  modalRef?: BsModalRef;

public eventos: Evento[] = [];
public eventosFiltrados: Evento[] = [];

public larguraImagem = 100;
public margemImagem = 2;
public exibirImagem: boolean = true;
private _filtroLista: string = '';

public get filtroLista(): string {
  return this._filtroLista;
}
public set filtroLista(value: string){
  this._filtroLista = value;
  this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
}
//  metodo para filtrar os eventos pelo nome e local
filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { nome: string; local: string; }) => evento.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
}

constructor(private eventoService: EventoService,
            private modalService: BsModalService,
            private toastr: ToastrService,
            private spinner: NgxSpinnerService) {}

public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();

}

public alterarImagem() {
  this.exibirImagem = !this.exibirImagem;
}

  public getEventos(): void {
      this.eventoService.getEventos().subscribe({
        next:(_eventos: Evento[])=> {
          this.eventos = _eventos
          this.eventosFiltrados = this.eventos;
       },
       error: (error: any) => {
                       this.spinner.hide();
                       this.toastr.error('Erro ao carregar os eventos', 'Deletado!');
       },
       complete: () => this.spinner.hide()
      }


   );

  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O evento foi deletado com sucesso!', 'Deletado');
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
