using FashionWorld.Data;
using FashionWorld.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Repos
{
   public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Order> Orders => context.Orders.
            Include(l => l.Lines)
            .ThenInclude(p => p.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(p => p.Product));
            if (order.OrderID==0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
