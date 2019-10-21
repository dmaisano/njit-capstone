using System.Collections.Generic;

namespace RRSS.API.Models
{
  public class CapstoneDatabaseSettings : ICapstoneDatabaseSettings
  {
    public string[] Collections { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }

  public interface ICapstoneDatabaseSettings
  {
    string[] Collections { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }

}