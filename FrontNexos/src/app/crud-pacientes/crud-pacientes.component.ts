import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-crud-pacientes',
  templateUrl: './crud-pacientes.component.html',
  styleUrls: ['./crud-pacientes.component.css']
})
export class CRUDPacientesComponent implements OnInit {
  radio: number;
  constructor() { }

  ngOnInit() {
  }

  registrar() {
    this.radio = 1;
  }

  editar() {
    this.radio = 2;
  }

  eliminar() {
    this.radio = 3;
  }

}
