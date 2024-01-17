using KsiegarniaPKP.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KsiegarniaPKP.Data
{
    public class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<Uzytkownik> userManager,
                  RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        // name - correct email
        // password - min 8 charcters, small and capital letter, digit and special char
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Uzytkownik").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Uzytkownik",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Kurier").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Kurier",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Pracownik").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Pracownik",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

        }

        public static void SeedOneUser(UserManager<Uzytkownik> userManager,
                                        string email, string password, string imie, string nazwisko, string role = null)
        {
            if (userManager.FindByNameAsync(email).Result == null)
            {
                Uzytkownik user = new Uzytkownik
                {
                    Imie = imie,
                    Nazwisko = nazwisko,
                    UserName = email, 
                    Email = email
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded && role != null)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                }
            }
        }
        public static void SeedUsers(UserManager<Uzytkownik> userManager)
        {
            SeedOneUser(userManager, "uzytkownik@gmail.com", "nUpass1!", "Szymon", "Wieczorek", "Uzytkownik");
            SeedOneUser(userManager, "kurier@gmail.com", "kUpass1!", "Karol", "Pilat", "Kurier");
            SeedOneUser(userManager, "pracownik@gmail.com", "pUpass1!", "Dawid", "Spalek", "Pracownik");
            SeedOneUser(userManager, "admin@gmail.com", "aUpass1!", "Urszula", "Staszak", "Admin");
        }
    }


}
