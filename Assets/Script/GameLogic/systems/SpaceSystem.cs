namespace Asteroid.GameLogic
{
    public abstract class SpaceSystem
    {
        protected GameLogicConfig Config;
        protected SpaceModel SpaceModel;
        protected SpaceObjectFactory SpaceObjectFactory;

        public void Init(GameLogicConfig logicConfig, SpaceModel spaceModel, SpaceObjectFactory spaceObjectFactory)
        {
            Config = logicConfig;
            SpaceModel = spaceModel;
            SpaceObjectFactory = spaceObjectFactory;
        }

        public abstract void Run(float deltaTime);
    }
}