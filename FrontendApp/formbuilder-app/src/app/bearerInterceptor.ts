import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { gettoken } from './shared.functions';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
@Injectable()
export class BearerInterceptor implements HttpInterceptor {
  constructor(private router: Router) { }

    private handleAuthError(err: HttpErrorResponse): Observable<any> {
        if (err.status === 401 || err.status === 403) {
            this.router.navigate(['access-denied']);
            return of(err.message);
        }
        return Observable.throw(err);
    }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${gettoken()}`
      }
    });
    return next.handle(request).pipe(catchError(x => this.handleAuthError(x)));
  }
}
