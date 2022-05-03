using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SoftwareHouseManagementBlazor.Server.Data;
using SoftwareHouseManagementBlazor.Server.Models;

namespace SoftwareHouseManagementBlazor.Server.Services

{
    public class ResponsibilitiesService
    {
        private readonly ApplicationDbContext _context;

        public ResponsibilitiesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateResponsibilities(string name)
        {
            var entity = new Responsibilities
            {
                Name = name
            };
            _context.Responsibilities.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Responsibilities> GetAll()
        {
            var responsibilities = _context.Responsibilities.Select(x => new Responsibilities()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return responsibilities;
        }

        public void AssignResponsibilities(long responsibilityID, long PositionId)
        {
            var responsibility = _context.Responsibilities.SingleOrDefault(x => x.Id == responsibilityID);
            var position = _context.Positions.SingleOrDefault(x => x.Id == PositionId);
            responsibility.Positions.Add(position);
            _context.SaveChanges();
        }
        public void ModifyResponsibility(long id, string name)
        {
            var responsibilities = _context.Responsibilities.FirstOrDefault(x => x.Id == id);
            responsibilities.Name = name;
            _context.SaveChanges();
        }

        public void DeleteResponsibility(long responsibilityId, long positionId)
        {
            try
            {
                var position = _context.Positions.Include("Responsibilities")
                    .FirstOrDefault(x => x.Id == positionId);
                var responsibility = _context.Responsibilities
                    .FirstOrDefault(y => y.Id == responsibilityId);
                position.Responsibilities.Remove(responsibility);
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

    }
}
