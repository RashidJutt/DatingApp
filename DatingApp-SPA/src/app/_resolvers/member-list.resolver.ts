import { Injectable } from '@angular/core';
import { User } from '../_models/user';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class MemberListResolver implements Resolve<User[]> {
    constructor(
        private userService: UserService,
        private rout: Router,
        private notify: AlertifyService
    ) { }

    resolve(rout: ActivatedRouteSnapshot): Observable<User[]> {
        return this.userService.getUsers().pipe(
            catchError(error => {
                this.notify.error('Error in fetching data');
                this.rout.navigate(['/home']);
                return of(null);
            })

        );
    }
}
