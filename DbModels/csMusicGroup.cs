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

        public csMusicGroup()
		{
		}
    }
}

