using System.Threading;
using System.Threading.Tasks;
using Model;

namespace Client{
    public interface IGameStateService {
        GameState Current { get; }

        Task Create(CancellationToken cancellationToken);
        Task Join(string key, CancellationToken cancellationToken);
        Task Leave(CancellationToken cancellationToken);
    }
}
