using Alicia.Logic.Interfaces;
using Alicia.Logic.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiAliciaContext = Alicia.Data.Entities.HiAliciaContext;

namespace Alicia.Data.Repository
{
    public class Aliciatory : IAliciatory
    {
        private readonly HiAliciaContext aliciaContext;

        public Aliciatory(HiAliciaContext _context)
        {
            aliciaContext = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task CreateNewPodcaster(string name, Guid newPodcasterGUID)
        {
            Entities.Podcaster contextPodcaster = new Entities.Podcaster()
            {
                PodcasterId = newPodcasterGUID,
                PodcasterName = name,
                PodcasterBalance = 0
            };
            await aliciaContext.Podcasters.AddAsync(contextPodcaster);
        }

        public async Task<List<Podcaster>> GetAllPodcasters()
        {
            List<Podcaster> logicPodcasters = await aliciaContext.Podcasters.Select(contextPodcaster => new Podcaster()
            {
                podcasterID = contextPodcaster.PodcasterId,
                podcasterName = contextPodcaster.PodcasterName,
                podcasterBalance = contextPodcaster.PodcasterBalance
            }).ToListAsync();
            return logicPodcasters;
        }

        public async Task<Podcaster> GetPodcasterByID(Guid podcasterID)
        {
            Podcaster logicPodcaster = await aliciaContext.Podcasters.Select(contextPodcaster => new Podcaster()
            {
                podcasterID = contextPodcaster.PodcasterId,
                podcasterName = contextPodcaster.PodcasterName,
                podcasterBalance = contextPodcaster.PodcasterBalance
            }).AsNoTracking().FirstOrDefaultAsync(p => p.podcasterID == podcasterID);
            return logicPodcaster;
        }

        public async Task GiveBux(Guid podcasterID)
        {
            Entities.Podcaster contextPodcaster = await aliciaContext.Podcasters.FirstOrDefaultAsync(p => p.PodcasterId == podcasterID);
            contextPodcaster.PodcasterBalance += 1;
            aliciaContext.Podcasters.Update(contextPodcaster);
        }
        public async Task TakeBux(Guid podcasterID)
        {
            Entities.Podcaster contextPodcaster = await aliciaContext.Podcasters.FirstOrDefaultAsync(p => p.PodcasterId == podcasterID);
            contextPodcaster.PodcasterBalance -= 1;
            aliciaContext.Podcasters.Update(contextPodcaster);
        }

        public async Task SaveAsync()
        {
            await aliciaContext.SaveChangesAsync();
        }
    }
}
