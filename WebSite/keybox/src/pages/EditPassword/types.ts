import type { SenhaDTO } from "../../domain/senha";
import type { CategoriaDTO } from "../../domain/categoria";
import type { EtiquetaDTO } from "../../domain/etiqueta";

export interface EditPasswordState {
  senha?: SenhaDTO;
  categorias: CategoriaDTO[];
  etiquetas: EtiquetaDTO[];
  categoriaSelecionada?: number;
  etiquetasSelecionadas: number[];
  loading: boolean;
}
