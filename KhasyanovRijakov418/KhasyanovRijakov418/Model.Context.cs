﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KhasyanovRijakov418
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        private static Entities _context;
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public static Entities GetContext()
        {
            if (_context == null)
                _context = new Entities();
            return _context;
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Storages> Storages { get; set; }
        public virtual DbSet<Waybill> Waybill { get; set; }
        public virtual DbSet<ListEntry> ListEntry { get; set; }
        public virtual DbSet<Product_in_Storage> Product_in_Storage { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
