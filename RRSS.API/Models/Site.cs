using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace RRSS.API.Models
{
  public class Site
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    [BsonElement("ident")]
    public string ident { get; set; }

    public string type { get; set; }

    public string name { get; set; }

    public string latitude_deg { get; set; }

    public string longitude_deg { get; set; }

    public string iso_country { get; set; }

    public string iso_region { get; set; }

    public Site(string csvLine)
    {
      string[] values = csvLine.Split(',');

      this.ident = values[0];
      this.type = values[1];
      this.name = values[2];
      this.latitude_deg = values[3];
      this.longitude_deg = values[4];
      this.iso_country = values[5];
      this.iso_region = values[6];
    }
  }
}