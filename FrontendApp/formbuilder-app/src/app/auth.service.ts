import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ApiService } from './api.service';
import { User } from './models/user';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/internal/operators/tap';
import { Router } from '@angular/router';
import { gettoken } from './shared.functions';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public get TestUsers(): Observable<User[]> {
    if (!this.testusers) {
      this.testusers = new BehaviorSubject<User[]>([]);
      this.api.getAvailableTestAccounts().subscribe(x => this.testusers.next(x));
    }
    return this.testusers;
  }
  private testusers: BehaviorSubject<User[]>;
  constructor(private api: ApiService, private router: Router) { }
  public jwtHelper = new JwtHelperService();
  public isAuthenticated(): boolean {
    return !this.jwtHelper.isTokenExpired(gettoken());
  }
  public getUserName() {
    const obj = this.jwtHelper.decodeToken(gettoken());
    return obj['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
  }

  public login = ({ login, password }) => this.api.authenticate(login, password)
    .pipe(tap(({ token }) => localStorage.setItem('token', token)))
  public logout = () => {
    localStorage.removeItem('token');
    this.router.navigate(['init']);
  }
}
