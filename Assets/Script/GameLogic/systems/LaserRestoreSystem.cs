namespace Asteroid.GameLogic
{
    public class LaserRestoreSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            SpaceModel.playerData.laserTimeRestore -= deltaTime;
            if (SpaceModel.playerData.laserTimeRestore < 0)
            {
                SpaceModel.playerData.laserTimeRestore += Config.laserRestoreTime;
                SpaceModel.playerData.laserCount++;
            }
        }
    }
}