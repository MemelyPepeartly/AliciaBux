using Alicia.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alicia.Logic.Interfaces
{
    public interface IAliciatory
    {
        /// <summary>
        /// Creates a new podcaster
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task CreateNewPodcaster(string name, Guid newPodcasterGUID);
        /// <summary>
        /// Up the bux of a podcaster by 1
        /// </summary>
        /// <param name="podcasterID"></param>
        /// <returns></returns>
        Task GiveBux(Guid podcasterID);
        /// <summary>
        /// Takes 1 Aliciabuk from an anon
        /// </summary>
        /// <param name="podcasterID"></param>
        /// <returns></returns>
        Task TakeBux(Guid podcasterID);
        /// <summary>
        /// Returns a list of all podcaster info
        /// </summary>
        /// <returns></returns>
        Task<List<Podcaster>> GetAllPodcasters();
        Task<Podcaster> GetPodcasterByID(Guid podcasterID);
        /// <summary>
        /// Saves the context
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
