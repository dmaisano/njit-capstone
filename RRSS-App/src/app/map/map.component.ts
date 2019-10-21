import { Component, OnInit } from "@angular/core";
import * as mapboxgl from "mapbox-gl";
import { MapService } from "./map.service";
import { Site } from "./map.model";
import { environment } from "src/environments/environment";
import { log } from "util";

@Component({
  selector: "app-map",
  templateUrl: "./map.component.html",
  styleUrls: ["./map.component.scss"],
})
export class MapComponent implements OnInit {
  map: mapboxgl.Map;
  style = "mapbox://styles/mapbox/streets-v11";
  // style = "mapbox://styles/mapbox/outdoors-v9";
  lat = 40.742789;
  lng = -74.179771;
  sites: Site[];

  constructor(private mapService: MapService) {
    (mapboxgl as typeof mapboxgl).accessToken = environment.mapbox.accessToken;
  }

  ngOnInit() {
    this.buildMap();

    this.mapService.getSites().subscribe({
      next: (sites) => {
        console.log(sites);
      },
    });
  }

  buildMap() {
    this.map = new mapboxgl.Map({
      container: "map",
      style: this.style,
      zoom: 13,
      center: [this.lng, this.lat],
    });

    /// Add map controls
    this.map.addControl(new mapboxgl.NavigationControl());
  }
}
