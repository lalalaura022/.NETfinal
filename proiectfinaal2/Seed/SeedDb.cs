﻿using Microsoft.AspNetCore.Identity;
using proiectfinaal2.data;
using proiectfinaal2.Models.Constants;
using proiectfinaal2.Models.entities2;
using System.Linq;
using System.Threading.Tasks;

namespace proiectfinaal2.Seed
{
    public class SeedDb
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly Context _context;

        public SeedDb(RoleManager<Role> roleManager, Context context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public async Task SeedRoles()
        {
            if (_context.Roles.Any())
            {
                return;
            }

            string[] roleNames =
            {
                UserRoleType.Admin,
                UserRoleType.User
            };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    roleResult = await _roleManager.CreateAsync(new Role
                    {
                        Name = roleName
                    });
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
