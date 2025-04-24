using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Project.API
{
  // RDS_DB_NAME, RDS_USERNAME, RDS_PASSWORD, RDS_HOSTNAME, RDS_PORT
  public class Helpers
  {
    public static string? GetRDSConnectionString(IDictionary environmentVariables)
    {
      string? dbname = (string?)environmentVariables["RDS_DB_NAME"];

      if (string.IsNullOrEmpty(dbname)) return null;

      string? username = (string?)environmentVariables["RDS_USERNAME"];
      string? password = (string?)environmentVariables["RDS_PASSWORD"];
      string? hostname = (string?)environmentVariables["RDS_HOSTNAME"];
      string? port = (string?)environmentVariables["RDS_PORT"];

      return "Server=" + hostname + ";Port="+port+";Database=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
    }
  }
}
