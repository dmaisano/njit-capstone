import { Component, OnInit } from "@angular/core";
import * as mapboxgl from "mapbox-gl";
import { MapService } from "../map.service";
import { environment } from "src/environments/environment";

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

  constructor(private mapService: MapService) {}

  ngOnInit() {
    this.buildMap();
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
