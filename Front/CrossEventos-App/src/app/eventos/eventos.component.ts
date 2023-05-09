import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit{

public eventos: any = [];
public eventosFiltrados: any = [];

larguraImagem = 100;
margemImagem = 2;
exibirImagem: boolean = true;
private _filtroLista: string = '';

public get filtroLista(): string {
  return this._filtroLista;
}
public set filtroLista(value: string){
  this._filtroLista = value;
  this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
}
//  metodo para filtrar os eventos pelo nome e local
filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { nome: string; local: string; }) => evento.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
}

constructor(private http: HttpClient) {}

ngOnInit(): void {
    this.getEventos();

}

alterarImagem() {
  this.exibirImagem = !this.exibirImagem;
}

  public getEventos(): void {
      this.http.get('https://localhost:7023/api/Evento').subscribe(
      response => {
         this.eventos = response
         this.eventosFiltrados = this.eventos
      },
      error => console.log(error)

   );

  }


}
