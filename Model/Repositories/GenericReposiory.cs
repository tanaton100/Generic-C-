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

        public GenericReposiory()
        {
            this.DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        
         public List<TModel> GetAll()
         {
             
            return DbConnection.Query<TModel>(CreateSeleteString()).ToList();
        }

        public TModel FindBy(int id)
        {
            return this.DbConnection.Query<TModel>(SeleteIdString(), new
            {
                id
            }).FirstOrDefault();
        }

        public abstract string CreateSeleteString();
        public abstract string SeleteIdString();
        public abstract int  Update(TModel tModel);
        public abstract int Delete(TModel tModel);
        public abstract int Add(TModel tModel);
    }
}