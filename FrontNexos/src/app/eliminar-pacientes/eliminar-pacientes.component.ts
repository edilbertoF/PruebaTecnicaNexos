import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { PacienteService } from '../_services/paciente.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Paciente } from '../_models/Paciente';

@Component({
  selector: 'app-eliminar-pacientes',
  templateUrl: './eliminar-pacientes.component.html',
  styleUrls: ['./eliminar-pacientes.component.css']
})
export class EliminarPacientesComponent implements OnInit {
  pacientes: Paciente[];
  deleteForm: FormGroup;
  paciente: Paciente;
  idPaciente: Paciente;
  deleteFormPaciente: FormGroup;
  @ViewChild('myModalConf', {static: false}) myModalConf: TemplateRef<any>;
  @ViewChild('myModalConfEliminar', {static: false}) myModalConfEliminar: TemplateRef<any>;

  constructor(private paciService: PacienteService, private route: Router, private fb: FormBuilder,
              private modalService: NgbModal) { }

  ngOnInit() {
    this.loadPacientes();
    this.createEdit();
    this.createEditForm();
  }

  loadPacientes() {
    this.paciService.getPacientes()
        .subscribe((res: Paciente[]) => {
          this.pacientes = res;
        }, error => {
          console.log(error);
        });
  }

  buscar() {
     if (this.deleteForm.valid) {
      this.idPaciente = Object.assign({}, this.deleteForm.value);
      this.paciService.consultarPaciente(this.idPaciente.idPaciente).subscribe((res: Paciente) => {
        this.paciente = res;
        this.cargarPaciente(this.paciente);
        console.log(this.paciente);
      }, error => {
        console.log(error);
      });
    }
  }

  createEdit() {
    this.deleteForm = this.fb.group({
      idPaciente: ['', Validators.required]
    });
  }

  eliminar() {
    if (this.deleteFormPaciente.valid) {
      this.idPaciente = Object.assign({}, this.deleteFormPaciente.value);
      this.paciente = Object.assign({}, this.deleteFormPaciente.value);
      this.paciService.eliminarPaciente(this.paciente.idPaciente).subscribe(() => {
        console.log('Eliminación exitosa');
        this.mostrarModalConf();
        this.route.navigate(['/CRUDPacientes']);
      }, error => {
        console.log(error);
      });
    }
  }

  cancel() {
    this.paciente = null;
  }

  cargarPaciente(paciente: Paciente) {
    this.deleteFormPaciente = this.fb.group({
      idPaciente: paciente.idPaciente,
      nombreCompleto: paciente.nombreCompleto,
      numSeguroSocial: paciente.numSeguroSocial,
      codigoPostal: paciente.codigoPostal,
      telefono: paciente.telefono
    });
  }

  createEditForm() {
    this.deleteFormPaciente = this.fb.group({
      idPaciente: ['', Validators.required],
      nombreCompleto: ['', Validators.required],
      numSeguroSocial: ['', Validators.required],
      codigoPostal: ['', Validators.required],
      telefono: ['', Validators.required]
    });
  }

  mostrarModalConf(){
    this.modalService.open(this.myModalConf).result.then( r => {
      console.log('Tu respuesta ha sido: ' + r);
    }, error => {
      console.log(error);
    });
  }

  mostrarModalConfEliminar(){
    this.modalService.open(this.myModalConfEliminar).result.then( r => {
      console.log('Tu respuesta ha sido: ' + r);
      if (r === 'Si') {
        this.eliminar();
      }
    }, error => {
      console.log(error);
    });
  }

}
