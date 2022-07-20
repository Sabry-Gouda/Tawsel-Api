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

    public class ReportsController : ControllerBase
    {
        List<reportDto> reports=new List<reportDto>();
        private readonly tawseel _context;

        public ReportsController(tawseel context)
        {
            _context = context;
        }
        [HttpGet]
        public List<reportDto> gerallReports()
        {


            var reportat = _context.Orders.Include(n => n.ApplicationUser)
     .Include(n => n.client)
     .Include(n => n.City)
     .Include(n => n.State)
     .Include(n => n.Status)
     .Include(n => n.shiping)
     .Select(n => new
     {
         id = n.Id,
         serialNumber = n.serialNumber,
         date = n.Date.ToString(),
         name = n.client.name,
         phoneNumber = n.ApplicationUser.PhoneNumber,
         government = n.State.Name,
         city = n.City.Name,
         orderCost = n.totalCost,
         status = n.Status.Name,
         traderName=n.ApplicationUser.UserName,
         customerName=n.client.name,
         shippingCost=n.shiping.Cost,
         paidShippingAmount=n.City.CostPerCity,
         receivedAmount = 120,
         companyValue = n.totalCost - n.shiping.Cost
        }).ToList();

            foreach (var item in reportat)
            {
                reportDto r = new reportDto();
                r.id= item.id;
                r.customerName = item.customerName;
                r.traderName = item.traderName;
                r.phoneNumber = item.phoneNumber;
                r.serialNumber = item.serialNumber;
                r.date = item.date;
                r.status = item.status;
                r.shippingCost = item.shippingCost;
                r.companyValue = item.companyValue;
                r.government = item.government;
                r.city = item.city;
                r.receivedAmount=item.receivedAmount;
                r.orderCost = item.orderCost;
                r.paidShippingAmount = item.paidShippingAmount;
                reports.Add(r);
            }


            return reports;
        
            
        }

        [HttpGet("{id}")]
        public reportDto gerReportById(int id)
        {
            List < reportDto > Myreports = gerallReports();
           reportDto report= Myreports.FirstOrDefault(n => n.id == id);
            return report;
        }

        }
}
