using System;
using System.Linq;
using Diploma.Models;

namespace Diploma.Data
{
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext _context)
        {
            if (!_context.Buyers.Any())
            {
                _context.Degrees.AddRange(
                    new Degree { Name = "Первая категория", Salary = 400M},
                    new Degree { Name = "Вторая категория", Salary = 500M},
                    new Degree { Name = "Третья категория", Salary = 600M},
                    new Degree { Name = "Четвертая категория", Salary = 700M},
                    new Degree { Name = "Пятая категория", Salary = 800M},
                    new Degree { Name = "Шестая категория", Salary = 900M}
                    );
                _context.SaveChanges();
                _context.Employees.AddRange(
                    new Employee
                    {
                        Email = "kolya@gmail.com",
                        NormalizedUserName = "KOLYA2000",
                        NormalizedEmail = "kolya@gmail.com".ToUpper(),
                        UserName = "KOLYA2000",
                        EmailConfirmed = true,
                        Name = "Kolya",
                        Surname = "Kaminski"
                    });
                _context.SaveChanges();
                _context.PromotionHistories.AddRange(
                    new PromotionHistory { DegreeId = 1, EmployeeId = 1, StartDate = DateTime.Now.AddYears(-2), EndDate = DateTime.Now.AddYears(-1)},
                    new PromotionHistory { DegreeId = 2, EmployeeId = 1, StartDate = DateTime.Now.AddYears(-1), EndDate = null}, 
                    new PromotionHistory { DegreeId = 3, EmployeeId = 2, StartDate = DateTime.Now.AddDays(-45), EndDate = null}
                );
                _context.SaveChanges();
                _context.Buyers.AddRange(
                    new Buyer
                    {

                        Name = "Dmitriy",
                        PassportId = "KP3553656HGT",
                        Surname = "Senko"
                    },
                    new Buyer
                    {

                        Name = "Vikasi",
                        PassportId = "ASDF454353445",
                        Surname = "Vichnevets"
                    },
                    new Buyer
                    {

                        Name = "Vicktor",
                        PassportId = "ASFF746756JYK8",
                        Surname = "Franken"
                    },
                    new Buyer
                    {

                        Name = "Dmitriy",
                        PassportId = "KP3553656HGT",
                        Surname = "Senko"
                    },
                    new Buyer
                    {

                        Name = "Vikasi",
                        PassportId = "ASDF454353445",
                        Surname = "Vichnevets"
                    },
                    new Buyer
                    {

                        Name = "Vicktor",
                        PassportId = "ASFF746756JYK8",
                        Surname = "Franken"
                    },
                    new Buyer
                    {

                        Name = "Dmitriy",
                        PassportId = "KP3553656HGT",
                        Surname = "Senko"
                    },
                    new Buyer
                    {

                        Name = "Vikasi",
                        PassportId = "ASDF454353445",
                        Surname = "Vichnevets"
                    },
                    new Buyer
                    {

                        Name = "Vicktor",
                        PassportId = "ASFF746756JYK8",
                        Surname = "Franken"
                    });

                _context.SaveChanges();
                _context.Sellers.AddRange(
                    new Seller
                    {

                        Name = "Katya",
                        Surname = "Kovcheg",
                        PassportNum = "POI949595"
                    },
                    new Seller
                    {

                        Name = "Vadim",
                        Surname = "Navrot",
                        PassportNum = "LGLJG99993"
                    },
                    new Seller
                    {

                        Name = "Wayvee",
                        Surname = "Uzi",
                        PassportNum = "CCCC22222222"
                    },
                    new Seller
                    {

                        Name = "Katya",
                        Surname = "Kovcheg",
                        PassportNum = "POI949595"
                    },
                    new Seller
                    {

                        Name = "Vadim",
                        Surname = "Navrot",
                        PassportNum = "LGLJG99993"
                    },
                    new Seller
                    {

                        Name = "Wayvee",
                        Surname = "Uzi",
                        PassportNum = "CCCC22222222"
                    },
                    new Seller
                    {

                        Name = "Katya",
                        Surname = "Kovcheg",
                        PassportNum = "POI949595"
                    },
                    new Seller
                    {

                        Name = "Vadim",
                        Surname = "Navrot",
                        PassportNum = "LGLJG99993"
                    },
                    new Seller
                    {

                        Name = "Wayvee",
                        Surname = "Uzi",
                        PassportNum = "CCCC22222222"
                    });
                _context.SaveChanges();
                _context.Houses.AddRange(
                    new House
                    {

                        Address = "Minsk, Lomonosova 5, 45",
                        SellerId = 1,
                    },
                    new House
                    {

                        Address = "Minsk, Kurganova 4, 5",
                        SellerId = 2,
                    },
                    new House
                    {

                        Address = "Minsk, Putina 25, 12",
                        SellerId = 3,
                    },
                    new House
                    {

                        Address = "Minsk, Protos 5, 10",
                        SellerId = 1,
                    },
                    new House
                    {

                        Address = "Minsk, Drukova 332, 1",
                        SellerId = 2,
                    },
                    new House
                    {

                        Address = "Minsk, Modnova 2, 12",
                        SellerId = 3,
                    },
                    new House
                    {

                        Address = "Minsk, Terranova 2, 15",
                        SellerId = 1,
                    },
                    new House
                    {

                        Address = "Minsk, Lomonosova 5, 45",
                        SellerId = 1,
                    },
                    new House
                    {

                        Address = "Minsk, Kurganova 4, 5",
                        SellerId = 2,
                    },
                    new House
                    {

                        Address = "Minsk, Putina 25, 12",
                        SellerId = 3,
                    },
                    new House
                    {

                        Address = "Minsk, Protos 5, 10",
                        SellerId = 1,
                    },
                    new House
                    {

                        Address = "Minsk, Drukova 332, 1",
                        SellerId = 2,
                    },
                    new House
                    {

                        Address = "Minsk, Modnova 2, 12",
                        SellerId = 3,
                    },
                    new House
                    {

                        Address = "Minsk, Terranova 2, 15",
                        SellerId = 1,
                    },
                    new House
                    {

                        Address = "Minsk, Lomonosova 5, 45",
                        SellerId = 1,
                    },
                    new House
                    {

                        Address = "Minsk, Kurganova 4, 5",
                        SellerId = 2,
                    },
                    new House
                    {

                        Address = "Minsk, Putina 25, 12",
                        SellerId = 3,
                    },
                    new House
                    {

                        Address = "Minsk, Protos 5, 10",
                        SellerId = 1,
                    },
                    new House
                    {

                        Address = "Minsk, Drukova 332, 1",
                        SellerId = 2,
                    },
                    new House
                    {

                        Address = "Minsk, Modnova 2, 12",
                        SellerId = 3,
                    },
                    new House
                    {

                        Address = "Minsk, Terranova 2, 15",
                        SellerId = 1,
                    });

                _context.SaveChanges();
                _context.ContractTypes.AddRange(
                    new ContractType
                    {
                        Type = "Аренда"
                    },
                    new ContractType
                    {
                        Type = "Продажа"
                    });
                _context.Contracts.AddRange(
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 1,
                        EndDate = DateTime.Today.AddDays(15),
                        StartDate = DateTime.Today.AddDays(-15),
                        ContractTypeId = 1,
                        Price = 300M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 1,
                        EndDate = DateTime.Today.AddDays(-30),
                        StartDate = DateTime.Today.AddDays(-60),
                        ContractTypeId = 1,
                        Price = 500M
                    },
                    new Contract
                    {

                        BuyerId = 2,
                        EmployeeId = 1,
                        SellerId = 2,
                        HouseId = 2,
                        EndDate = DateTime.Today.AddMonths(2).AddDays(15),
                        StartDate = DateTime.Today.AddMonths(2).AddDays(-15),
                        ContractTypeId = 1,
                        Price = 200M
                    },
                    new Contract
                    {

                        BuyerId = 3,
                        EmployeeId = 1,
                        SellerId = 3,
                        HouseId = 3,
                        EndDate = DateTime.Today.AddMonths(2).AddDays(55),
                        StartDate = DateTime.Today.AddMonths(2).AddDays(-55),
                        ContractTypeId = 1,
                        Price = 1500M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 4,
                        EndDate = DateTime.Today.AddMonths(2).AddDays(95),
                        StartDate = DateTime.Today.AddMonths(3).AddDays(-95),
                        ContractTypeId = 1,
                        Price = 1200M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 2,
                        HouseId = 5,
                        EndDate = null,
                        StartDate = DateTime.Today.AddMonths(1).AddDays(-105),
                        ContractTypeId = 2,
                        Price = 30000M
                    },
                    new Contract
                    {

                        BuyerId = 3,
                        EmployeeId = 1,
                        SellerId = 3,
                        HouseId = 6,
                        EndDate = DateTime.Today.AddDays(15),
                        StartDate = DateTime.Today.AddDays(-15),
                        ContractTypeId = 1,
                        Price = 300M
                    },
                    new Contract
                    {

                        BuyerId = 2,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 7,
                        EndDate = DateTime.Today.AddDays(15),
                        StartDate = DateTime.Today.AddDays(-15),
                        ContractTypeId = 2,
                        Price = 700M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 1,
                        EndDate = DateTime.Today.AddDays(15),
                        StartDate = DateTime.Today.AddDays(-15),
                        ContractTypeId = 1,
                        Price = 300M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 1,
                        EndDate = DateTime.Today.AddMonths(6).AddDays(-30),
                        StartDate = DateTime.Today.AddMonths(6).AddDays(-60),
                        ContractTypeId = 1,
                        Price = 500M
                    },
                    new Contract
                    {

                        BuyerId = 2,
                        EmployeeId = 1,
                        SellerId = 2,
                        HouseId = 2,
                        EndDate = DateTime.Today.AddMonths(7).AddDays(15),
                        StartDate = DateTime.Today.AddMonths(7).AddDays(-15),
                        ContractTypeId = 1,
                        Price = 200M
                    },
                    new Contract
                    {

                        BuyerId = 3,
                        EmployeeId = 1,
                        SellerId = 3,
                        HouseId = 3,
                        EndDate = DateTime.Today.AddMonths(-4).AddDays(55),
                        StartDate = DateTime.Today.AddMonths(-4).AddDays(-55),
                        ContractTypeId = 1,
                        Price = 1500M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 4,
                        EndDate = DateTime.Today.AddMonths(-5).AddDays(95),
                        StartDate = DateTime.Today.AddMonths(-5).AddDays(-95),
                        ContractTypeId = 1,
                        Price = 1200M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 2,
                        HouseId = 5,
                        EndDate = null,
                        StartDate = DateTime.Today.AddMonths(-5).AddDays(-105),
                        ContractTypeId = 2,
                        Price = 30000M
                    },
                    new Contract
                    {

                        BuyerId = 3,
                        EmployeeId = 1,
                        SellerId = 3,
                        HouseId = 6,
                        EndDate = DateTime.Today.AddMonths(-4).AddDays(15),
                        StartDate = DateTime.Today.AddMonths(-4).AddDays(-15),
                        ContractTypeId = 1,
                        Price = 300M
                    },
                    new Contract
                    {

                        BuyerId = 2,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 7,
                        EndDate = DateTime.Today.AddMonths(-3).AddDays(15),
                        StartDate = DateTime.Today.AddMonths(-3).AddDays(-15),
                        ContractTypeId = 2,
                        Price = 700M
                    },
                   
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 1,
                        EndDate = DateTime.Today.AddDays(15),
                        StartDate = DateTime.Today.AddDays(-15),
                        ContractTypeId = 1,
                        Price = 300M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 1,
                        EndDate = DateTime.Today.AddDays(-30),
                        StartDate = DateTime.Today.AddDays(-60),
                        ContractTypeId = 1,
                        Price = 500M
                    },
                    new Contract
                    {

                        BuyerId = 2,
                        EmployeeId = 1,
                        SellerId = 2,
                        HouseId = 2,
                        EndDate = DateTime.Today.AddMonths(4).AddDays(15),
                        StartDate = DateTime.Today.AddMonths(4).AddDays(-15),
                        ContractTypeId = 1,
                        Price = 200M
                    },
                    new Contract
                    {

                        BuyerId = 3,
                        EmployeeId = 1,
                        SellerId = 3,
                        HouseId = 3,
                        EndDate = DateTime.Today.AddMonths(4).AddDays(55),
                        StartDate = DateTime.Today.AddMonths(4).AddDays(-55),
                        ContractTypeId = 1,
                        Price = 1500M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 4,
                        EndDate = DateTime.Today.AddMonths(5).AddDays(95),
                        StartDate = DateTime.Today.AddMonths(6).AddDays(-95),
                        ContractTypeId = 1,
                        Price = 1200M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 2,
                        HouseId = 5,
                        EndDate = null,
                        StartDate = DateTime.Today.AddMonths(6).AddDays(-105),
                        ContractTypeId = 2,
                        Price = 30000M
                    },
                    new Contract
                    {

                        BuyerId = 3,
                        EmployeeId = 1,
                        SellerId = 3,
                        HouseId = 6,
                        EndDate = DateTime.Today.AddDays(15),
                        StartDate = DateTime.Today.AddDays(-15),
                        ContractTypeId = 1,
                        Price = 300M
                    },
                    new Contract
                    {

                        BuyerId = 2,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 7,
                        EndDate = DateTime.Today.AddDays(15),
                        StartDate = DateTime.Today.AddDays(-15),
                        ContractTypeId = 2,
                        Price = 700M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 1,
                        EndDate = DateTime.Today.AddDays(15),
                        StartDate = DateTime.Today.AddDays(-15),
                        ContractTypeId = 1,
                        Price = 300M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 1,
                        EndDate = DateTime.Today.AddMonths(7).AddDays(-30),
                        StartDate = DateTime.Today.AddMonths(7).AddDays(-60),
                        ContractTypeId = 1,
                        Price = 500M
                    },
                    new Contract
                    {

                        BuyerId = 2,
                        EmployeeId = 1,
                        SellerId = 2,
                        HouseId = 2,
                        EndDate = DateTime.Today.AddMonths(-5).AddDays(15),
                        StartDate = DateTime.Today.AddMonths(-5).AddDays(-15),
                        ContractTypeId = 1,
                        Price = 200M
                    },
                    new Contract
                    {

                        BuyerId = 3,
                        EmployeeId = 1,
                        SellerId = 3,
                        HouseId = 3,
                        EndDate = DateTime.Today.AddMonths(-6).AddDays(55),
                        StartDate = DateTime.Today.AddMonths(-6).AddDays(-55),
                        ContractTypeId = 1,
                        Price = 1500M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 4,
                        EndDate = DateTime.Today.AddMonths(-7).AddDays(95),
                        StartDate = DateTime.Today.AddMonths(-7).AddDays(-95),
                        ContractTypeId = 1,
                        Price = 1200M
                    },
                    new Contract
                    {

                        BuyerId = 1,
                        EmployeeId = 1,
                        SellerId = 2,
                        HouseId = 5,
                        EndDate = null,
                        StartDate = DateTime.Today.AddMonths(-5).AddDays(-105),
                        ContractTypeId = 2,
                        Price = 30000M
                    },
                    new Contract
                    {

                        BuyerId = 3,
                        EmployeeId = 1,
                        SellerId = 3,
                        HouseId = 6,
                        EndDate = DateTime.Today.AddMonths(-4).AddDays(15),
                        StartDate = DateTime.Today.AddMonths(-4).AddDays(-15),
                        ContractTypeId = 1,
                        Price = 300M
                    },
                    new Contract
                    {

                        BuyerId = 2,
                        EmployeeId = 1,
                        SellerId = 1,
                        HouseId = 7,
                        EndDate = DateTime.Today.AddMonths(-3).AddDays(15),
                        StartDate = DateTime.Today.AddMonths(-3).AddDays(-15),
                        ContractTypeId = 2,
                        Price = 700M
                    });
                _context.SaveChanges();
            }
        }
    }
}
