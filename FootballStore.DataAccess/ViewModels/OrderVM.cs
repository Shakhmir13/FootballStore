using FootballStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.DataAccess.ViewModels
{
    public class OrderVM
    {
        public IEnumerable<Order> orders { get; set; } = new List<Order>();
    }
}
