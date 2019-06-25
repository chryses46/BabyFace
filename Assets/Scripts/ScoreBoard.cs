using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BabyGame
{
    public class ScoreBoard : MonoBehaviour
    {
        public int Score {get; set;}
        public int HighScore {get; set;}

        public void SetHighScore()
        {
            if(Score > HighScore)
            {
                HighScore = Score;
            }
        }

    }
}
