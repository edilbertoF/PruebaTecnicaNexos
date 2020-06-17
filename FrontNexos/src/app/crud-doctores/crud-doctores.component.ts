import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-crud-doctores',
  templateUrl: './crud-doctores.component.html',
  styleUrls: ['./crud-doctores.component.css']
})
export class CrudDoctoresComponent implements OnInit {
  radio: number;

  constructor() { }

  ngOnInit() {
  }

  registrar() {
    this.radio = 1;
  }

}
