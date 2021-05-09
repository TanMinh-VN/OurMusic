using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOnlineDB.Self_Created
{
    public class SongModel
    {
        public int songID { get; set; }
        public string songName { get; set; }
        public string songArtist { get; set; }
        public string songUrl { get; set; }
        public string imgUrl { get; set; }
        public string genreName { get; set; }
    }
}
