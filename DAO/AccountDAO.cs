using MusicOnlineDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        MyDB db = new MyDB();
        private static AccountDAO instance;


        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private AccountDAO() { }
        public Account getAccount(string userName, string password)
        {

            //dùng LinQ 
            return db.Accounts.Where(q => q.username == userName && q.password == password).FirstOrDefault();
        }
        /// <summary>
        /// Kiểm tra xác thực tài khoản có hợp lệ
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool VerifyAccount(string userName, string password)
        {
            var a = db.Accounts.Where(b => b.username == userName && b.password == password).SingleOrDefault();
            return a == null ? false : true;
        }
        /// <summary>
        /// Lấy ra đối tượng tài khoản sử dụng Username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Account GetAccountByUsername(string username)
        {
            return db.Accounts.FirstOrDefault(a => a.username == username);
        }
    }
}
