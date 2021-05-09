using MusicOnlineDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TagDAO
    {
        private static TagDAO instance;
        MyDB db = new MyDB();
        public static TagDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TagDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private TagDAO() { }

        public IEnumerable<Tag> getListTag ()
        {
            IEnumerable<Tag> model = db.Tags.ToList();
            return model;
        }
    }
}
