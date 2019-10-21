export interface IGeometry {
  type: string;
  coordinates: number[];
}

export interface IGeoJson {
  type: string;
  geometry: IGeometry;
  properties?: any;
  $key?: string;
}

// Site conforms to the GeoJSON spec
export class Site implements IGeoJson {
  type = "Feature";
  geometry: IGeometry;

  constructor(coordinates: number[], public properties?) {
    this.geometry = {
      type: "Point",
      coordinates,
    };
  }
}

export class SiteCollection {
  type: "FeatureCollection";

  constructor(public features: Site[]) {}
}
