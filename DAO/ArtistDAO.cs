using MusicOnlineDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ArtistDAO
    {
        private static ArtistDAO instance;
        MyDB db = new MyDB();
        public static ArtistDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArtistDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private ArtistDAO() { }

        public IEnumerable<Artist> getListArtist()
        {
            IEnumerable<Artist> model = db.Artists.Where(q=>q.artistName!="Unknown").ToList();
            return model;
        }

        public Artist getArtistByID(int artistID)
        {
            Artist artist = new Artist();
            artist = db.Artists.FirstOrDefault(q => q.artistID == artistID);
            return artist;
        }
        public IEnumerable<Artist> getFavouriteArtistByAccountID(int id)
        {
            var list = (from p in db.Personals
                        join a in db.Artists on p.artistID equals a.artistID
                        where p.accountID == id
                        select new
                        {
                            artistID=a.artistID,
                            artistName=a.artistName,
                            artistImg=a.artistImg,
                            date=a.date,
                            sex=a.sex,
                            nation=a.nation,
                            about=a.about
                        }).ToList();
            List<Artist> model = new List<Artist>();
            foreach (var item in list)
            {
                Artist a = new Artist()
                {
                    artistID = item.artistID,
                    artistName = item.artistName,
                    artistImg = item.artistImg,
                    date = item.date,
                    sex = item.sex,
                    nation = item.nation,
                    about = item.about
                };
                model.Add(a);
            }
            return model as IEnumerable<Artist> ;
        }

        public IEnumerable<string> getListNation()
        {
            var list = db.Artists.Select(x => x.nation).Distinct().ToList();
            List<string> model = new List<string>();
            foreach (var item in list)
            {
                string nation = item;
                model.Add(nation);

            }
            return list as IEnumerable<string>;
        }

        public IEnumerable<Artist> searchArtist(string keyword)
        {
            IEnumerable<Artist> model = db.Artists.Where(q => q.artistName.Contains(keyword)).ToList();
            return model;
        }
    }
}
