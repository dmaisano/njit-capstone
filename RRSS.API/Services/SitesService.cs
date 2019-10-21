using RRSS.API.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace RRSS.API.Services
{
  public class SitesService
  {
    private readonly IMongoCollection<Site> _sites;

    public SitesService(ICapstoneDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _sites = database.GetCollection<Site>(settings.Collections[0]);
    }

    public List<Site> Get()
    {
      return _sites.Find(site => true).ToList();
    }

    public Site Get(string id)
    {
      return _sites.Find<Site>(site => site.id == id).FirstOrDefault();
    }

    public Site Create(Site site)
    {
      _sites.InsertOne(site);
      return site;
    }

    public void Update(string id, Site siteIn)
    {
      _sites.ReplaceOne<Site>(site => site.id == siteIn.id, siteIn);
    }

    public void Remove(Site siteIn)
    {
      _sites.DeleteOne<Site>(site => site.id == siteIn.id);
    }

    public void Remove(string id)
    {
      _sites.DeleteOne<Site>(site => site.id == id);
    }
  }
}