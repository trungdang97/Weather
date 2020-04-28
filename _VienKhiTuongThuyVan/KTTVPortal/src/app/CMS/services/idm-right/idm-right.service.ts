import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { APP_CONFIG, IAppConfig } from 'src/app/app.config';
import { catchError } from 'rxjs/operators';
import { simpleErrorHandler } from 'src/app/_layout/utils/common-functions';
import { IdmRightFilter, IdmRightCreateRequestModel, IdmRightUpdateRequestModel } from './idm-right.model';

@Injectable()

export class IdmRightService {
    private baseUrl: string;

    constructor(@Inject(APP_CONFIG) config: IAppConfig, private http: HttpClient) {
        this.baseUrl = config.apiEndpoint + 'api/v1/idm_right/';
    }
    httpOptions: any = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    GetFilter(filter: IdmRightFilter) {
        //debugger;
        let route: string = this.baseUrl + 'filter?filter=' + JSON.stringify(filter);
        return this.http.get(route, this.httpOptions).pipe(
            catchError(simpleErrorHandler)
        );
    }

    Create(model: IdmRightCreateRequestModel) {
        // debugger;
        let route: string = this.baseUrl + 'create';
        return this.http.post(route, model, this.httpOptions).pipe(
            catchError(simpleErrorHandler)
        );
    }

    Update(model: IdmRightUpdateRequestModel) {
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

    IsRightCodeExist(rightCode: string){
        let route: string = this.baseUrl + 'exist?rightCode=' + rightCode;
        return this.http.get(route, this.httpOptions).pipe(
            catchError(simpleErrorHandler)
        );
    }
}