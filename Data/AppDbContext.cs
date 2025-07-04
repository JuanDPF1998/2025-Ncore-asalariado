﻿using _2025_NetCore_Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace _2025_NetCore_Empleados.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Empleados> empleadosDbSet { get; set; }
    }
}
