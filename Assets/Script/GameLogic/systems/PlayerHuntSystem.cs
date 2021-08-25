namespace Asteroid.GameLogic
{
    public class PlayerHuntSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            foreach (var item in SpaceModel.spaceObject.Objects)
            {
                if (item.Value is UfoData)
                {
                    item.Value.velocity = (SpaceModel.playerData.position - item.Value.position).normalized;
                }
            }
        }
    }
}