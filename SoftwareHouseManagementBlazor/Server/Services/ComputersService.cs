using System.Collections.Generic;
using SoftwareHouseManagementBlazor.Server.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SoftwareHouseManagementBlazor.Shared.Models;

namespace SoftwareHouseManagementBlazor.Server.Services
{
    public class ComputersService
    {
        private readonly ApplicationDbContext _context;

        public ComputersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddComputer(string model)
        {
            var computer = new Computer
            {
                Model = model
            };
            _context.Computers.Add(computer);
            _context.SaveChanges();
        }

        public IEnumerable<Computer> GetAll()
        {
            var computers = _context.Computers.Select(x => new Computer()
            {
                Id = x.Id,
                Model = x.Model,
                Worker = x.Worker
            }).ToList();
            return computers;
        }
        public IEnumerable<Computer> GetAllWithoutWorker()
        {
            var computers = _context.Computers.Where(y => y.Worker == null).Select(x => new Computer()
            {
                Id = x.Id,
                Model = x.Model
            }).ToList();
            return computers;
        }

        public void AssignComputer(string workerId, long computerId)
        {
            var worker = _context.Workers.FirstOrDefault(x => x.Id == workerId);
            worker.ComputerId = computerId;
            _context.SaveChanges();
        }

        public void ModifyComputer(long computerId, string model)
        {
            var computer = _context.Computers.FirstOrDefault(x => x.Id == computerId);
            computer.Model = model;
            _context.SaveChanges();
        }

        public IEnumerable<Worker> GetAllWithComputers()
        {
            var workersWithComputers = _context.Workers.Include(y => y.Computer).Where(x => x.ComputerId != null).ToList();
            return workersWithComputers;
        }

        public void DeleteAssignedComputers(string workerId)
        {
            var worker = _context.Workers.Include(x => x.Computer).FirstOrDefault(y => y.Id == workerId);
            worker.Computer = null;
            _context.SaveChanges();
        }

    }
}
