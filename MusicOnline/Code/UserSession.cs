using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicOnline.Code
{
    [Serializable]
    public class UserSession
    {
        public int AccountID { get; set; }
        public string UserName { set; get; }
        public string FullName { get; set; }
    }
}