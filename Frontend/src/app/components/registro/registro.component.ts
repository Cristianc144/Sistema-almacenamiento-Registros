import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { RegistroService } from 'src/app/services/registro.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent {
  listRegistros : any[] = []
  action = 'Agregar'
  form: FormGroup;
  id: number | undefined

  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private _registroService: RegistroService){
    this.form = this.fb.group({
      nombres: ['', Validators.required],
      apellidos: ['', Validators.required],
      edad: ['', Validators.required],
      titulo: ['', Validators.required],
      ciudad: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.obtenerRegistros()
  }

  obtenerRegistros(){
    this._registroService.getListRegistros().subscribe(data => {
      console.log(data);
      this.listRegistros = data
    }, error => {
      console.log(error);
      
    })
  }

  guardarRegistro(){
    const registro: any = {
      nombres: this.form.get('nombres')?.value,
      apellidos: this.form.get('apellidos')?.value,
      edad: this.form.get('edad')?.value,
      titulo: this.form.get('titulo')?.value,
      ciudad: this.form.get('ciudad')?.value
    }
    if(this.id === undefined) {
      this._registroService.saveRegistro(registro).subscribe(data => {
        this.toastr.success('El usuario fue registrado con éxito!', 'Usuario Registrado!');
        this.obtenerRegistros()
        this.form.reset()
      }, error => {
        this.toastr.error('Ocurrió un error', 'ERROR')
        console.log(error);
      })  
    }else{
      registro.id = this.id
      this._registroService.updateRegistro(this.id, registro).subscribe(data => {
        this.form.reset()
        this.action = 'Agregar'
        this.id = undefined
        this.toastr.info("El usuario fue actualizado", "Usuario actualizado")
        this.obtenerRegistros()
      }, error => {
        console.log(error);
      })
    }

  }

  eliminarRegistro(id: number){
    this._registroService.deleteRegistro(id).subscribe(data => {
      this.toastr.error('El usuario fue eliminado con éxito!', 'Usuario Eliminado!')
      this.obtenerRegistros()
    }, error => {
      console.log(error);   
    }) 
  }
  editarRegistro(registro: any){
    this.action = 'Editar'
    this.id = registro.id
    this.form.patchValue({
      nombres: registro.nombres,
      apellidos: registro.apellidos,
      edad: registro.edad,
      titulo: registro.titulo,
      ciudad: registro.ciudad
    })
    
  }
}
