import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { gettoken } from './shared.functions';
import { Observable, of, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
@Injectable()
export class BearerInterceptor implements HttpInterceptor {
  constructor(private router: Router) { }

  private handleError(err: HttpErrorResponse): Observable<any> {
    if (err.status === 401 || err.status === 403) {
      this.router.navigate(['access-denied']);
      return of(err.message);
    } else if (err.status === 500) {
      this.router.navigate(['oops']);
      return of(err.message);
    } else if (err.status === 404) {
      this.router.navigate(['notfound']);
      return of(err.message);
    }
    return throwError(err);
  }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${gettoken()}`
      }
    });
    if (request.headers.has('Skip-Prefix')) {
      const headers = request.headers.delete('Skip-Prefix');
      const directRequest = request.clone({ headers });
      return next.handle(directRequest);
    }
    return next.handle(request).pipe(catchError(x => this.handleError(x)));
  }
}
