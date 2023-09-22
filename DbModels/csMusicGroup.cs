using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Linq;

using Configuration;
using Models;
using Models.DTO;

namespace DbModels
{
    public class csMusicGroup : ISeed<csMusicGroup>
    {
        [Key]       // for EFC Code first
        public Guid MusicGroupId { get; set; }

        public string Name { get; set; }
        public int EstablishedYear { get; set; }

        public bool Seeded { get; set; } = true;

        public List<csAlbum> Albums { get; set; } = new List<csAlbum>();        //for EFC Code first

        public csMusicGroup()
        {
        }

        public csMusicGroup Seed(csSeedGenerator sgen)
        {
            var mg = new csMusicGroup
            {
                MusicGroupId = Guid.NewGuid(),
                Name = sgen.MusicBand,
                EstablishedYear = sgen.Next(1970, 2023),
                Seeded = true
            };
            return mg;
        }
    }

    public class csAlbum : ISeed<csAlbum>
    {
        [Key]       // for EFC Code first
        public Guid AlbumId { get; set; }

        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public long CopiesSold { get; set; }

        public bool Seeded { get; set; } = true;

        public csMusicGroup MusicGroup { get; set; }

        public csAlbum()
        {
        }
        public csAlbum Seed(csSeedGenerator sgen)
        {
        
            var al = new csAlbum
            {
                AlbumId = Guid.NewGuid(),
                Name = sgen.MusicAlbum,
                CopiesSold = sgen.Next(1000, 1000000),
                ReleaseYear = sgen.Next(1970, 2023),
                Seeded = true
            };
            return al;
        }
    }
}

