using System;
using System.Collections.Generic;

#nullable disable

namespace Alicia.Data.Entities
{
    public partial class Podcaster
    {
        public Guid PodcasterId { get; set; }
        public string PodcasterName { get; set; }
        public int PodcasterBalance { get; set; }
    }
}
