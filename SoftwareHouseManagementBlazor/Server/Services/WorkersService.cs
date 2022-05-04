using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SoftwareHouseManagementBlazor.Server.Data;
using SoftwareHouseManagementBlazor.Shared.DTOs;
using SoftwareHouseManagementBlazor.Shared.DTOs.FormModels;
using SoftwareHouseManagementBlazor.Shared.Entities;

namespace SoftwareHouseManagementBlazor.Server.Services
{
    public class WorkersService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Worker> _userManager;

        public WorkersService(ApplicationDbContext context, UserManager<Worker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<Worker> GetAll()
        {
            var workers = _context.Workers.Select(x => new Worker()
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();
            return workers;
        }
        public IEnumerable<Worker> GetAllWithoutComputer()
        {
            var workers = _context.Workers.Where(y => y.Computer == null).Select(x => new Worker()
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();
            return workers;
        }

        public List<Task> GetWorkersTasks(string workerId)
        {
            var tasks = new List<Task>();
            var worker = _context.Workers
                .Include(y => y.Teams).ThenInclude(z => z.Task)
                .FirstOrDefault(x => x.Id == workerId);

            foreach (var item in worker.Teams)
            {
                tasks.Add(item.Task);
            }
            return tasks;
        }

        public void LoginTime(long projectId, string date, int hours, int minutes, Worker identity)
        {

            var hoursTicks = hours * 36000000000;
            var minutesTicks = minutes * 600000000;
            string format = "MM-yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            var hoursWorked = new HoursWorked()
            {
                Amount = hoursTicks + minutesTicks,
                Month = DateTime.ParseExact(date, format, provider),
                TaskId = projectId
            };
            var worker = _context.Workers.Include(x => x.HoursWorked).FirstOrDefault(y => y.Id == identity.Id);
            var task = _context.Tasks.FirstOrDefault(a => a.Id == projectId);
            task.WorkedHours += hoursTicks + minutesTicks;
            worker.HoursWorked.Add(hoursWorked);
            _context.SaveChanges();
        }
        public IEnumerable<Worker> GetAllWithPositions()
        {
            var workers = _context.Workers.Select(x => new Worker()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Positions = x.Positions,
                Email = x.Email
            }).Where(y => y.Positions.Count != 0).ToList();
            return workers;
        }
        public IEnumerable<Worker> GetAllWithComputers()
        {
            var workersWithComputers = _context.Workers
                .Include(y => y.Computer)
                .Where(x => x.ComputerId != null).ToList();

            return workersWithComputers;
        }
        public void DeleteAssignedComputer(string workerId)
        {
            var worker = _context.Workers.Include(x => x.Computer).FirstOrDefault(y => y.Id == workerId);
            worker.Computer = null;
            _context.SaveChanges();
        }
        public void AssignComputer(string workerId, long computerId)
        {
            var worker = _context.Workers.FirstOrDefault(x => x.Id == workerId);
            worker.ComputerId = computerId;
            _context.SaveChanges();
        }

    }
}
