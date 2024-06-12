using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using assessment_platform_developer.Models;


namespace assessment_platform_developer.Data
{
    public class CustomerDBContext : DbContext
    {
          public DbSet<Customer> Customers { get; set; }

    }

}