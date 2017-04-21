﻿using Conscience.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Conscience.DataAccess.Repositories
{
    public class AccountRepository : BaseRepository<ConscienceAccount>
    {
        public AccountRepository(ConscienceContext context) : base(context)
        {
        }

        protected override IDbSet<ConscienceAccount> DbSet
        {
            get
            {
                return _context.Accounts;
            }
        }

        public Account GetById(int accountId)
        {
            var account = DbSet.Include(a => a.Host).Include(a => a.Employee).Where(a => a.Id == accountId).ToList().FirstOrDefault();
            if (account == null)
                throw new ArgumentException("There is no account with id: " + accountId);
            return account;
        }

        public IQueryable<Account> GetAllHosts(Account currentUser)
        {
            return DbSet.Where(a => a.Host != null);
        }

        public IQueryable<Account> GetAllEmployees()
        {
            return DbSet.Where(a => a.Employee != null);
        }

        public Account AddRole(int accountId, RoleTypes role)
        {
            var account = DbSet.First(a => a.Id == accountId);
            var roleToAdd = _context.Roles.First(r => r.Name == role.ToString());
            account.Roles.Add(roleToAdd);
            _context.SaveChanges();
            return account;
        }

        public void UpdateDevice(Account account, string deviceId)
        {
            if (account.Device == null)
            {
                account.Device = new Device();
                _context.Devices.Add(account.Device);
            }

            account.Device.DeviceId = deviceId;
            account.Device.Online = true;
            account.Device.LastConnection = DateTime.Now;
            _context.SaveChanges();
        }

        public Account UpdateLocations(int accountId, List<Location> locations)
        {
            var account = GetById(accountId);
            account.Device.Locations.AddRange(locations);
            account.Device.LastConnection = DateTime.Now;
            _context.SaveChanges();
            return account;
        }

        public void UserDisconnected(Account account)
        {
            if (account.Device != null)
            {
                account.Device.Online = false;
                _context.SaveChanges();
            }
        }
    }
}
