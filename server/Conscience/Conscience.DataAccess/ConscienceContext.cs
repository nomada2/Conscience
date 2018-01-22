﻿using Conscience.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conscience.DataAccess
{
    public class ConscienceContext : DbContext
    {
        public ConscienceContext() : base("ConscienceDB")
        {
        }

        public DbSet<ConscienceAccount> Accounts
        {
            get;
            set;
        }

        public DbSet<Role> Roles
        {
            get;
            set;
        }

        public DbSet<Host> Hosts
        {
            get;
            set;
        }

        public DbSet<Employee> Employees
        {
            get;
            set;
        }


        public DbSet<Device> Devices
        {
            get;
            set;
        }

        public DbSet<Location> Locations
        {
            get;
            set;
        }

        public DbSet<Character> Characters
        {
            get;
            set;
        }

        public DbSet<Memory> Memories
        {
            get;
            set;
        }

        public DbSet<CoreMemory> CoreMemories
        {
            get;
            set;
        }

        public DbSet<Plot> Plots
        {
            get;
            set;
        }

        public DbSet<Notification> Notifications
        {
            get;
            set;
        }

        public DbSet<Audio> Audios
        {
            get;
            set;
        }

        public DbSet<LogEntry> LogEntries
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasMany(a => a.Roles).WithMany(r => r.Accounts);
            modelBuilder.Entity<Account>().HasOptional(u => u.Device);
            modelBuilder.Entity<Device>().HasMany(d => d.Locations);
            modelBuilder.Entity<Employee>().HasRequired(e => e.Account).WithOptional(a => a.Employee);
            modelBuilder.Entity<Host>().HasRequired(e => e.Account).WithOptional(a => a.Host);
            modelBuilder.Entity<Host>().HasMany(h => h.Stats).WithRequired(s => s.Host);
            modelBuilder.Entity<Host>().HasOptional(h => h.CoreMemory1);
            modelBuilder.Entity<Host>().HasOptional(h => h.CoreMemory2);
            modelBuilder.Entity<Host>().HasOptional(h => h.CoreMemory3);
            modelBuilder.Entity<Host>().HasMany(h => h.Characters).WithOptional(c => c.Host);
            modelBuilder.Entity<Host>().HasMany(h => h.HiddenHostAdministrators).WithMany(e => e.HiddenHosts);
            modelBuilder.Entity<CoreMemory>().HasRequired(c => c.Audio);
            modelBuilder.Entity<CharacterInHost>().HasRequired(c => c.Character).WithMany(c => c.Hosts);
            modelBuilder.Entity<Character>().HasMany(c => c.Memories).WithRequired(m => m.Character).WillCascadeOnDelete();
            modelBuilder.Entity<Character>().HasMany(c => c.Triggers).WithRequired(m => m.Character).WillCascadeOnDelete();
            modelBuilder.Entity<Character>().HasMany(c => c.Relations).WithRequired(r => r.ParentCharacter).HasForeignKey(r => r.ParentCharacterId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Character>().HasMany(c => c.Plots).WithRequired(p => p.Character).HasForeignKey(p => p.CharacterId).WillCascadeOnDelete();
            modelBuilder.Entity<CharacterRelation>().HasRequired(r => r.Character);
            modelBuilder.Entity<Plot>().HasMany(c => c.Events).WithRequired(e => e.Plot);
            modelBuilder.Entity<Plot>().HasMany(c => c.Characters).WithRequired(c => c.Plot).HasForeignKey(c => c.PlotId).WillCascadeOnDelete();
            modelBuilder.Entity<Plot>().HasOptional(c => c.Writer);
            modelBuilder.Entity<LogEntry>().HasOptional(c => c.Host);
            modelBuilder.Entity<LogEntry>().HasOptional(c => c.Employee);
            modelBuilder.Entity<Notification>().HasRequired(c => c.Owner);
            modelBuilder.Entity<Notification>().HasOptional(c => c.Host);
            modelBuilder.Entity<Notification>().HasOptional(c => c.Employee);
            modelBuilder.Entity<Notification>().HasOptional(c => c.Audio);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
