using TMPro;
using UnityEngine;

namespace Asteroid.View
{
    public class GameOverScreen : MonoBehaviour
    {
        public TextMeshProUGUI score;

        public void SetData(int playerScore)
        {
            score.text = $"You score: {playerScore}";
        }
    }
}