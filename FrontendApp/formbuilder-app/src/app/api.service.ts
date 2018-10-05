import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  tap, map
} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public apiHost = 'http://localhost:6895';
  constructor(private http: HttpClient) { }
  public configureAndConnect = (apiHost: string) =>
    this.http.get(apiHost + '/api/ping')
    .pipe(tap(() => this.apiHost = apiHost))
  private url = (relative) => this.apiHost + relative;
}
