import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { APP_CONFIG, IAppConfig } from 'src/app/app.config';
import { catchError } from 'rxjs/operators';
import { simpleErrorHandler } from 'src/app/_layout/utils/common-functions';
import { NewsCategoryFilter, NewsCategoryCreateRequestModel, NewsCategoryUpdateRequestModel } from './newscategory.model';

@Injectable()


export class NewsCategoryService {
  private baseUrl: string;

  constructor(@Inject(APP_CONFIG) config: IAppConfig, private http: HttpClient) {
    this.baseUrl = config.apiEndpoint + 'api/v1/newscategory/';
  }
  httpOptions: any = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  GetFilter(filter: NewsCategoryFilter) {
    //debugger;
    let route: string = this.baseUrl + 'filter?filter=' + JSON.stringify(filter);
    return this.http.get(route, this.httpOptions).pipe(
      catchError(simpleErrorHandler)
    );
  }

  Create(model: NewsCategoryCreateRequestModel) {
    // debugger;
    let route: string = this.baseUrl + 'create';
    return this.http.post(route, model, this.httpOptions).pipe(
      catchError(simpleErrorHandler)
    );
  }

  Update(model: NewsCategoryUpdateRequestModel) {
    let route: string = this.baseUrl + 'update';
    return this.http.put(route, model, this.httpOptions).pipe(
      catchError(simpleErrorHandler)
    );
  }

  Delete(id) {
    // debugger;
    let route: string = this.baseUrl + 'delete/' + id;
    return this.http.delete(route, this.httpOptions).pipe(
      catchError(simpleErrorHandler)
    );
  }

  DeleteMany(listId) {
    let route: string = this.baseUrl + 'deletemany';
    let option = this.httpOptions;
    option.body = listId ;
    return this.http.request('delete', route, this.httpOptions).pipe(
      catchError(simpleErrorHandler)
    );
  }
}
