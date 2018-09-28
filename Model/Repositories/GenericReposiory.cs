using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Model.Models;

namespace Model.Repositories
{
    public abstract class GenericReposiory<TModel>
    {
        public IDbConnection DbConnection { get; set; }

        protected GenericReposiory()
        {
            this.DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        
         public List<TModel> GetAll()
         {
             
            return DbConnection.Query<TModel>(CreateSeleteString()).ToList();
         }

        public TModel FindById(int id)
        {
            return this.DbConnection.Query<TModel>(CreateSeleteString()+ " WHERE Id = @Id", new
            {
                id
            }).FirstOrDefault();
        }

        public abstract string CreateSeleteString();
        public abstract int  Update(TModel tModel);
        public abstract int Delete(TModel tModel);
        public abstract int Add(TModel tModel);
    }
}