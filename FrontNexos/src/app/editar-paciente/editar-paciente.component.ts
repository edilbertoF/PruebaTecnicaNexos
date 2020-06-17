import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Paciente } from '../_models/Paciente';
import { PacienteService } from '../_services/paciente.service';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PacienteActualizar } from '../_models/PacienteActualizar';

@Component({
  selector: 'app-editar-paciente',
  templateUrl: './editar-paciente.component.html',
  styleUrls: ['./editar-paciente.component.css']
})
export class EditarPacienteComponent implements OnInit {
  pacientes: Paciente[];
  editForm: FormGroup;
  paciente: Paciente;
  idPaciente: Paciente;
  pacienteActualizar: PacienteActualizar;
  editFormPaciente: FormGroup;
  @ViewChild('myModalConf', {static: false}) myModalConf: TemplateRef<any>;

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
     if (this.editForm.valid) {
      this.idPaciente = Object.assign({}, this.editForm.value);
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
    this.editForm = this.fb.group({
      idPaciente: ['', Validators.required]
    });
  }

  editar() {
    if (this.editFormPaciente.valid) {
      this.idPaciente = Object.assign({}, this.editFormPaciente.value);
      this.paciente = Object.assign({}, this.editFormPaciente.value);
      this.paciService.actualizarPaciente(this.paciente.idPaciente, this.paciente).subscribe(() => {
        console.log('Actualización exitosa');
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
    this.editFormPaciente = this.fb.group({
      idPaciente: paciente.idPaciente,
      nombreCompleto: paciente.nombreCompleto,
      numSeguroSocial: paciente.numSeguroSocial,
      codigoPostal: paciente.codigoPostal,
      telefono: paciente.telefono
    });
  }

  createEditForm() {
    this.editFormPaciente = this.fb.group({
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

}
