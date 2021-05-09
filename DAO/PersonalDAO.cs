using MusicOnlineDB.EF;
using MusicOnlineDB.Self_Created;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PersonalDAO
    {
        MyDB db = new MyDB();
        private static PersonalDAO instance;


        public static PersonalDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonalDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private PersonalDAO() { }
        /// <summary>
        /// Thêm một bài nhạc vào danh mục yêu thích của người dùng
        /// </summary>
        /// <param name="username"></param>
        /// <param name="songID"></param>
        public void AddFavouriteSong(int accountID,int songID)
        {
            Personal abc = db.Personals.FirstOrDefault(p => p.accountID == accountID && p.songID == songID);
            if (abc==null)
            {
                Personal personal = new Personal() { accountID = accountID, songID = songID };
                db.Personals.Add(personal);
                db.SaveChanges();
            }
            
        }

        public void AddFavouriteArtist(int accountID, int artistID)
        {
            Personal abc = db.Personals.FirstOrDefault(p => p.accountID == accountID && p.artistID==artistID);
            if (abc == null)
            {
                Personal personal = new Personal() { accountID = accountID, artistID = artistID };
                db.Personals.Add(personal);
                db.SaveChanges();
            }

        }


        public PersonalModel LoadPersonalPage(int id)
        {
            PersonalModel personal = new PersonalModel();
            personal.ListMusic = MusicDAO.Instance.getListFavouriteSongByAccountID(id);
            personal.ListArtist = ArtistDAO.Instance.getFavouriteArtistByAccountID(id);
            personal.ListMV = MusicDAO.Instance.getListFavouriteMVByAccountID(id);
            return personal;
        }
    }
}
