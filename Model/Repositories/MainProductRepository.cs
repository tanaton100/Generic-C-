using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using Model.Models;

namespace Model.Repositories
{
    public interface IMainProductRepository
    {
        List<MainProduct> GetAll();
        MainProduct FindBy(int id);
        int Add(MainProduct entity);
        int Update(MainProduct entity);
        int Delete(MainProduct entity);
        MainProduct FindByName(string name);
    }

    public class MainProductRepository : GenericReposiory<MainProduct>, IMainProductRepository
    {

        public override string CreateSeleteString()
        {
            return "SELECT * FROM [MainProduct] ";
        }

        public override int Add(MainProduct entity)
        {
            var sqlCommand = string.Format(@"INSERT INTO [dbo].[MainProduct] ([Name]) VALUES (@Name)");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Name    
            });
        }

        public override int Update(MainProduct entity)
        {
            var sqlCommand = string.Format(@"Update [dbo].[MainProduct] SET [Name] = @Name where [Id] = @Id ");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Id
            });
        }

        public override int Delete(MainProduct entity)
        {
            var sqlCommand = string.Format(@"DELETE FROM [MainProduct]  where [Id] = @Id ");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Id
            });
        }

        public MainProduct FindByName(string name)
        {
            return this.DbConnection.Query<MainProduct>(CreateSeleteString() + " where Name = @Name", new
            {
                name 
            }).FirstOrDefault();
        }
    }
}