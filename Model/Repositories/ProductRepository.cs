using Dapper;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Model.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product FindBy(int id);
        int Add(Product entity);
        int Update(Product entity);
        int Delete(Product entity);
    }

    public class ProductRepository : GenericReposiory<Product>, IProductRepository
    {
        public override string CreateSeleteString()
        {
            return "SELECT * FROM [Product]";
        }



        public Product FindBy(int id)
        {
            var sqlCommand = string.Format(@"SELECT  * FROM[POP_DEMO].[dbo].[Product] where Id = @Id");
            return this.DbConnection.Query<Product>(sqlCommand, new
            {
                id
            }).FirstOrDefault();
        }

        public int Add(Product entity)
        {
            var sqlCommand = string.Format(@"INSERT INTO[dbo].[Product]([Name],[Price])VALUES (@Name, @Price)");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Price
            });
        }

        public int Update(Product entity)
        {
            var sqlCommand = string.Format(@"UPDATE [dbo].[Product] SET [Name] = @Name ,[Price] = @Price WHERE [Id] = @Id");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Price,
                entity.Id
            });
        }

        public int Delete(Product entity)
        {
            var sqlCommand = string.Format(@"DELETE FROM [dbo].[Product] WHERE Id = @Id");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Id
            });
        }
    }
}