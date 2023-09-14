using System;
using DbContext;
using DbModels;
using DbRepos;
using Microsoft.Extensions.Logging;
using Models;
using Models.DTO;


namespace Services
{
    public interface IMusicService
    {
        public int Seed(int _nrOfItems);
        public List<csMusicGroup> ReadMusicGroups();
        public List<csAlbum> ReadAlbums();
        public List<csMusicGroup> OldestBand();
    }


	public class csMusicService : IMusicService
	{
        private ILogger<csMusicService> _logger = null;
        private IMusicRepos _repos; 

        #region constructors
        public csMusicService()
        {

        }        
        
        public csMusicService(IMusicRepos repos, ILogger<csMusicService> logger)
        {
            //only for layer verification
            string _instanceHello = $"Hello from class {this.GetType()}.";

            _repos = repos;
            _logger = logger;
            _logger.LogInformation(_instanceHello);
        }
        #endregion

        public int Seed(int _nrOfItems) => _repos.Seed(_nrOfItems);

        public List<csMusicGroup> ReadMusicGroups() => _repos.ReadMusicGroups();

        public List<csAlbum> ReadAlbums() => _repos.ReadAlbums();

        public List<csMusicGroup> OldestBand()
        {
            var mg = _repos.ReadMusicGroups();
            var ret = mg.OrderBy(i => i.EstablishedYear).Take(10).ToList();
            return ret;
        }
    }
}

