
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ComunicacaoBaseService } from '../../_config/comunicacao-base.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { ParametroSistemaModel } from '../_models/parametro.sistema.model';
import { QueryParamsModel, QueryResultsModel, HttpUtilsService } from '../../_base/crud';

var BASE_URL: string;
var CAMINHO_EXTERNO: String;

@Injectable()
export class ParametroSistemaService {
lastFilter$: BehaviorSubject<QueryParamsModel> = new BehaviorSubject(new QueryParamsModel({}, 'asc', '', 0, 10));

constructor(private http: HttpClient,
            private comunicacao: ComunicacaoBaseService,
            private httpUtils: HttpUtilsService) { 
  BASE_URL = this.comunicacao.caminhoApi + 'api/parametros/';
  CAMINHO_EXTERNO = this.comunicacao.caminhoApi;
  
}

getTipoParametro(nome: string): Observable<ParametroSistemaModel> {
  return this.http.get<ParametroSistemaModel>(BASE_URL + `obter-parametros/${nome}`);
}

getAllParametro(): Observable<ParametroSistemaModel> {
  return this.http.get<ParametroSistemaModel>(BASE_URL + `obter-parametros-todos`);
}

updateParametros(parametros: ParametroSistemaModel[]): Observable<any>{
  const httpHeaders = this.httpUtils.getHTTPHeaders();
  return this.http.put(BASE_URL + 'atualizar', parametros, { headers: httpHeaders });
}

}