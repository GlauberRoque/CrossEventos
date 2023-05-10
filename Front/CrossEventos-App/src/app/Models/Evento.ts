import { Lote } from "./Lote";
import { Promotor } from "./Promotor";
import { RedeSocial } from "./RedeSocial";

export interface Evento {
  id: number;
  nome: string;
  local: string;
  dataEvento?: Date;
  qtdPessoas: number;
  imagemURL: string;
  telefone: string;
  email: string;
  lotes: Lote[];
  redesSociais?: RedeSocial[];
  promotoresEventos?: Promotor[];

}
