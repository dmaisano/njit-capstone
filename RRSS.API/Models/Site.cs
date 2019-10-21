using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;


namespace RRSS.API.Models
{
  public class Site
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    // ? intended to make this property readonly, however it does not get serialized by MongoDB
    public string type { get; set; }

    public SiteGeometry geometry { get; set; }

    public SiteProperties properties { get; set; }

    public Site(string ident, string type, string name, double latitude_deg, double longitude_deg, string iso_country, string iso_region)
    {
      this.type = "Feature";

      this.geometry = new SiteGeometry(latitude_deg, longitude_deg);

      this.properties = new SiteProperties
      {
        ident = ident,
        type = type,
        name = name,
        latitude_deg = latitude_deg,
        longitude_deg = longitude_deg,
        iso_country = iso_country,
        iso_region = iso_region,
      };
    }
  }

  public class SiteGeometry
  {
    public string type { get; set; }

    public double[] coordinates;

    public SiteGeometry(double latitude_deg, double longitude_deg)
    {
      this.type = "Point";
      this.coordinates = new double[2];

      this.coordinates[0] = latitude_deg;
      this.coordinates[1] = longitude_deg;
    }
  }

  public class SiteProperties
  {
    public string ident { get; set; }

    public string type { get; set; }

    public string name { get; set; }

    public double latitude_deg { get; set; }

    public double longitude_deg { get; set; }

    public string iso_country { get; set; }

    public string iso_region { get; set; }
  }
}