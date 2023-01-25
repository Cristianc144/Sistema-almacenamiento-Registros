import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistroService {
  private myAppUrl = 'https://localhost:44379/'
  private myApiUrl = 'api/Registros/'
  constructor(private http: HttpClient) { }

  getListRegistros(): Observable<any>{
    return this.http.get(this.myAppUrl + this.myApiUrl)
  }
  deleteRegistro(id: number): Observable<any>{
    return this.http.delete(this.myAppUrl + this.myApiUrl + id)
  }
  saveRegistro(registro: any): Observable<any>{
    return this.http.post(this.myAppUrl + this.myApiUrl, registro)
  }
  updateRegistro(id: number, registro: any): Observable<any> {
    return this.http.put(this.myAppUrl + this.myApiUrl + id, registro)
  }
}
