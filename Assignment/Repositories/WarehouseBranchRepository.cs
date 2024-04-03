using Assignment.DataBaseAccess;
using Assignment.Interfaces;
using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repositories
{
    public class WarehouseBranchRepository : IWarehouseBranches
    {
        private readonly DatabaseContext _dbContext;

        public WarehouseBranchRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WarehouseBranch>> GetWarehouseBranches()
        {
            try
            {
                return await _dbContext.WarehouseBranches.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<WarehouseBranch> GetWarehouseBranchById(int id)
        {
            try
            {
                return await _dbContext.WarehouseBranches.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task AddWarehouseBranch(WarehouseBranch warehouseBranch)
        {
            try
            {
                await _dbContext.WarehouseBranches.AddAsync(warehouseBranch);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateWarehouseBranch(WarehouseBranch warehouseBranch)
        {
            try
            {
                _dbContext.Entry(warehouseBranch).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<WarehouseBranch> DeleteWarehouseBranch(int id)
        {
            try
            {
                var warehouseBranch = await _dbContext.WarehouseBranches.FindAsync(id);
                if (warehouseBranch != null)
                {
                    _dbContext.WarehouseBranches.Remove(warehouseBranch);
                    await _dbContext.SaveChangesAsync();
                }
                return warehouseBranch;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CheckWarehouseBranch(int id)
        {
            return await _dbContext.WarehouseBranches.AnyAsync(w => w.Id == id);
        }
    }
}
