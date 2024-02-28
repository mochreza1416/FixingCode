using AuthDocument.Context;
using AuthDocument.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace AuthDocument.Service
{
    public class AccessService : IAccessService
    {
        DatabaseContext _dbContext = null;
        public AccessService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Password validation method
        private bool ValidatePassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-+]).{8,}$");
        }
        public async Task<string> Register(User user)
        {
            // Validate password against requirements
            if (!ValidatePassword(user.Password))
            {
                return "Failed";
            }

            // Save user to database
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            return "Success";
        }

        public async Task<string> Login(User login)
        {
            var user = await _dbContext.Users.Where(w => w.Email == login.Email && w.Password == login.Password).ToListAsync();
            if (user.Any())
                return "Success";
            return "Failed";
        }
    }
}
