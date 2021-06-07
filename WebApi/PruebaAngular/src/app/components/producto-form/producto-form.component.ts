import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductoService } from '../../services/producto.service';
import swal from'sweetalert2';
import { Producto } from 'src/app/models/Producto.model';


@Component({
  selector: 'app-producto-form',
  templateUrl: './producto-form.component.html',
  styleUrls: ['./producto-form.component.scss']
})
export class ProductoFormComponent implements OnInit {
  @Output() cerrarModal = new EventEmitter();
  @Input() producto: Producto = new Producto();
  validateForm: FormGroup;

  constructor(private fb: FormBuilder,
    private _productoService: ProductoService) {
    this.validateForm = this.fb.group({
      nombre: [null, [Validators.required]],
      descripcion: [null],
      precio: [null, [Validators.required]],
      restriccionedad: [null],
      compania: [null, [Validators.required]]
    });

    
  }

  ngOnInit(): void {
    if(this.producto.id > 0) {
      this.validateForm.controls.nombre.setValue(this.producto['nombre']);
      this.validateForm.controls.descripcion.setValue(this.producto['descripcion']);
      this.validateForm.controls.precio.setValue(this.producto['precio']);
      this.validateForm.controls.restriccionedad.setValue(this.producto['restriccionEdad']);
      this.validateForm.controls.compania.setValue(this.producto['compania']);
    }
  }

  Guardar() {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
    console.log(this.validateForm)
    if (this.validateForm.valid) {
      debugger
      let producto : Producto = this.validateForm.value;
      producto.id = this.producto.id;

      if(this.producto.id > 0) {
        this.EditarProducto(producto);
      } else {
        this.NuevoProducto(producto);
      }
    } else {
      return;
    }
  }

  NuevoProducto(producto: Producto) {
    this._productoService.GuardarProducto(producto).subscribe(response => {
      debugger
      if(response.isCompletedSuccessfully) {
        swal.fire({
          icon: 'success',
          text: 'Producto guadardo correctamente'
        }).then(result => {
          this.validateForm.reset();
          this.cerrarModal.emit();
        });
      } else {
        swal.fire({
          icon: 'error',
          text: response.errors.join('\n')
        });
      }
    });
  }

  EditarProducto(producto: Producto) {
    this._productoService.EditarProducto(producto).subscribe(response => {
      debugger
      if(response.isCompletedSuccessfully) {
        swal.fire({
          icon: 'success',
          text: 'Producto actualizado correctamente'
        }).then(result => {
          debugger
          this.validateForm.reset();
          this.cerrarModal.emit();
        });
      } else {
        swal.fire({
          icon: 'error',
          text: response.errors.join('\n')
        });
      }
    });
  }
}


