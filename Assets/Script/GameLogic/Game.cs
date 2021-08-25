using UnityEngine;

namespace Asteroid.GameLogic
{
    public class Game
    {
        private readonly SpaceModel _spaceModel = new SpaceModel();

        public ISpaceModel SpaceModel => _spaceModel;

        private readonly SpaceSystem[] _workSystems;

        public Game(GameLogicConfig logicConfig)
        {
            _spaceModel.playerData = new PlayerData {Config = logicConfig.playerConfig};

            _workSystems = new SpaceSystem[]
            {
                new ObjectUnionSystem(),
                new CollisionSystem(),
                new PlayerCollisionSystem(),
                new LaserRestoreSystem(),
                new LaserWeaponSystem(),
                new LaserWeaponCollisionSystem(),
                new DestroyAsteroidSystem(),
                new LeaveAreaSystem(),
                new AsteroidRespawnSystem(),
                new PlayerHuntSystem(),
                new PlayerControllerSystem(),
                new PlayerFireSystem(),
                new SpawnBulletSystem(),
                new MoveSystem(),
                new EnemyCreatorSystem(),
                new EndTickSystem()
            };

            var factory = new SpaceObjectFactory(logicConfig);
            foreach (var workSystem in _workSystems)
            {
                workSystem.Init(logicConfig, _spaceModel, factory);
            }
        }

        public void NextTimer(float deltaTime)
        {
            if (_spaceModel.state == GameState.Game)
            {
                foreach (var system in _workSystems)
                {
                    system.Run(deltaTime);
                }
            }
        }

        public void Input(Vector2 input, bool isSuper)
        {
            _spaceModel.playerData.Input = input;
            _spaceModel.playerData.isLaser = isSuper;
        }

        public void StartGame()
        {
            _spaceModel.Reset();
            _spaceModel.state = GameState.Game;
        }
    }
}