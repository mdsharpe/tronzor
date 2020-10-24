using System.Threading;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IGameApiService
    {
        Task<string> GetHelloWorld(CancellationToken cancellationToken);
    }
}