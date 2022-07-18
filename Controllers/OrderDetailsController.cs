using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tawsel.DTO;
using tawsel.models;

namespace tawsel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        List<OrderDto> orders = new List<OrderDto>();
        private readonly tawseel _context;

        public OrderDetailsController(tawseel context)
        {
            _context = context;
        }
        [HttpGet]
        public  List<OrderDto> getallorders()
        {

            var order = _context.Orders.Include(n => n.ApplicationUser)
                 .Include(n => n.client)
                 .Include(n => n.City)
                 .Include(n => n.State)
                 .Select(n => new
                 {
                     id = n.Id,
                     serialNumber = n.serialNumber,
                     date = n.Date.ToString(), 
                     name=n.client.name,
                     phoneNumber=n.client.Phone1,
                     government=n.State.Name,
                     city=n.City.Name,
                     orderCost = n.Cost,
                     status=n.Status.Name
                 }).ToList();

        foreach(var item in order)
            {
                OrderDto o = new OrderDto();
                o.id = item.id;
                o.serialNumber = item.serialNumber;
                o.date = item.date;
                o.customerData.name = item.name;
                o.customerData.phoneNumber = item.phoneNumber;
                o.government = item.government;
                o.city = item.city;
                o.orderCost = item.orderCost;
                o.status = item.status;
                orders.Add(o);
            }


            return orders;
        }
        [HttpGet("{id}")]
        public OrderDto gerOrderById(int id)
        {
            List<OrderDto> MyOrders = getallorders();
            OrderDto Myorder = MyOrders.FirstOrDefault(n => n.id == id);
            return Myorder;
        }
    }
}
