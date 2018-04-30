import { InjectionToken } from "@angular/core";
import { HttpHeaders } from "@angular/common/http";

export const API_BASE_URL = new InjectionToken("API_BASE_URL");
export const httpOptions = {
  headers: new HttpHeaders({
    "Content-Type": "application/json"
  })
};
