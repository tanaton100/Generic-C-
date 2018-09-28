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
    public interface IUserRepository
    {
        List<User> GetAll();
        User FindById(int id);
        int Add(User entity);
        int Update(User entity);
        int Delete(User entity);
    }

    public class UserRepository : GenericReposiory<User>, IUserRepository
    {
        public override string CreateSeleteString()
        {
            return "SELECT * FROM [User]";
        }
     

        public override int Add(User entity)
        {
            var sqlCommand = string.Format(@"INSERT INTO [User] ([Name]) VALUES (@Name)");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Name
            });
        }

        public override int Update(User entity)
        {
            var sqlCommand = string.Format(@"UPDATE [User] SET [Name] = @Name WHERE [Id] = @Id");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Id
            });
        }

        public override int Delete(User entity)
        {
            var sqlCommand = string.Format(@"DELETE FROM [User] WHERE [Id] = @Id");
            return this.DbConnection.Execute(sqlCommand, new
            {
                entity.Id
            });
        }
    }
}