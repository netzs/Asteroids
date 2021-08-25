namespace Asteroid.GameLogic
{
    public class ObjectUnionSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            SpaceModel.spaceObject.ReleaseObject();
        }
    }
}