import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  tap
} from 'rxjs/operators';
import { User } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public apiHost = 'http://localhost:6895';
  constructor(private http: HttpClient) { }
  public configureAndConnect = (apiHost: string) =>
    this.http.get(apiHost + '/api/ping')
      .pipe(tap(() => this.apiHost = apiHost))
  public getAvailableTestAccounts = () => this.http.get<User[]>(this.url('/api/auth/testaccounts'));
  public getToken = (login, password) => this.http.post<{ token: string }>(this.url('/api/auth'), { login, password });
  private url = (relative) => this.apiHost + relative;
}
