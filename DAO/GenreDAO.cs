using MusicOnlineDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GenreDAO
    {
        private static GenreDAO instance;
        MyDB db = new MyDB();
        public static GenreDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GenreDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private GenreDAO() { }

        public IEnumerable<Genre> getFavouriteGenreByAccountID(int id)
        {
            var list = (from p in db.Personals
                                join g in db.Genres on p.genreID equals g.genreID
                                where p.accountID == id
                                select new { genreID=g.genreID,genreName=g.genreName,genreImg=g.genreImg}).ToList();
            List<Genre> model = new List<Genre>();
            foreach (var item in list)
            {
                Genre genre = new Genre() { genreID = item.genreID, genreName = item.genreName, genreImg = item.genreImg };
                model.Add(genre);
            }

            return model as IEnumerable<Genre>;

        }

        public IEnumerable<Genre> getListGenre()
        {
            IEnumerable<Genre> model = db.Genres.ToList();
            return model;
        }
    }
}
