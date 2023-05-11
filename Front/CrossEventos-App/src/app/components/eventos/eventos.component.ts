
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
  ngOnInit(): void {

  }

}
