/* tslint:disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v11.17.2.0 (NJsonSchema v9.10.45.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
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

export const API_BASE_URL = new InjectionToken("API_BASE_URL");

export interface IProjectsClient {
  getProjects(
    name: string | null | undefined,
    description: string | null | undefined,
    status: ProjectStatus | null | undefined
  ): Observable<Project[] | null>;
  createProject(
    model: CreateProjectModel | null
  ): Observable<FileResponse | null>;
  getProjectById(id: string): Observable<FileResponse | null>;
  put(
    id: string,
    model: UpdateProjectModel | null
  ): Observable<FileResponse | null>;
  delete(id: string): Observable<FileResponse | null>;
}

@Injectable()
export class ProjectsClient implements IProjectsClient {
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

  getProjects(
    name: string | null | undefined,
    description: string | null | undefined,
    status: ProjectStatus | null | undefined
  ): Observable<Project[] | null> {
    let url_ = this.baseUrl + "/api/Projects?";
    if (name !== undefined)
      url_ += "Name=" + encodeURIComponent("" + name) + "&";
    if (description !== undefined)
      url_ += "Description=" + encodeURIComponent("" + description) + "&";
    if (status !== undefined)
      url_ += "Status=" + encodeURIComponent("" + status) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_: any = {
      observe: "response",
      responseType: "blob",
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Accept: "application/json"
      })
    };

    return this.http.get(url_).map(x => {
      return <Project[]>x;
    });
  }

  createProject(
    model: CreateProjectModel | null
  ): Observable<FileResponse | null> {
    let url_ = this.baseUrl + "/api/Projects";
    url_ = url_.replace(/[?&]$/, "");

    const content_ = JSON.stringify(model);

    let options_: any = {
      body: content_,
      observe: "response",
      responseType: "blob",
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Accept: "application/json"
      })
    };

    return this.http
      .request("post", url_, options_)
      .flatMap((response_: any) => {
        return this.processCreateProject(response_);
      })
      .catch((response_: any) => {
        if (response_ instanceof HttpResponseBase) {
          try {
            return this.processCreateProject(<any>response_);
          } catch (e) {
            return <Observable<FileResponse | null>>(<any>Observable.throw(e));
          }
        } else
          return <Observable<FileResponse | null>>(<any>Observable.throw(
            response_
          ));
      });
  }

  protected processCreateProject(
    response: HttpResponseBase
  ): Observable<FileResponse | null> {
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
    if (status === 200 || status === 206) {
      const contentDisposition = response.headers
        ? response.headers.get("content-disposition")
        : undefined;
      const fileNameMatch = contentDisposition
        ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition)
        : undefined;
      const fileName =
        fileNameMatch && fileNameMatch.length > 1
          ? fileNameMatch[1]
          : undefined;
      return Observable.of({
        fileName: fileName,
        data: <any>responseBlob,
        status: status,
        headers: _headers
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
    return Observable.of<FileResponse | null>(<any>null);
  }

  getProjectById(id: string): Observable<FileResponse | null> {
    let url_ = this.baseUrl + "/api/Projects/{id}";
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
        return this.processGetProjectById(response_);
      })
      .catch((response_: any) => {
        if (response_ instanceof HttpResponseBase) {
          try {
            return this.processGetProjectById(<any>response_);
          } catch (e) {
            return <Observable<FileResponse | null>>(<any>Observable.throw(e));
          }
        } else
          return <Observable<FileResponse | null>>(<any>Observable.throw(
            response_
          ));
      });
  }

  protected processGetProjectById(
    response: HttpResponseBase
  ): Observable<FileResponse | null> {
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
    if (status === 200 || status === 206) {
      const contentDisposition = response.headers
        ? response.headers.get("content-disposition")
        : undefined;
      const fileNameMatch = contentDisposition
        ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition)
        : undefined;
      const fileName =
        fileNameMatch && fileNameMatch.length > 1
          ? fileNameMatch[1]
          : undefined;
      return Observable.of({
        fileName: fileName,
        data: <any>responseBlob,
        status: status,
        headers: _headers
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
    return Observable.of<FileResponse | null>(<any>null);
  }

  put(
    id: string,
    model: UpdateProjectModel | null
  ): Observable<FileResponse | null> {
    let url_ = this.baseUrl + "/api/Projects/{id}";
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
        "Content-Type": "application/json",
        Accept: "application/json"
      })
    };

    return this.http
      .request("put", url_, options_)
      .flatMap((response_: any) => {
        return this.processPut(response_);
      })
      .catch((response_: any) => {
        if (response_ instanceof HttpResponseBase) {
          try {
            return this.processPut(<any>response_);
          } catch (e) {
            return <Observable<FileResponse | null>>(<any>Observable.throw(e));
          }
        } else
          return <Observable<FileResponse | null>>(<any>Observable.throw(
            response_
          ));
      });
  }

  protected processPut(
    response: HttpResponseBase
  ): Observable<FileResponse | null> {
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
    if (status === 200 || status === 206) {
      const contentDisposition = response.headers
        ? response.headers.get("content-disposition")
        : undefined;
      const fileNameMatch = contentDisposition
        ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition)
        : undefined;
      const fileName =
        fileNameMatch && fileNameMatch.length > 1
          ? fileNameMatch[1]
          : undefined;
      return Observable.of({
        fileName: fileName,
        data: <any>responseBlob,
        status: status,
        headers: _headers
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
    return Observable.of<FileResponse | null>(<any>null);
  }

  delete(id: string): Observable<FileResponse | null> {
    let url_ = this.baseUrl + "/api/Projects/{id}";
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
      .request("delete", url_, options_)
      .flatMap((response_: any) => {
        return this.processDelete(response_);
      })
      .catch((response_: any) => {
        if (response_ instanceof HttpResponseBase) {
          try {
            return this.processDelete(<any>response_);
          } catch (e) {
            return <Observable<FileResponse | null>>(<any>Observable.throw(e));
          }
        } else
          return <Observable<FileResponse | null>>(<any>Observable.throw(
            response_
          ));
      });
  }

  protected processDelete(
    response: HttpResponseBase
  ): Observable<FileResponse | null> {
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
    if (status === 200 || status === 206) {
      const contentDisposition = response.headers
        ? response.headers.get("content-disposition")
        : undefined;
      const fileNameMatch = contentDisposition
        ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition)
        : undefined;
      const fileName =
        fileNameMatch && fileNameMatch.length > 1
          ? fileNameMatch[1]
          : undefined;
      return Observable.of({
        fileName: fileName,
        data: <any>responseBlob,
        status: status,
        headers: _headers
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
    return Observable.of<FileResponse | null>(<any>null);
  }
}

export enum ProjectStatus {
  Active = "Active",
  Inactive = "Inactive"
}

export class CreateProjectModel implements ICreateProjectModel {
  name?: string | undefined;
  description?: string | undefined;
  status: ProjectStatus;

  constructor(data?: ICreateProjectModel) {
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
      this.description = data["Description"];
      this.status = data["Status"];
    }
  }

  static fromJS(data: any): CreateProjectModel {
    data = typeof data === "object" ? data : {};
    let result = new CreateProjectModel();
    result.init(data);
    return result;
  }

  toJSON(data?: any) {
    data = typeof data === "object" ? data : {};
    data["Name"] = this.name;
    data["Description"] = this.description;
    data["Status"] = this.status;
    return data;
  }
}

export interface ICreateProjectModel {
  name?: string | undefined;
  description?: string | undefined;
  status: ProjectStatus;
}

export class UpdateProjectModel implements IUpdateProjectModel {
  name?: string | undefined;
  description?: string | undefined;
  status: ProjectStatus;

  constructor(data?: IUpdateProjectModel) {
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
      this.description = data["Description"];
      this.status = data["Status"];
    }
  }

  static fromJS(data: any): UpdateProjectModel {
    data = typeof data === "object" ? data : {};
    let result = new UpdateProjectModel();
    result.init(data);
    return result;
  }

  toJSON(data?: any) {
    data = typeof data === "object" ? data : {};
    data["Name"] = this.name;
    data["Description"] = this.description;
    data["Status"] = this.status;
    return data;
  }
}

export interface IUpdateProjectModel {
  name?: string | undefined;
  description?: string | undefined;
  status: ProjectStatus;
}

export interface FileResponse {
  data: Blob;
  status: number;
  fileName?: string;
  headers?: { [name: string]: any };
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

//todo

export class Project {
  id: string;
  name: string;
  description: string;
  status: ProjectStatus;
}