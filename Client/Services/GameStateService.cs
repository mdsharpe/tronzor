using System;
using System.Threading;
using System.Threading.Tasks;
using Model;
using Model.Services;

namespace Client
{
    public class GameStateService : IGameStateService
    {
        private readonly IGameKeyFactory _gameKeyFactory;

        public GameState Current { get; private set; }

        public GameStateService(IGameKeyFactory gameKeyFactory)
        {
            if (gameKeyFactory == null)
            {
                throw new ArgumentNullException(nameof(gameKeyFactory));
            }

            _gameKeyFactory = gameKeyFactory;
        }

        public async Task Create(CancellationToken cancellationToken)
        {
            var key = _gameKeyFactory.Create();
            Current = new GameState(key, 1024, 768);
        }

        public async Task Join(string key, CancellationToken cancellationToken) {
        }

        public async Task Leave(CancellationToken cancellationToken) {
            Current = null;
        }
    }
}
