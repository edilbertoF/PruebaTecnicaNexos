import { Component, OnInit, Output, ViewChild, TemplateRef, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Doctor } from '../_models/Doctor';
import { DoctorService } from '../_services/doctor.service';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Paciente } from '../_models/Paciente';
import { PacienteService } from '../_services/paciente.service';

@Component({
  selector: 'app-registrar-doctor',
  templateUrl: './registrar-doctor.component.html',
  styleUrls: ['./registrar-doctor.component.css']
})
export class RegistrarDoctorComponent implements OnInit {

  registerForm: FormGroup;
  doctor: Doctor;
  pacientes: Paciente[];
  @ViewChild('myModalConf', {static: false}) myModalConf: TemplateRef<any>;

  constructor(private fb: FormBuilder, private doctorService: DoctorService, private paciService: PacienteService,
              private router: Router,
              private modalService: NgbModal) { }

  ngOnInit() {
    this.createRegisterForm();
    this.loadPacientes();
  }

  register() {
    if (this.registerForm.valid) {
      this.doctor = Object.assign({}, this.registerForm.value);
      this.doctorService.register(this.doctor).subscribe(() => {
        console.log('Registration successful');
        this.router.navigate(['/CRUDDoctores']);
        this.mostrarModalConf();
      }, error => {
        console.log(error);
      });
    }
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      nombreCompleto: ['', Validators.required],
      especialidad: ['', Validators.required],
      numeroCredencial: ['', Validators.required],
      hospitalTrabaja: ['', Validators.required]
    });
  }

  cancel() {
    console.log('Cancelled');
    this.createRegisterForm();
  }

  mostrarModalConf(){
    this.modalService.open(this.myModalConf).result.then( r => {
      console.log('Tu respuesta ha sido: ' + r);
    }, error => {
      console.log(error);
    });
  }

  loadPacientes() {
    this.paciService.getPacientes()
        .subscribe((res: Paciente[]) => {
          this.pacientes = res;
        }, error => {
          console.log(error);
        });
  }

  agregarQuitarSeleccion(id: number) {
    console.log(id);
  }

}
