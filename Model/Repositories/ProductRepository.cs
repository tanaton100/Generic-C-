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
            return "SELECT * FROM [Product] ";
        }

        public override string SeleteIdString()
        {
            return @"SELECT  * FROM[POP_DEMO].[dbo].[Product] where Id = @Id";
        }

       

        public override int Add(Product entity)
        {
            var sqlCommand = string.Format(@"INSERT INTO[dbo].[Product]([Name],[Price])VALUES (@Name, @Price)");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Price
            });
        }

        public override int Update(Product entity)
        {
            var sqlCommand = string.Format(@"UPDATE [dbo].[Product] SET [Name] = @Name ,[Price] = @Price WHERE [Id] = @Id");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Price,
                entity.Id
            });
        }

        public override int Delete(Product entity)
        {
            var sqlCommand = string.Format(@"DELETE FROM [dbo].[Product] WHERE Id = @Id");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Id
            });
        }
    }
}