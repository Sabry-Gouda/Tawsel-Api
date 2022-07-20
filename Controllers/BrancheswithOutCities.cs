using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tawsel.DTO;
using tawsel.models;

namespace tawsel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrancheswithOutCities : ControllerBase
    {

        List<BranchDto> Branches = new List<BranchDto>();
        private readonly tawseel _context;

        public BrancheswithOutCities(tawseel context)
        {
            _context = context;
        }
        [HttpGet]
        public List<BranchDto> gerallBranches()
        {
            var branchat = _context.Branches.Select(n => new { id = n.id, name = n.name, createdDate = n.createdDate.ToString(), status = n.status }).ToList();
            foreach (var item in branchat)
            {
                BranchDto b = new BranchDto();
                b.id = item.id;
                b.name = item.name;
                b.createdDate = item.createdDate;
                b.status = item.status;
                Branches.Add(b);
            }
            return Branches;
        }

        [HttpGet("{id}")]
        public BranchDto gerBranchById(int id)
        {
            List<BranchDto> MyBranches = gerallBranches();
            BranchDto MyBranch = MyBranches.FirstOrDefault(n => n.id == id);
            return MyBranch;
        }
    }
}
