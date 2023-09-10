using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Conceretes
{
    public class Order:IEntity
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public string CustomerId { get; set; }
        public string ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
