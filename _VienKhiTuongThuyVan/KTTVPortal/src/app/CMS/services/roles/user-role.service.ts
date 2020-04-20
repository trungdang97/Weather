import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { APP_CONFIG, IAppConfig } from 'src/app/app.config';
import { catchError } from 'rxjs/operators';
import { simpleErrorHandler } from 'src/app/_layout/utils/common-functions';
import { UserRoleFilter, UserRoleCreateRequestModel, UserRoleUpdateRequestModel } from './user-role.model';

@Injectable()

export class UserRoleService {
    private baseUrl: string;

    constructor(@Inject(APP_CONFIG) config: IAppConfig, private http: HttpClient) {
        this.baseUrl = config.apiEndpoint + 'api/v1/user_role/';
    }
    httpOptions: any = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    GetFilter(filter: UserRoleFilter) {
        //debugger;
        let route: string = this.baseUrl + 'filter?filter=' + JSON.stringify(filter);
        return this.http.get(route, this.httpOptions).pipe(
            catchError(simpleErrorHandler)
        );
    }

    Create(model: UserRoleCreateRequestModel) {
        // debugger;
        let route: string = this.baseUrl + 'create';
        return this.http.post(route, model, this.httpOptions).pipe(
            catchError(simpleErrorHandler)
        );
    }

    Update(model: UserRoleUpdateRequestModel) {
        let route: string = this.baseUrl + 'update';
        return this.http.put(route, model, this.httpOptions).pipe(
            catchError(simpleErrorHandler)
        );
    }

    Delete(id: string) {
        // debugger;
        let route: string = this.baseUrl + 'delete/' + id;
        return this.http.delete(route, this.httpOptions).pipe(
            catchError(simpleErrorHandler)
        );
    }

    DeleteMany(listId: Array<string>) {
        let route: string = this.baseUrl + 'deletemany';
        let option = this.httpOptions;
        option.body = listId;
        return this.http.request('delete', route, this.httpOptions).pipe(
            catchError(simpleErrorHandler)
        );
    }
}