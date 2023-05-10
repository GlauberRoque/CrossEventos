import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Promotor {

  id: number;
  nome: string;
  imagemURL: string;
  telefone: string;
  email: string;
  redesSociais?: RedeSocial[];
  promotoresEventos?: Evento[];

}
