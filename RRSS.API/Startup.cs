using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using RRSS.API.Models;
using RRSS.API.Services;

using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace RRSS.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;

      // task to check if DB collection exists, if not create create and populate with CSV data
      try
      {
        var collectionName = configuration["CapstoneDatabaseSettings:Collections:0"];

        var client = new MongoClient(configuration["CapstoneDatabaseSettings:ConnectionString"]);
        var db = client.GetDatabase(configuration["CapstoneDatabaseSettings:DatabaseName"]);

        var filter = new BsonDocument("name", collectionName);
        var options = new ListCollectionNamesOptions { Filter = filter };

        // collection DNE
        if (!db.ListCollectionNames(options).Any())
        {
          db.CreateCollection(collectionName);
        }

        var airportsCollection = db.GetCollection<Site>(collectionName);

        // no documents in collection
        if (airportsCollection.AsQueryable().Count() < 1)
        {
          // TODO: possibly make this task async
          // using (StreamReader file = File.OpenText("./data/airports.json"))
          // using (JsonTextReader reader = new JsonTextReader(file))
          // {
          //   JObject o2 = (JObject)JToken.ReadFrom(reader);
          // }

          // List<Site> airports = File.ReadAllLines("./data/airports.csv", Encoding.UTF8).Skip(1).Select(line => new Site(line)).ToList();

          // airportsCollection.InsertMany(airports);
        }
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e);
        System.Environment.Exit(-1);
      }
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // requires using Microsoft.Extensions.Options
      services.Configure<CapstoneDatabaseSettings>(
          Configuration.GetSection(nameof(CapstoneDatabaseSettings)));

      services.AddSingleton<ICapstoneDatabaseSettings>(sp =>
          sp.GetRequiredService<IOptions<CapstoneDatabaseSettings>>().Value);

      services.AddSingleton<SitesService>();

      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
