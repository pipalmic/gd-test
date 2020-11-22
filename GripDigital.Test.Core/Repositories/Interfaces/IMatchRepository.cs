using System.Collections.Generic;
using System.Threading.Tasks;
using GripDigital.Test.Core.Entities;

namespace GripDigital.Test.Core.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetActive();
    }
}