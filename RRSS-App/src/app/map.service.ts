import { Injectable } from "@angular/core";
import * as mapboxgl from "mapbox-gl";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class MapService {
  constructor() {
    (mapboxgl as typeof mapboxgl).accessToken = environment.mapbox.accessToken;
  }
}
