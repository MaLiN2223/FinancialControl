using System;
using System.Collections.Generic;
using System.Linq;
using FinancialControl.Database;
using FinancialControl.Database.Tables;
using FinancialControl.Repositories;
using FinancialControl.Repositories.Dto;
using Utils;
using Category = FinancialControl.Repositories.Category;
using Color = FinancialControl.Database.Tables.Color;
using Location = FinancialControl.Database.Tables.Location;
using Product = FinancialControl.Database.Tables.Product;
using Receipt = FinancialControl.Repositories.Dto.Receipt;

namespace FinancialControl.Service
{
    public class DatabaseProxy : IDataAccessProxy
    {
        public List<Category> GetCategories()
        {
            return Get(context =>
            {
                var categories = context.Categories.Select(x => x).ToList();
                return categories.Select(x => new Category()
                {
                    Color = new FinancialControl.Repositories.Color { R = x.Color.R, G = x.Color.G, B = x.Color.B },
                    Description = x.Description,
                    Title = x.Title
                }).ToList();
            });
        }

        public void CreateUser(string login, string password)
        {
            Do(x => x.Users.Add(new User { Login = login, Password = password.Hash() }));
        }

        public List<string> GetUsers()
        {
            return Get(x => x.Users.Select(user => user.Login).ToList());
        }


        public void AddReceipt(Receipt receipt)
        {
            Do(x =>
            {
                x.Receipts.Add(new Database.Tables.Receipt
                {
                    Products = receipt.Products.Select(y => new Product()
                    {
                        Price = y.Price,
                        Volume = y.Volume,
                        Name = y.Name
                    }).ToList(),
                    Date = receipt.Date.ToDateTimeUnspecified(),
                    Location = new Location
                    {
                        Name = receipt.Location.Name
                    }

                });
            });
        }

        public void AddCategory(Category category)
        {
            Do(x => x.Categories.Add(new Database.Tables.Category()
            {
                Color = new Color() { R = category.Color.R, G = category.Color.G, B = category.Color.B },
                Title = category.Title,
                Description = category.Description
            }));
        }

        private void Do(Action<DatabaseContext> action)
        {
            using (var ctx = new DatabaseContext())
            {
                action(ctx);
                ctx.SaveChanges();
            }
        }

        private T Get<T>(Func<DatabaseContext, T> action)
        {
            using (var ctx = new DatabaseContext())
            {
                return action(ctx);
            }
        }
    }
}