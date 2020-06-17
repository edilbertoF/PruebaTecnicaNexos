import { Component, OnInit, Output, EventEmitter, ViewChild, TemplateRef } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Paciente } from '../_models/Paciente';
import { PacienteService } from '../_services/paciente.service';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Doctor } from '../_models/Doctor';
import { DoctorService } from '../_services/doctor.service';

@Component({
  selector: 'app-registrar-paciente',
  templateUrl: './registrar-paciente.component.html',
  styleUrls: ['./registrar-paciente.component.css']
})
export class RegistrarPacienteComponent implements OnInit {
  registerForm: FormGroup;
  paciente: Paciente;
  doctores: Doctor[];
  @ViewChild('myModalConf', {static: false}) myModalConf: TemplateRef<any>;

  constructor(private fb: FormBuilder, private paciService: PacienteService,
              private doctorService: DoctorService,
              private router: Router,
              private modalService: NgbModal) { }

  ngOnInit() {
    this.createRegisterForm();
    this.loadDoctores();
  }

  register() {
    if (this.registerForm.valid) {
      this.paciente = Object.assign({}, this.registerForm.value);
      this.paciService.register(this.paciente).subscribe(() => {
        console.log('Registration successful');
        this.mostrarModalConf();
        this.router.navigate(['/CRUDPacientes']);
      }, error => {
        console.log(error);
      });
    }
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      nombreCompleto: ['', Validators.required],
      numSeguroSocial: ['', Validators.required],
      codigoPostal: ['', Validators.required],
      telefono: ['', Validators.required]
    });
  }

  cancel() {
    console.log('Cancelled');
    this.createRegisterForm();
  }

  mostrarModalConf(){
    this.modalService.open(this.myModalConf).result.then( r => {
      console.log('Tu respuesta ha sido: ' + r);
      this.router.navigate(['/CRUDPacientes']);
    }, error => {
      console.log(error);
    });
  }

  loadDoctores() {
    this.doctorService.getDoctores()
        .subscribe((res: Doctor[]) => {
          this.doctores = res;
        }, error => {
          console.log(error);
        });
  }

  agregarQuitarSeleccion(id: number) {
    console.log(id);
  }

}
