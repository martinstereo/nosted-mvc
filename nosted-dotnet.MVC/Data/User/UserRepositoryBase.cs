﻿using Microsoft.AspNetCore.Identity;

namespace nosted_dotnet.MVC.Data.User
{
    public abstract class UserRepositoryBase
    {
        UserManager<IdentityUser> userManager;
        public UserRepositoryBase(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public bool IsAdmin(string email)
        {
            var identity = userManager.Users.FirstOrDefault(x => x.Email == email);
            var existingRoles = userManager.GetRolesAsync(identity).Result;
            return existingRoles.FirstOrDefault(x => x == "Administrator") != null;
        }

        protected void SetRoles(string userEmail, List<string> roles)
        {
            var identity = userManager.Users.FirstOrDefault(x => x.Email == userEmail);
            var existingRoles = userManager.GetRolesAsync(identity).Result;

            //fjerner role access for en ny legges til
            foreach (var existingRole in existingRoles)
            {
                var result = userManager.RemoveFromRoleAsync(identity, existingRole).Result;
            }
            foreach (var role in roles)
            {
                if (!userManager.IsInRoleAsync(identity, role).Result)
                {
                    var result = userManager.AddToRoleAsync(identity, role).Result;
                }
            }
        }
        public UserManager<IdentityUser> UserManager { get; }
    }
}
