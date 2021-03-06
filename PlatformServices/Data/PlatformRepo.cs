using System;
using System.Collections.Generic;
using System.Linq;
using PlatformServices.Models;

namespace PlatformServices.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;


        public PlatformRepo(AppDbContext ctx)
        {
            _context = ctx;
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
