﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModellenBureau.Models;

namespace ModellenBureau.Data
{
    public class ApplicationDbContext : IdentityDbContext<ASL>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ModelUser> ModelUser { get; set; }
        public DbSet<CustomerUser> CustomerUser { get; set; }


    }
}
