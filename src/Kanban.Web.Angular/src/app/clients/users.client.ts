/* tslint:disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v11.17.3.0 (NJsonSchema v9.10.46.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import "rxjs/add/observable/fromPromise";
import "rxjs/add/observable/of";
import "rxjs/add/observable/throw";
import "rxjs/add/operator/map";
import "rxjs/add/operator/toPromise";
import "rxjs/add/operator/mergeMap";
import "rxjs/add/operator/catch";

import { Observable } from "rxjs/Observable";
import { Injectable, Inject, Optional, InjectionToken } from "@angular/core";
import {
  HttpClient,
  HttpHeaders,
  HttpParams,
  HttpResponse,
  HttpResponseBase,
  HttpErrorResponse
} from "@angular/common/http";
import { API_BASE_URL } from "../globals";

export interface IUsersClient {
  getByFilter(name: string | null | undefined): Observable<UserModel[] | null>;
  create(model: CreateUserModel | null): Observable<void>;
  getById(id: string): Observable<UserModel | null>;
  update(id: string, model: UpdateUserModel | null): Observable<void>;
  delete(id: string): Observable<void>;
}

@Injectable()
export class UsersClient implements IUsersClient {
  private http: HttpClient;
  private baseUrl: string;
  protected jsonParseReviver:
    | ((key: string, value: any) => any)
    | undefined = undefined;

  constructor(
    @Inject(HttpClient) http: HttpClient,
    @Optional()
    @Inject(API_BASE_URL)
    baseUrl?: string
  ) {
    this.http = http;
    this.baseUrl = baseUrl ? baseUrl : "";
  }

  getByFilter(name: string | null | undefined): Observable<UserModel[] | null> {
    let url_ = this.baseUrl + "/api/Users?";
    if (name !== undefined)
      url_ += "Name=" + encodeURIComponent("" + name) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_: any = {
      observe: "response",
      responseType: "blob",
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Accept: "application/json"
      })
    };

    return this.http
      .request("get", url_, options_)
      .flatMap((response_: any) => {
        return this.processGetByFilter(response_);
      })
      .catch((response_: any) => {
        if (response_ instanceof HttpResponseBase) {
          try {
            return this.processGetByFilter(<any>response_);
          } catch (e) {
            return <Observable<UserModel[] | null>>(<any>Observable.throw(e));
          }
        } else
          return <Observable<UserModel[] | null>>(<any>Observable.throw(
            response_
          ));
      });
  }

  protected processGetByFilter(
    response: HttpResponseBase
  ): Observable<UserModel[] | null> {
    const status = response.status;
    const responseBlob =
      response instanceof HttpResponse
        ? response.body
        : (<any>response).error instanceof Blob
          ? (<any>response).error
          : undefined;

    let _headers: any = {};
    if (response.headers) {
      for (let key of response.headers.keys()) {
        _headers[key] = response.headers.get(key);
      }
    }
    if (status === 200) {
      return blobToText(responseBlob).flatMap(_responseText => {
        let result200: any = null;
        let resultData200 =
          _responseText === ""
            ? null
            : JSON.parse(_responseText, this.jsonParseReviver);
        if (resultData200 && resultData200.constructor === Array) {
          result200 = [];
          for (let item of resultData200)
            result200.push(UserModel.fromJS(item));
        }
        return Observable.of(result200);
      });
    } else if (status !== 200 && status !== 204) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "An unexpected server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    }
    return Observable.of<UserModel[] | null>(<any>null);
  }

  create(model: CreateUserModel | null): Observable<void> {
    let url_ = this.baseUrl + "/api/Users";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(model);

    let options_: any = {
      body: content_,
      observe: "response",
      responseType: "blob",
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    };

    return this.http
      .request("post", url_, options_)
      .flatMap((response_: any) => {
        return this.processCreate(response_);
      })
      .catch((response_: any) => {
        if (response_ instanceof HttpResponseBase) {
          try {
            return this.processCreate(<any>response_);
          } catch (e) {
            return <Observable<void>>(<any>Observable.throw(e));
          }
        } else return <Observable<void>>(<any>Observable.throw(response_));
      });
  }

  protected processCreate(response: HttpResponseBase): Observable<void> {
    const status = response.status;
    const responseBlob =
      response instanceof HttpResponse
        ? response.body
        : (<any>response).error instanceof Blob
          ? (<any>response).error
          : undefined;

    let _headers: any = {};
    if (response.headers) {
      for (let key of response.headers.keys()) {
        _headers[key] = response.headers.get(key);
      }
    }
    if (status === 201) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return Observable.of<void>(<any>null);
      });
    } else if (status === 400) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "A server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    } else if (status !== 200 && status !== 204) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "An unexpected server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    }
    return Observable.of<void>(<any>null);
  }

  getById(id: string): Observable<UserModel | null> {
    let url_ = this.baseUrl + "/api/Users/{id}";
    if (id === undefined || id === null)
      throw new Error("The parameter 'id' must be defined.");
    url_ = url_.replace("{id}", encodeURIComponent("" + id));
    url_ = url_.replace(/[?&]$/, "");

    let options_: any = {
      observe: "response",
      responseType: "blob",
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Accept: "application/json"
      })
    };

    return this.http
      .request("get", url_, options_)
      .flatMap((response_: any) => {
        return this.processGetById(response_);
      })
      .catch((response_: any) => {
        if (response_ instanceof HttpResponseBase) {
          try {
            return this.processGetById(<any>response_);
          } catch (e) {
            return <Observable<UserModel | null>>(<any>Observable.throw(e));
          }
        } else
          return <Observable<UserModel | null>>(<any>Observable.throw(
            response_
          ));
      });
  }

  protected processGetById(
    response: HttpResponseBase
  ): Observable<UserModel | null> {
    const status = response.status;
    const responseBlob =
      response instanceof HttpResponse
        ? response.body
        : (<any>response).error instanceof Blob
          ? (<any>response).error
          : undefined;

    let _headers: any = {};
    if (response.headers) {
      for (let key of response.headers.keys()) {
        _headers[key] = response.headers.get(key);
      }
    }
    if (status === 200) {
      return blobToText(responseBlob).flatMap(_responseText => {
        let result200: any = null;
        let resultData200 =
          _responseText === ""
            ? null
            : JSON.parse(_responseText, this.jsonParseReviver);
        result200 = resultData200 ? UserModel.fromJS(resultData200) : <any>null;
        return Observable.of(result200);
      });
    } else if (status === 404) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "A server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    } else if (status !== 200 && status !== 204) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "An unexpected server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    }
    return Observable.of<UserModel | null>(<any>null);
  }

  update(id: string, model: UpdateUserModel | null): Observable<void> {
    let url_ = this.baseUrl + "/api/Users/{id}";
    if (id === undefined || id === null)
      throw new Error("The parameter 'id' must be defined.");
    url_ = url_.replace("{id}", encodeURIComponent("" + id));
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(model);

    let options_: any = {
      body: content_,
      observe: "response",
      responseType: "blob",
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    };

    return this.http
      .request("put", url_, options_)
      .flatMap((response_: any) => {
        return this.processUpdate(response_);
      })
      .catch((response_: any) => {
        if (response_ instanceof HttpResponseBase) {
          try {
            return this.processUpdate(<any>response_);
          } catch (e) {
            return <Observable<void>>(<any>Observable.throw(e));
          }
        } else return <Observable<void>>(<any>Observable.throw(response_));
      });
  }

  protected processUpdate(response: HttpResponseBase): Observable<void> {
    const status = response.status;
    const responseBlob =
      response instanceof HttpResponse
        ? response.body
        : (<any>response).error instanceof Blob
          ? (<any>response).error
          : undefined;

    let _headers: any = {};
    if (response.headers) {
      for (let key of response.headers.keys()) {
        _headers[key] = response.headers.get(key);
      }
    }
    if (status === 204) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return Observable.of<void>(<any>null);
      });
    } else if (status === 400) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "A server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    } else if (status === 404) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "A server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    } else if (status !== 200 && status !== 204) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "An unexpected server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    }
    return Observable.of<void>(<any>null);
  }

  delete(id: string): Observable<void> {
    let url_ = this.baseUrl + "/api/Users/{id}";
    if (id === undefined || id === null)
      throw new Error("The parameter 'id' must be defined.");
    url_ = url_.replace("{id}", encodeURIComponent("" + id));
    url_ = url_.replace(/[?&]$/, "");

    let options_: any = {
      observe: "response",
      responseType: "blob",
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    };

    return this.http
      .request("delete", url_, options_)
      .flatMap((response_: any) => {
        return this.processDelete(response_);
      })
      .catch((response_: any) => {
        if (response_ instanceof HttpResponseBase) {
          try {
            return this.processDelete(<any>response_);
          } catch (e) {
            return <Observable<void>>(<any>Observable.throw(e));
          }
        } else return <Observable<void>>(<any>Observable.throw(response_));
      });
  }

  protected processDelete(response: HttpResponseBase): Observable<void> {
    const status = response.status;
    const responseBlob =
      response instanceof HttpResponse
        ? response.body
        : (<any>response).error instanceof Blob
          ? (<any>response).error
          : undefined;

    let _headers: any = {};
    if (response.headers) {
      for (let key of response.headers.keys()) {
        _headers[key] = response.headers.get(key);
      }
    }
    if (status === 204) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return Observable.of<void>(<any>null);
      });
    } else if (status === 404) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "A server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    } else if (status !== 200 && status !== 204) {
      return blobToText(responseBlob).flatMap(_responseText => {
        return throwException(
          "An unexpected server error occurred.",
          status,
          _responseText,
          _headers
        );
      });
    }
    return Observable.of<void>(<any>null);
  }
}

export class UserModel implements IUserModel {
  id: string;
  name?: string | undefined;

  constructor(data?: IUserModel) {
    if (data) {
      for (var property in data) {
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }

  init(data?: any) {
    if (data) {
      this.id = data["id"];
      this.name = data["name"];
    }
  }

  static fromJS(data: any): UserModel {
    data = typeof data === "object" ? data : {};
    let result = new UserModel();
    result.init(data);
    return result;
  }

  toJSON(data?: any) {
    data = typeof data === "object" ? data : {};
    data["id"] = this.id;
    data["name"] = this.name;
    return data;
  }
}

export interface IUserModel {
  id: string;
  name?: string | undefined;
}

export class CreateUserModel implements ICreateUserModel {
  name: string;

  constructor(data?: ICreateUserModel) {
    if (data) {
      for (var property in data) {
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }

  init(data?: any) {
    if (data) {
      this.name = data["Name"];
    }
  }

  static fromJS(data: any): CreateUserModel {
    data = typeof data === "object" ? data : {};
    let result = new CreateUserModel();
    result.init(data);
    return result;
  }

  toJSON(data?: any) {
    data = typeof data === "object" ? data : {};
    data["Name"] = this.name;
    return data;
  }
}

export interface ICreateUserModel {
  name: string;
}

export class UpdateUserModel implements IUpdateUserModel {
  name: string;

  constructor(data?: IUpdateUserModel) {
    if (data) {
      for (var property in data) {
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }

  init(data?: any) {
    if (data) {
      this.name = data["Name"];
    }
  }

  static fromJS(data: any): UpdateUserModel {
    data = typeof data === "object" ? data : {};
    let result = new UpdateUserModel();
    result.init(data);
    return result;
  }

  toJSON(data?: any) {
    data = typeof data === "object" ? data : {};
    data["Name"] = this.name;
    return data;
  }
}

export interface IUpdateUserModel {
  name: string;
}

export class SwaggerException extends Error {
  message: string;
  status: number;
  response: string;
  headers: { [key: string]: any };
  result: any;

  constructor(
    message: string,
    status: number,
    response: string,
    headers: { [key: string]: any },
    result: any
  ) {
    super();

    this.message = message;
    this.status = status;
    this.response = response;
    this.headers = headers;
    this.result = result;
  }

  protected isSwaggerException = true;

  static isSwaggerException(obj: any): obj is SwaggerException {
    return obj.isSwaggerException === true;
  }
}

function throwException(
  message: string,
  status: number,
  response: string,
  headers: { [key: string]: any },
  result?: any
): Observable<any> {
  if (result !== null && result !== undefined) return Observable.throw(result);
  else
    return Observable.throw(
      new SwaggerException(message, status, response, headers, null)
    );
}

function blobToText(blob: any): Observable<string> {
  return new Observable<string>((observer: any) => {
    if (!blob) {
      observer.next("");
      observer.complete();
    } else {
      let reader = new FileReader();
      reader.onload = function() {
        observer.next(this.result);
        observer.complete();
      };
      reader.readAsText(blob);
    }
  });
}
