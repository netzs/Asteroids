namespace Asteroid.GameLogic
{
    public class SpawnBulletSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            foreach (var item in SpaceModel.BulletSpawnData)
            {
                var obj = SpaceObjectFactory.CreateBullet();
                obj.position = item.pos;
                obj.velocity = item.dir.normalized * Config.bullet.speed;
                SpaceModel.spaceObject.Add(obj);
            }
        }
    }
}