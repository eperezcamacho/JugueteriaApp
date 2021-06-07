import { Component, ElementRef, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { ProductoService } from '../../services/producto.service';
import { ProductoFormComponent } from '../../components/producto-form/producto-form.component';

import swal from'sweetalert2';
import { Producto } from 'src/app/models/Producto.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  productos = null;
  //@ViewChild('modalMensaje', { static: true }) modal: ElementRef;
  bsModalRef: BsModalRef = new BsModalRef;
  producto:Producto = new Producto;

  constructor(private _productoService: ProductoService,
    private modalService: BsModalService) {
    
  }

  ngOnInit() {
    this.ObtenerProductos();
  }

  ObtenerProductos() {
    this._productoService.ObtenerProductos().subscribe(response => {
      this.productos = response;
      console.log('Productos', this.productos);
      
    });
  }

  OpenProductModal() {
    this.bsModalRef = this.modalService.show(ProductoFormComponent);
    this.bsModalRef.content.closeBtnName = 'Close';
  }

  GuardarProducto() {
    swal.fire({
      title: 'Hola',
      html: '<app-producto-form></app-producto-form>'
    })
  }

  openModal(template: TemplateRef<any>) {
    this.bsModalRef = this.modalService.show(template);
  }

  openModalProduct(template: TemplateRef<any>, producto: Producto) {
    this.bsModalRef = this.modalService.show(template);
    this.producto = producto;
  }

  cerrarModal(){
    debugger
    this.bsModalRef.hide();
    
    this.ObtenerProductos();
  }

  EliminarProducto(producto: Producto) {
    swal.fire({
      title: '¡Atención!',
      text: 'Estás a punto de eliminar el producto. ¿Estás seguro de continuar?',
      icon: 'error',
      showCancelButton: true,
      cancelButtonText: 'No, cancelar.',
      confirmButtonText: 'Sí, eliminar.',
    }).then((result) => {
      if(result.value) {
        this._productoService.EliminarProducto(producto).subscribe(response => {
          debugger
          if(response) {
            swal.fire({
              icon: 'success',
              text: 'Producto eliminado correctamente'
            }).then(result => {
              this.ObtenerProductos();
            });
          } else {
            swal.fire({
              icon: 'error',
              text: 'No se ha podido eliminar el producto'
            });
          }
        });
      } else {
        
      }
    });
  }
}
