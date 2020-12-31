import { Component, OnInit } from '@angular/core';
import { SubheaderService } from '../../../../core/_base/layout';
import { Observable, BehaviorSubject } from 'rxjs';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { ParametroSistemaService, ParametroSistemaModel } from '../../../../core/parametrosistema';
import { LayoutUtilsService } from '../../../../core/_base/crud';

export enum MessageType {
	Create,
	Read,
	Update,
	Delete
}

@Component({
  selector: 'kt-parametros-sistema-cadastro',
  templateUrl: './parametros-sistema-cadastro.component.html',
  styleUrls: ['./parametros-sistema-cadastro.component.scss']
})
export class ParametrosSistemaCadastroComponent implements OnInit {
  loading$: Observable<boolean>;
  loadingSubject = new BehaviorSubject<boolean>(true);
  parametrosForm: FormGroup;
  parametroSistema: ParametroSistemaModel[];
  hasFormErrors = false;

  constructor(
    private subheaderService: SubheaderService,
    private parametrosFb: FormBuilder,
    private parametrosService: ParametroSistemaService,
    private layoutUtilsService: LayoutUtilsService,
  ) { }

  get parametros(): FormArray{
    return <FormArray>this.parametrosForm.get('parametros');
  }

  ngOnInit() {

    this.loading$ = this.loadingSubject.asObservable();
    this.loadingSubject.next(true);
    this.subheaderService.setTitle('Parametros do Sistema');

    this.carregarControles();
    this.carregarServiceParametros();
  }

  carregarControles(){
    this.parametrosForm = this.parametrosFb.group({
      parametros: this.parametrosFb.array([])
    });
  }

  criarCampos(parametro: any): FormGroup {
    return this.parametrosFb.group({
      id: [parametro.id],
      nome: [parametro.nome],
      titulo: [parametro.titulo],
      valor: [parametro.valor, Validators.required],
      status: [parametro.status, Validators.required],
    });
  }

  carregarServiceParametros(){
    let teste;
    this.parametrosService.getAllParametro().subscribe(
      (parametro: ParametroSistemaModel) => {

        this.parametroSistema = Object.assign([], parametro);

        this.parametroSistema.forEach(parametro =>{
          this.parametros.push(this.criarCampos(parametro));
        });

        this.loadingSubject.next(false);
      }
    );
  }

  onSumbit(){
    this.hasFormErrors = false;
    const controls = this.parametrosForm.controls;
    /** check form */
    if (this.parametrosForm.invalid) {
      Object.keys(controls).forEach(controlName =>
        controls[controlName].markAsTouched()
      );
  
      this.hasFormErrors = true;
      return;
    }

    let preparadoParametros = this.prepareParametrosSistema();

    this.loadingSubject.next(true);

    this.parametrosService.updateParametros(preparadoParametros)
    .subscribe((result) =>{
      const message = `Parametros atualizado com sucesso.`;
      this.layoutUtilsService.showActionNotification(message, MessageType.Update, 10000, true, true);
      this.loadingSubject.next(false);
    });

  }

  prepareParametrosSistema(): ParametroSistemaModel[] {
    const controls = this.parametrosForm.controls;
    var listaParametro = [];

    controls.parametros.value.forEach(param => {
      const _parametro = new ParametroSistemaModel();
      _parametro.id = param.id;
      _parametro.valor = param.valor;
      _parametro.status = param.status;
      listaParametro.push(_parametro);
    });
    
    return listaParametro;
  }

  onAlertClose(){

  }

}
