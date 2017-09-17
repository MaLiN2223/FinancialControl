using System;
using System.Collections.Generic;
using FinancialControl.Database;
using System.Linq;
using FinancialControl.Repositories;
using ServiceStack;
using ServiceStack.Html;
using Utils;
using Category = FinancialControl.Repositories.Category;

public class DatabaseProxy : IDataAccessProxy
{
    public List<Category> GetCategories()
    {
        return Get(context => context.Categories.Select(x => new Category()
        {
            Color = System.Drawing.Color.FromArgb(x.Color.R, x.Color.G, x.Color.B),
            Description = x.Description,
            Title = x.Title
        }).ToList());
    }

    public void CreateUser(string login, string password)
    {
        Do(x => x.Users.Add(new User { Login = login, Password = password.Hash() }));
    }

    public List<string> GetUsers()
    {
        return Get(x => x.Users.Select(user => user.Login).ToList());
    }

    public void AddCategory(Category category)
    {
        Do(x => x.Categories.Add(new FinancialControl.Database.Category()
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