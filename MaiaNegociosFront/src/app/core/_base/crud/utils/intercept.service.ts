// Angular
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse } from '@angular/common/http';
// RxJS
import { Observable } from 'rxjs';
import { tap } from 'rxjs/internal/operators/tap';
import { Router } from '@angular/router';

/**
 * More information there => https://medium.com/@MetonymyQT/angular-http-interceptors-what-are-they-and-how-to-use-them-52e060321088
 */
@Injectable()
export class InterceptService implements HttpInterceptor {

	constructor(private router: Router) {}

	// intercept request and add token
	intercept(
		request: HttpRequest<any>,
		next: HttpHandler
	): Observable<HttpEvent<any>> {
		// tslint:disable-next-line:no-debugger
		// modify request
		if (localStorage.getItem('authce9d77b308c149d5992a80073637e4d5') !== null && request.url.indexOf('viacep.com.br') < 0){

			request = request.clone({
				setHeaders: {
					Authorization: `Bearer ${localStorage.getItem('authce9d77b308c149d5992a80073637e4d5')}`
				}
			});
			return next.handle(request).pipe(
				tap(
					event => {
							if (event instanceof HttpResponse) {
							// console.log('all looks good');
							// http response status code
							 //console.log(event.status);
						}
					},
					error => {
						if (error.status == 401){
							this.router.navigateByUrl('auth/login');
						}
					}
				)
			);
		} else {
			return next.handle(request.clone());
		}
	}
}
