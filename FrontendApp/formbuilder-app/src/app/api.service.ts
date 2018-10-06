import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  tap
} from 'rxjs/operators';
import { User } from './models/user';
import { FormDefinition } from './models/formDefinition';
import { ObjectList } from './models/objectList';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public apiHost = 'http://localhost:6895';
  private skipInterceptor = {
    headers: {
      'Skip-Prefix': 'yes'
    }
  };
  constructor(private http: HttpClient) { }
  public configureAndConnect = (apiHost: string) =>
    this.http.get(apiHost + '/api/ping', this.skipInterceptor)
      .pipe(tap(() => this.apiHost = apiHost))
  public getAvailableTestAccounts = () => this.http.get<User[]>(this.url('/api/auth/testaccounts'), this.skipInterceptor);
  public authenticate = (login, password) => this.http.post<{ token: string }>(
    this.url('/api/auth'),
    { login, password },
    this.skipInterceptor)
  public saveForm = (formDefinitionId, formObj) => this.http.post(
    this.url('/api/values/' + formDefinitionId),
    formObj)
  private url = (relative) => this.apiHost + relative;
  public getFormDefinitions = () => this.http.get<FormDefinition[]>(this.url('/api/metadata'));
  public getFormDefinition = (id) => this.http.get<FormDefinition>(this.url('/api/metadata/' + id));
  public getObjects = (id) => this.http.get<ObjectList>(this.url('/api/values/' + id));

}
