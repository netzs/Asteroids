using Asteroid.GameLogic;
using TMPro;
using UnityEngine;


namespace Asteroid.View
{
    public class UserInfoScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pos;
        [SerializeField] private TextMeshProUGUI speed;
        [SerializeField] private TextMeshProUGUI angle;
        [SerializeField] private TextMeshProUGUI laser;
        [SerializeField] private TextMeshProUGUI laserTime;
        [SerializeField] private TextMeshProUGUI score;

        public void SetData(IPlayerData playerDataInfo)
        {
            pos.text = $"Position: ({playerDataInfo.Position.x:N2}:{playerDataInfo.Position.y:N2})";
            speed.text = $"Speed: {playerDataInfo.Velocity.magnitude:N2}";
            angle.text = $"Angle: {playerDataInfo.Rotation.eulerAngles.z:N1}";
            laser.text = $"LaserCount: {playerDataInfo.LaserCount}";
            laserTime.text = $"LaserRestore: {playerDataInfo.LaserTimeRestore:N2}";
            score.text = $"Score:{playerDataInfo.Score}";
        }
    }
}