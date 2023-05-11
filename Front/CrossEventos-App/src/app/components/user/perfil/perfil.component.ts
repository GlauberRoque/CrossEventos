import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from 'src/app/helpers/validatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  get f(): any {
    return this.form.controls;
  }

  form!: FormGroup;

  constructor(public fb: FormBuilder) { }

  ngOnInit() {
    this.validation();
  }

  private validation(): void{
    const formOptions: AbstractControlOptions ={
      validators: ValidatorField.MustMatch('senha', 'confirmaSenha')
    };

      this.form = this.fb.group({
        primeiroNome: ['', Validators.required],
        ultimoNome: ['', Validators.required],
        email: ['',[ Validators.required, Validators.email]],
        telefone: ['', Validators.required],
        funcao: ['', Validators.required],
        descricao: ['', [Validators.required, Validators.maxLength(256)]],
        senha: ['', [Validators.required, Validators.minLength(6)]],
        confirmaSenha: ['', Validators.required],
      }, formOptions)
  }

  public resetForm(event: any): void{
    event.preventDefault();
    this.form.reset();
  }

}
