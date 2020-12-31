import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ComunicacaoBaseService {

 //private _caminhoApi: string = "http://localhost:5000/";
// private _caminhoApi: string = "http://esollar.sis-pro.net/";
private _caminhoApi: string = "";

  constructor(
  ) { 

    this._caminhoApi = environment.api_url;

  }

  public set caminhoApi(value:string){
    this._caminhoApi = value;
  }

  public get caminhoApi() {
    return this._caminhoApi;
  }
}
