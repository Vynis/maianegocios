import { AbstractControl, Validators } from '@angular/forms';

export class GenericValidator {
    constructor() {}
    static isValidCpf() {
        return (control: AbstractControl): Validators => {
            const numero = control.value;
            const { cpf } = require('cpf-cnpj-validator');

            if (numero.length === 11) {

                if (!cpf.isValid(numero)){
                    return { cpfNotValid: true };
                }

                return null;

            }
            else{
                return null;
            }
        }
    }

    static isValidCnpj(){
        return (control: AbstractControl): Validators => {
            const numero = control.value;
            const { cnpj } = require('cpf-cnpj-validator'); 
            
            if (numero.length === 14) {
                
                if (!cnpj.isValid(numero)){
                    return { cnpjNotValid: true };
                }

                return null;

            }
            else {
                return null;
            }
        }
    }
}
