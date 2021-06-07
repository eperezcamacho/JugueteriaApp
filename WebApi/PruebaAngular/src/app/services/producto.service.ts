import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Producto } from '../models/Producto.model';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private _httpClient: HttpClient) { }

  ObtenerProductos(): Observable<any> {
    return this._httpClient.get(environment.producto);
  }

  GuardarProducto(producto: Producto): Observable<any> {
    return this._httpClient.post(environment.producto, producto);
  }

  EditarProducto(producto: Producto): Observable<any> {
    return this._httpClient.put(environment.producto, producto);
  }

  EliminarProducto(producto: Producto): Observable<any> {
    return this._httpClient.delete(environment.producto + '/' + producto.id);
  }
}
