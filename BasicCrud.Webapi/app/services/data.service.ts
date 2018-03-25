﻿import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { UserSessionService } from '../services/userSession.service';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class DataService {
    constructor(private _http: Http, private _userSessionService: UserSessionService) { }

    get(url: string): Observable<any> {
        let headers = new Headers({'Authorization': this._userSessionService.getUserToken() });
        let options = new RequestOptions({ headers: headers });
        return this._http.get(url, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    post(url: string, model: any): Observable<any> {
        let body = JSON.stringify(model);
        let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': this._userSessionService.getUserToken() });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(url, body, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}