using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SoftwareHouseManagementBlazor.Server.Data;
using SoftwareHouseManagementBlazor.Server.Models;

namespace SoftwareHouseManagementBlazor.Server.Services
{
    public class TeamsService
    {
        private readonly ApplicationDbContext _context;

        public TeamsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetAllNotAssignedTasks()
        {
            var notAssignedTasks = _context.Tasks.Where(x => x.Team == null).ToList();
            return notAssignedTasks;
        }

        public IEnumerable<Team> GetAllNotAssignedTeams()
        {
            var notAssignedTeams = _context.Teams.Where(x => x.Task == null).ToList();
            return notAssignedTeams;
        }

        public IEnumerable<Team> GetAllAssignedTeams()
        {
            var assignedTeams = _context.Teams.Include(x => x.Task)
                .Where(z => z.TaskId != null).ToList();
            return assignedTeams;
        }

        public void AddTeam(string name)
        {
            var team = new Team()
            {
                Name = name,
                MemberCount = 0
            };
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void AssignTaskToTeam(long teamId, long taskId, int hours, int minutes)
        {
            var hoursTicks = hours * 36000000000;
            var minutesTicks = minutes * 600000000;
            var team = _context.Teams.FirstOrDefault(x => x.Id == teamId);
            team.TaskId = taskId;
            var task = _context.Tasks.FirstOrDefault(y => y.Id == taskId);
            task.AssignedHours = hoursTicks + minutesTicks;
            _context.SaveChanges();
        }

        public void DeleteTeamContent(long teamId)
        {
            var team = _context.Teams.Include(y => y.Task).FirstOrDefault(x => x.Id == teamId);
            team.Task.AssignedHours = 0;
            team.Task = null;
            team.TaskId = null;
            team.Workers = null;
            team.MemberCount = 0;
            team.Accesses = null;
            _context.SaveChanges();
        }

        public void AssignWorkerToTeam(long teamId, string workerId)
        {
            var team = _context.Teams.Include(y => y.Workers).FirstOrDefault(x => x.Id == teamId);
            var worker = _context.Workers.FirstOrDefault(z => z.Id == workerId);
            team.Workers.Add(worker);
            team.MemberCount++;
            _context.SaveChanges();
        }

        public IEnumerable<Worker> GetTeamsWorkers(long teamId)
        {
            var team = _context.Teams.Include(x => x.Workers)
                .FirstOrDefault(y => y.Id == teamId);
            return team.Workers;
        }

        public void DeleteFromTeam(long teamId, string workerId)
        {
            var team = _context.Teams.Include(x => x.Workers)
                .FirstOrDefault(y => y.Id == teamId);
            var worker = _context.Workers.FirstOrDefault(z => z.Id == workerId);
            team.Workers.Remove(worker);
            team.MemberCount--;
            _context.SaveChanges();
        }

        public IEnumerable<Access> GetTeamsAccesses(long teamId)
        {
            var team = _context.Teams.Include(x => x.Accesses)
                .FirstOrDefault(y => y.Id == teamId);
            return team.Accesses;
        }

        public void AddAccessForTeam(string accessName, long teamId)
        {
            var team = _context.Teams.Include(x => x.Accesses).FirstOrDefault(y => y.Id == teamId);
            var access = new Access()
            {
                Name = accessName
            };
            team.Accesses.Add(access);
            _context.SaveChanges();
        }

        public void DeleteAccessFromTeam(long teamId, long accessId)
        {
            var team = _context.Teams.Include(x => x.Accesses)
                .FirstOrDefault(y => y.Id == teamId);
            var access = _context.Accesses.FirstOrDefault(z => z.Id == accessId);
            team.Accesses.Remove(access);
            _context.SaveChanges();
        }
    }
}
