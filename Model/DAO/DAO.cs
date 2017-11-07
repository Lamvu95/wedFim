using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class UserDAO
    {
        WebFilmEntities db = null;
        public UserDAO()
        {
            db = new WebFilmEntities();
        }
        public long Insert(Table_Username entity)
        {
            db.Table_Username.Add(entity);

            return db.SaveChanges();

        }
        public Table_Username getid(string Username)
        {
            return db.Table_Username.SingleOrDefault(x => x.NameUser == Username);
        }
        public bool Login(string username, string password)
        {
            var result = db.Table_Username.Count(x => x.NameUser == username && x.PassUser == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Kt(string anhphim)
        {
            var result = db.Table_Fim.Count(x => x.AnhPhim == anhphim);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
