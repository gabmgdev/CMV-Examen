import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ClienteCreacionDto, ClienteCuentaDto, ClienteDto } from './ClienteDto';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  private apiUrl = environment.baseApiUrl + 'clientes';

  constructor(private http: HttpClient) { }

  public obtenerTodos(pagina: number, recordsPorPagina: number) {
    let params = new HttpParams();
    params = params.append('pagina', pagina.toString());
    params = params.append('recordsPorPagina', recordsPorPagina.toString());
    return this.http.get(this.apiUrl + '/paginacion', { observe: 'response', params });
  }

  public obtenerPorId(id: number): Observable<ClienteDto> {
    return this.http.get<ClienteDto>(`${this.apiUrl}/${id}`);
  }

  public crearCliente(cliente: ClienteCreacionDto) {
    return this.http.post(this.apiUrl, cliente, { responseType: 'text' });
  }

  public editarCliente(id: number, cliente: ClienteCreacionDto) {
    return this.http.put(`${this.apiUrl}/${id}`, cliente, { responseType: 'text' });
  }

  public eliminarCliente(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`, { responseType: 'text' });
  }

  public obtenerCuentasDeCliente(id: number) {
    return this.http.get<ClienteCuentaDto[]>(`${this.apiUrl}/${id}/cuentas`);
  }
}
