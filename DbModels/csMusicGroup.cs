using System;
using System.ComponentModel.DataAnnotations;

namespace DbModels
{
    public class csMusicGroup
    {
        [Key]       // for EFC Code first
        public Guid MusicGroupId { get; set; }
        
        public string Name { get; set; }
        public int EstablishedYear { get; set; }

        public List<csAlbum> Albums { get; set; } = new List<csAlbum>();        //for EFC Code first

        public csMusicGroup()
        {
        }
    }

    public class csAlbum
    {
        [Key]       // for EFC Code first
        public Guid AlbumId { get; set; }

        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public long CopiesSold { get; set; }

        public List<csMusicGroup> MusicGroup { get; set; } = new List<csMusicGroup>();

        public csAlbum()
        {
        }
    }
}

