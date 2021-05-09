
using MusicOnlineDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using MusicOnlineDB.Self_Created;


namespace DAO
{
    public class MusicDAO
    {
        private static MusicDAO instance;
        MyDB db = new MyDB();
        public static MusicDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MusicDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private MusicDAO() { }
        /// <summary>
        /// Lấy ra danh sách nhạc cho pagedList
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<SongModel> getListMusic(int page,int pageSize)
        {

            IEnumerable<SongModel> model = (from s in db.Songs join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID join g in db.Genres on s.genreID equals g.genreID
                                            where s.type==0
                                            select new SongModel {
                                                songID=s.songID,
                                                songName=s.songName,
                                                songUrl=s.songUrl,
                                                songArtist=a.artistName,
                                                genreName=g.genreName,
                                                imgUrl=s.songImg
                                            }).OrderByDescending(x => x.songName).ToPagedList(page, pageSize);
            return model;
        }
        /// <summary>
        /// Lấy danh sách nhạc
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SongModel> getListMusic()
        {

            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            where s.type==0
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();
            return model;
        }
        /// <summary>
        /// Lấy ra bài hát bằng ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SongModel getSongByID(int id)
        {

            SongModel model = (from s in db.Songs
                               join sh in db.Shows on s.songID equals sh.songID
                               join a in db.Artists on sh.artistID equals a.artistID
                               join g in db.Genres on s.genreID equals g.genreID
                               where s.songID==id & s.type==0
                               select new SongModel
                               {
                                   songID = s.songID,
                                   songName = s.songName,
                                   songUrl = s.songUrl,
                                   songArtist = a.artistName,
                                   genreName = g.genreName,
                                   imgUrl = s.songImg
                               }).FirstOrDefault();
            return model;
        }
        /// <summary>
        /// Lấy danh sách bài hát yêu thích bằng accountID
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public IEnumerable<SongModel> getListFavouriteSongByAccountID(int accountID)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            join p in db.Personals on s.songID equals p.songID
                                        where p.accountID == accountID & s.type==0
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();

            return model;
        }

        public IEnumerable<SongModel> getListFavouriteMVByAccountID(int accountID)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            join p in db.Personals on s.songID equals p.songID
                                            where p.accountID == accountID & s.type == 1
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();

            return model;
        }
        /// <summary>
        /// Lấy danh sách MV Việt Nam
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SongModel> getListMV()
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            where  s.type == 1&&(a.nation=="Việt Nam"|| a.nation == "Unknown")
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();
            return model;
        }
        public IEnumerable<SongModel> getListUsUkMV()
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            where s.type == 1 && (a.nation == "US-UK")
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();
            return model;
        }
        public IEnumerable<SongModel> getListKpopMV()
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            where s.type == 1 && a.nation == "Kpop"
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();
            return model;
        }
        /// <summary>
        ///Tìm MV bằng ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SongModel getMVByID(int id)
        {
            SongModel mv = (from s in db.Songs
                            join sh in db.Shows on s.songID equals sh.songID
                            join a in db.Artists on sh.artistID equals a.artistID
                            join g in db.Genres on s.genreID equals g.genreID
                            where s.type == 1 & s.songID==id
                            select new SongModel
                            {
                                songID = s.songID,
                                songName = s.songName,
                                songUrl = s.songUrl,
                                songArtist = a.artistName,
                                genreName = g.genreName,
                                imgUrl = s.songImg
                            }).FirstOrDefault();
            return mv;
        }
        /// <summary>
        /// Lấy danh sách bài hát theo nghệ sĩ
        /// </summary>
        /// <param name="artistID"></param>
        /// <returns></returns>
        public IEnumerable<SongModel> getListSongByArtistID(int artistID)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID

                                            where s.type == 0 && a.artistID==artistID
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();
            return model;
        }
        /// <summary>
        /// Lấy danh sách nhạc theo Quốc gia
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="nation"></param>
        /// <returns></returns>
        public IEnumerable<SongModel> getListMusicByNation(int page, int pageSize,string nation)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            where s.type == 0 && a.nation==nation
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).Take(20).OrderByDescending(x => x.songName).ToPagedList(page, pageSize);
            return model;
        }

        /// <summary>
        /// Lấy danh sách nhạc theo Thể loại
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="genreID"></param>
        /// <returns></returns>
        public IEnumerable<SongModel> getListMusicByGenreID(int page, int pageSize, int genreID)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            where s.type == 0 && g.genreID==genreID
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).Take(20).OrderByDescending(x => x.songName).ToPagedList(page, pageSize);
            return model;
        }

        /// <summary>
        /// Lấy danh sách nhạc theo Tag
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="tagID"></param>
        /// <returns></returns>
        public IEnumerable<SongModel> getListMusicByTagID(int page, int pageSize, int tagID)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            join st in db.SongTags on s.songID equals st.songID
                                            join t in db.Tags on st.tagID equals t.tagID
                                            where s.type == 0 && t.tagID==tagID
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).Take(20).OrderByDescending(x => x.songName).ToPagedList(page, pageSize);
            return model;
        }

        /// <summary>
        /// Lấy danh sách nhạc tương tự
        /// </summary>
        /// <param name="genreName"></param>
        /// <returns></returns>
        public IEnumerable<SongModel> getListSimilarSong(string genreName)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID

                                            where s.type == 0 && g.genreName==genreName
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).Take(10).ToList();
            return model;
        }

        /// <summary>
        /// Lấy danh sách nhạc có thể bạn muốn
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SongModel> getListWannaSong()
        {
            Random rd = new Random();
            int numRand;
            List<SongModel> list = (from s in db.Songs
                                     join sh in db.Shows on s.songID equals sh.songID
                                     join a in db.Artists on sh.artistID equals a.artistID
                                     join g in db.Genres on s.genreID equals g.genreID
                                     where s.type == 0
                                     select new SongModel
                                     {
                                         songID = s.songID,
                                         songName = s.songName,
                                         songUrl = s.songUrl,
                                         songArtist = a.artistName,
                                         genreName = g.genreName,
                                         imgUrl = s.songImg
                                     }).ToList();
            IEnumerable <SongModel> model= list.Skip(rd.Next(1,75)).Take(15).ToList();
            return model;
        }
        /// <summary>
        /// Lấy danh sách MV tương tự
        /// </summary>
        /// <param name="genreName"></param>
        /// <returns></returns>
        public IEnumerable<SongModel> getListSimilarMV(string genreName)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID

                                            where s.type == 1 && g.genreName == genreName
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).Take(5).ToList();
            return model;
        }

        public IEnumerable<SongModel> searchSong(string keyword)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            where s.type == 0 && s.songName.Contains(keyword)
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).Take(10).ToList();
            return model;
        }

        public IEnumerable<SongModel> searchMV(string keyword)
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            where s.type == 1 && s.songName.Contains(keyword)
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();
            return model;
        }

        public IEnumerable<SongModel> getVietNamSongChart()
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            join c in db.Charts on s.songID equals c.songID
                                            where s.type == 0&&a.nation== "Việt Nam"
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();
            return model;
        }

        public IEnumerable<SongModel> getUSUKSongChart()
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            join c in db.Charts on s.songID equals c.songID
                                            where s.type == 0 && a.nation == "US-UK"
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();
            return model;
        }

        public IEnumerable<SongModel> getKpopSongChart()
        {
            IEnumerable<SongModel> model = (from s in db.Songs
                                            join sh in db.Shows on s.songID equals sh.songID
                                            join a in db.Artists on sh.artistID equals a.artistID
                                            join g in db.Genres on s.genreID equals g.genreID
                                            join c in db.Charts on s.songID equals c.songID
                                            where s.type == 0 && a.nation == "Kpop"
                                            select new SongModel
                                            {
                                                songID = s.songID,
                                                songName = s.songName,
                                                songUrl = s.songUrl,
                                                songArtist = a.artistName,
                                                genreName = g.genreName,
                                                imgUrl = s.songImg
                                            }).ToList();
            return model;
        }
    }
}
