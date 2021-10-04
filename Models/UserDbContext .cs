using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using WebTeste.Migrations;

namespace WebTeste.Models
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
    }
}