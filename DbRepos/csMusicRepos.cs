using System;
using DbContext;
using DbModels;
using Models;

namespace DbRepos
{
    public interface IMusicRepos
    {
        public int Seed(int _nrOfItems);
        public List<csMusicGroup> ReadMusicGroups();
        public List<csAlbum> ReadAlbums();
    }

	public class csMusicRepos : IMusicRepos
    {
		public csMusicRepos()
		{
		}

        public int Seed(int _nrOfItems)
        {
            var sgen = new csSeedGenerator();
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                for (int i = 0; i < _nrOfItems; i++)
                {
                    var mg = new csMusicGroup().Seed(sgen);
                    var al = new csAlbum().Seed(sgen);

                    mg.Albums.Add(al);

                    db.MusicGroups.Add(mg);
                }

                db.SaveChanges();

                return db.MusicGroups.Count();
            }
        }

        public List<csMusicGroup> ReadMusicGroups()
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                var mg = db.MusicGroups.ToList();
                return mg;
            }
        }

        public List<csAlbum> ReadAlbums()
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                var al = db.Albums.ToList();
                return al;
            }
        }
    }
}

