using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicOnlineDB.EF;

namespace MusicOnlineDB.Self_Created
{
    public class PersonalModel
    {
        public IEnumerable<SongModel> ListMusic = new List<SongModel>();
        public IEnumerable<Artist> ListArtist = new List<Artist>();
        public IEnumerable<SongModel> ListMV = new List<SongModel>();
    }
}
