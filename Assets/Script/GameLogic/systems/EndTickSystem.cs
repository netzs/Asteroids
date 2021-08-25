namespace Asteroid.GameLogic
{
    public class EndTickSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            SpaceModel.EndTick();
        }
    }
}