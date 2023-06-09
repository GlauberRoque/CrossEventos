import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../Models/Evento';

@Injectable(
    //{ providedIm: 'root'}
)
export class EventoService {
baseURL = 'https://localhost:7023/api/Evento'
constructor(private http: HttpClient) { }

  public getEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL)
  }

  public getEventosByNome(nome: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${nome}/nome`)
  }

  public getEventosById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}/id`)
  }
}
