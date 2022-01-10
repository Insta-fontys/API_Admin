using API_Admin.Services.Interfaces;
using DataAccesLibrary.DataAccess;
using DataAccesLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Admin.Services
{
    public class AdminDatabaseService : IAdminDatabase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly DatabaseContext _context;

        public AdminDatabaseService(DatabaseContext context, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }

        public async Task<IList<Fan>> GetFans()
        {
            return await _context.Fans.ToListAsync();
        }

        public async Task<IList<Creator>> GetCreators()
        {
            return await _context.Creators.ToListAsync();
        }

        public async Task<bool> DeleteCreatorByName(string name)
        {
            try
            {
                var fan = await _context.Creators.FirstOrDefaultAsync(i => i.Username == name);
                _context.Creators.Remove(fan);
                await DeleteIdentityUser(name);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFanByName(string name)
        {
            try
            {
                var fan = await _context.Fans.FirstOrDefaultAsync(i => i.Username == name);
                _context.Fans.Remove(fan);
                await DeleteIdentityUser(name);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<bool> DeleteIdentityUser(string name)
        {
            IdentityUser user = await userManager.FindByNameAsync(name);
            await userManager.DeleteAsync(user);
            return true;
        }

        public async Task<bool> DeletePostById(long id)
        {
            try
            {
                var post = await _context.Posts.FindAsync(id);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
