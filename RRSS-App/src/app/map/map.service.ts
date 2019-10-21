import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Site } from "./map.model";

@Injectable({
  providedIn: "root",
})
export class MapService {
  baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = `${environment.api.url}/sites`;
  }

  foo(): void {
    console.log("foo");
  }

  getSites(): Observable<Site[]> {
    return this.http.get<Site[]>("http://localhost:5000/api/sites");
  }
}
