import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from 'src/app/helpers/validatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit{

  get f(): any {
    return this.form.controls;
  }

  form!: FormGroup;

  constructor(public fb: FormBuilder) {}

  ngOnInit(): void {

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
        usuario: ['', Validators.required],
        senha: ['', [Validators.required, Validators.minLength(6)]],
        confirmaSenha: ['', Validators.required],
      }, formOptions)
  }

}
