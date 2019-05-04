using FashionWorld.Data;
using FashionWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Repos
{
   public interface IMarketRepository
    {

            IEnumerable<Market> Markets { get; }
            void AddMarket(Market market);
            void UpdateMarket(Market market);
            void DeleteMarket(Market market);
        }
        public class MarketRepository : IMarketRepository
        {
            private ApplicationDbContext context;
            public MarketRepository(ApplicationDbContext ctx) => context = ctx;

            public IEnumerable<Market> Markets => context.Markets;

            public void AddMarket(Market market)
            {
                context.Markets.Add(market);
                context.SaveChanges();
            }

            public void DeleteMarket(Market market)
            {
                context.Markets.Remove(market);
                context.SaveChanges();
            }

            public void UpdateMarket(Market market)
            {
                context.Markets.Update(market);
                context.SaveChanges();
            }
        }
    }




