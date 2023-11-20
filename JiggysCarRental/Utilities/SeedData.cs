using JiggysCarRental.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JiggysCarRental.Utilities
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> usermanager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            CarDbContext context = serviceProvider.GetRequiredService<CarDbContext>();

            await SeedRoles(roleManager);
            await SeedAdminUser(usermanager);
            await SeedEmployeeUser(usermanager);

            await SeedCarData(context);
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new[] {"Admin" , "Employee"};
            foreach(string role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public static async Task SeedAdminUser(UserManager<IdentityUser> userManager)
        {
            IdentityUser? adminUser = await userManager.FindByNameAsync("admin");

            if(adminUser == null)
            {
                IdentityUser admin = new()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };

                IdentityResult createAdmin = await userManager.CreateAsync(admin, "Admin123$");
                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(admin);
                await userManager.ConfirmEmailAsync(admin, confirmationToken);
                if(createAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }

        public static async Task SeedEmployeeUser(UserManager<IdentityUser> userManager)
        {
            IdentityUser? employeeUser = await userManager.FindByNameAsync("employee1");
            if(employeeUser == null)
            {
                IdentityUser employee1 = new()
                {
                    UserName = "employee1",
                    Email = "employee1@gmail.com"
                };

                IdentityResult createEmployee = await userManager.CreateAsync(employee1, "Employee123$");
                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(employee1);
                await userManager.ConfirmEmailAsync(employee1, confirmationToken);
                if(createEmployee.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee1, "Employee");
                }
            }
        }

        public static async Task SeedCarData(CarDbContext context)
        {
            Vehicle vehicle1 = new()
            {
                VehicleName = "Compact Car",
                Image = "604b6e82-0a76-4df3-89db-2bedcaaf4306.webp",
                Details = "Demio, Vitz or similar",
                RentCost = "22",
                NumberOfPassengers = 3,
                NumberOLargeBags = 4,
                UsbAdapter = true,
                ReverseCamera = false,
                PushStart = true,
                Bluetooth = true,
                ToolsControl = false,
                SteeringControl = true,
                ThermalControl = false,
                HeatedSeat = true,
                AutomaticTransmission = false,
                FourWheelDrive = true,
                LeatherSeats = false,
                Aux = true,
                StartDateAvailable = DateTime.Now,
                EndDateAvailable = (DateTime.Now).AddDays(30)

            };

            Vehicle? vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleName == vehicle1.VehicleName);

            if(vehicle == null)
            {
                context.Add(vehicle1);
                await context.SaveChangesAsync();
            }

            Vehicle vehicle2 = new()
            {
                VehicleName = "Economy Car",
                Image = "4de20c6e-23dc-4ba7-bee4-1b9857dc7758.jpg",
                Details = "Mitsubishi Galant, Tiida or similar",
                RentCost = "30",
                NumberOfPassengers = 5,
                NumberOLargeBags = 3,
                UsbAdapter = true,
                ReverseCamera = true,
                PushStart = false,
                Bluetooth = false,
                ToolsControl = false,
                SteeringControl = false,
                ThermalControl = false,
                HeatedSeat = false,
                AutomaticTransmission = true,
                FourWheelDrive = false,
                LeatherSeats = false,
                Aux = true,
                StartDateAvailable = DateTime.Now,
                EndDateAvailable = (DateTime.Now).AddDays(30)

            };

            Vehicle? Vehicle2 = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleName == vehicle2.VehicleName);

            if(Vehicle2 == null)
            {
                context.Add(vehicle2);
                await context.SaveChangesAsync();
            }

            Vehicle vehicle3 = new()
            {
                VehicleName = "Standard Car",
                Image = "a7b5b6e1-3e2b-4908-9f37-50e905f2920e.jpg",
                Details = "Subaru Impreza or similar",
                RentCost = "33",
                NumberOfPassengers = 5,
                NumberOLargeBags = 3,
                UsbAdapter = true,
                ReverseCamera = true,
                PushStart = false,
                Bluetooth = false,
                ToolsControl = false,
                SteeringControl = false,
                ThermalControl = false,
                HeatedSeat = false,
                AutomaticTransmission = true,
                FourWheelDrive = false,
                LeatherSeats = false,
                Aux = true,
                StartDateAvailable = DateTime.Now,
                EndDateAvailable = (DateTime.Now).AddDays(30)

            };

            Vehicle? Vehicle3 = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleName == vehicle3.VehicleName);

            if(Vehicle3 == null)
            {
                context.Add(vehicle3);
                await context.SaveChangesAsync();
            }

            Vehicle vehicle4 = new()
            {
                VehicleName = "Full-size Car",
                Image = "980188bb-1714-4b0f-a2e7-85ddfa807279.jpg",
                Details = "Axio, Corolla Fielder, Nissan Sylphy or similar",
                RentCost = "35",
                NumberOfPassengers = 5,
                NumberOLargeBags = 3,
                UsbAdapter = true,
                ReverseCamera = false,
                PushStart = false,
                Bluetooth = false,
                ToolsControl = false,
                SteeringControl = false,
                ThermalControl = false,
                HeatedSeat = false,
                AutomaticTransmission = true,
                FourWheelDrive = false,
                LeatherSeats = false,
                Aux = true,
                StartDateAvailable = DateTime.Now,
                EndDateAvailable = (DateTime.Now).AddDays(30)

            };

            Vehicle? Vehicle4 = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleName == vehicle4.VehicleName);

            if(Vehicle4 == null)
            {
                context.Add(vehicle4);
                await context.SaveChangesAsync();
            }

            Vehicle vehicle5 = new()
            {
                VehicleName = "Intermediate SUV",
                Image = "ec04f440-8af9-4322-b914-c092e3a9b333.jpg",
                Details = "Nissan, Rukus or similar",
                RentCost = "50",
                NumberOfPassengers = 7,
                NumberOLargeBags = 5,
                UsbAdapter = true,
                ReverseCamera = false,
                PushStart = true,
                Bluetooth = false,
                ToolsControl = false,
                SteeringControl = false,
                ThermalControl = false,
                HeatedSeat = false,
                AutomaticTransmission = true,
                FourWheelDrive = false,
                LeatherSeats = true,
                Aux = true,
                StartDateAvailable = DateTime.Now,
                EndDateAvailable = (DateTime.Now).AddDays(30)

            };

            Vehicle? Vehicle5 = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleName == vehicle5.VehicleName);

            if(Vehicle5 == null)
            {
                context.Add(vehicle5);
                await context.SaveChangesAsync();
            }

             Vehicle vehicle6 = new()
            {
                VehicleName = "SUV",
                Image = "37723b18-ea1c-4e50-8448-1c99942b4f83.jpg",
                Details = "Vitara, RVR or similar",
                RentCost = "60",
                NumberOfPassengers = 8,
                NumberOLargeBags = 5,
                UsbAdapter = true,
                ReverseCamera = true,
                PushStart = true,
                Bluetooth = true,
                ToolsControl = true,
                SteeringControl = false,
                ThermalControl = false,
                HeatedSeat = false,
                AutomaticTransmission = true,
                FourWheelDrive = true,
                LeatherSeats = true,
                Aux = true,
                StartDateAvailable = DateTime.Now,
                EndDateAvailable = (DateTime.Now).AddDays(30)

            };

            Vehicle? Vehicle6 = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleName == vehicle6.VehicleName);

            if(Vehicle6 == null)
            {
                context.Add(vehicle6);
                await context.SaveChangesAsync();
            }

            Vehicle vehicle7 = new()
            {
                VehicleName = "LUXURY SUV",
                Image = "81133989-aa76-4d64-be71-ccc021643376.jpeg",
                Details = "Mazda CX-5, Honda CRV or similar",
                RentCost = "65",
                NumberOfPassengers = 8,
                NumberOLargeBags = 5,
                UsbAdapter = true,
                ReverseCamera = true,
                PushStart = true,
                Bluetooth = true,
                ToolsControl = true,
                SteeringControl = true,
                ThermalControl = false,
                HeatedSeat = false,
                AutomaticTransmission = true,
                FourWheelDrive = false,
                LeatherSeats = true,
                Aux = true,
                StartDateAvailable = DateTime.Now,
                EndDateAvailable = (DateTime.Now).AddDays(30)

            };

            Vehicle? Vehicle7 = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleName == vehicle7.VehicleName);

            if(Vehicle7 == null)
            {
                context.Add(vehicle7);
                await context.SaveChangesAsync();
            }

            Vehicle vehicle8 = new()
            {
                VehicleName = "Minivan",
                Image = "50872c9c-b0b1-4107-893f-d9592d8f3796.jpg",
                Details = "Noah, Voxy or similar",
                RentCost = "60",
                NumberOfPassengers = 8,
                NumberOLargeBags = 5,
                UsbAdapter = true,
                ReverseCamera = true,
                PushStart = false,
                Bluetooth = true,
                ToolsControl = false,
                SteeringControl = false,
                ThermalControl = true,
                HeatedSeat = true,
                AutomaticTransmission = true,
                FourWheelDrive = false,
                LeatherSeats = false,
                Aux = true,
                StartDateAvailable = DateTime.Now,
                EndDateAvailable = (DateTime.Now).AddDays(30)

            };

            Vehicle? Vehicle8 = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleName == vehicle8.VehicleName);

            if(Vehicle8 == null)
            {
                context.Add(vehicle8);
                await context.SaveChangesAsync();
            }

             Vehicle vehicle9 = new()
            {
                VehicleName = "Bus",
                Image = "e27cdba8-cb96-44a3-8bb6-d7cf4a3fcec0.jpg",
                Details = "Toyota Hiace or similar",
                RentCost = "80",
                NumberOfPassengers = 14,
                NumberOLargeBags = 10,
                UsbAdapter = true,
                ReverseCamera = false,
                PushStart = false,
                Bluetooth = true,
                ToolsControl = false,
                SteeringControl = false,
                ThermalControl = false,
                HeatedSeat = false,
                AutomaticTransmission = true,
                FourWheelDrive = false,
                LeatherSeats = false,
                Aux = true,
                StartDateAvailable = DateTime.Now,
                EndDateAvailable = (DateTime.Now).AddDays(30)

            };

            Vehicle? Vehicle9 = await context.Vehicles.FirstOrDefaultAsync(x => x.VehicleName == vehicle9.VehicleName);

            if(Vehicle9 == null)
            {
                context.Add(vehicle9);
                await context.SaveChangesAsync();
            }
        }
    }
}