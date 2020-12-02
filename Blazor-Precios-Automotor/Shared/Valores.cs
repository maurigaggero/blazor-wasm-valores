using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_Precios_Automotor.Shared
{
    public class Valores
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Version { get; set; }
        public string Moneda { get; set; }
        public string Okm { get; set; }
        public string Año2019 { get; set; }
        public string Año2018 { get; set; }
        public string Año2017 { get; set; }
        public string Año2016 { get; set; }
        public string Año2015 { get; set; }
        public string Año2014 { get; set; }
        public string Año2013 { get; set; }
        public string Año2012 { get; set; }
        public string Año2011 { get; set; }
        public string Año2010 { get; set; }
        public string Año2009 { get; set; }
        public string Año2008 { get; set; }
        public string Año2007 { get; set; }
        public string Año2006 { get; set; }
        public string Año2005 { get; set; }
    }

    public class ValoresContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = valoresDb; Integrated Security = True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Valores> Valores { get; set; }
    }
}
