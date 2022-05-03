using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SoftwareHouseManagementBlazor.Server.Data;
using SoftwareHouseManagementBlazor.Server.Models;
using SoftwareHouseManagementBlazor.Shared.Models;

namespace SoftwareHouseManagementBlazor.Server.Services
{
    public class WorkersService
    {
        private readonly ApplicationDbContext _context;

        public WorkersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddWorker(string firstName, string lastName, string email, string password, long positionId)
        {


            var position = _context.Positions
                .FirstOrDefault(x => x.Id == positionId);
            var worker = new Worker
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                //Password = password,
            };
            worker.Positions.Add(position);
            _context.Workers.Add(worker);
            _context.SaveChanges();
        }
        public IEnumerable<Worker> GetAll()
        {
            var workers = _context.Workers.Select(x => new Worker()
            {
                Id = x.Id,
                Email = x.Email,
                //Password = x.Password,
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
                //Password = x.Password,
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
    }
}
