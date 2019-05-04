using FashionWorld.Data;
using FashionWorld.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Repos
{
   public interface IFavoritsRepository
    {
        void AddToFavorits(Favorite favorite);
        List<Favorite> GetUserFavorites(string userId);
        Favorite GetFavorite(int id);
        void RemoveFromFavorits(Favorite favorite);
    }
    public class FavoritsRepository : IFavoritsRepository
    {
        private readonly ApplicationDbContext _context;

        public FavoritsRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public void AddToFavorits(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            _context.SaveChanges();
        }

        public Favorite GetFavorite(int id)
        {
            return _context.Favorites.FirstOrDefault(f => f.ID == id);
        }

        public List<Favorite> GetUserFavorites(string userId)
        {
            return _context.Favorites.Where(f => f.AppUserId.Equals(userId))
                .Include(p=>p.Product).ToList();
        }

        public void RemoveFromFavorits(Favorite favorite)
        {
            _context.Favorites.Remove(favorite);
            _context.SaveChanges();
        }
    }
}
