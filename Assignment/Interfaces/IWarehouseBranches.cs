using Assignment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.Interfaces
{
    public interface IWarehouseBranches
    {
        Task<List<WarehouseBranch>> GetWarehouseBranches();
        Task<WarehouseBranch> GetWarehouseBranchById(int id);
        Task AddWarehouseBranch(WarehouseBranch warehouseBranch);
        Task UpdateWarehouseBranch(WarehouseBranch warehouseBranch);
        Task<WarehouseBranch> DeleteWarehouseBranch(int id);
        Task<bool> CheckWarehouseBranch(int id);
    }
}
