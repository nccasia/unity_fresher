using UnityEngine;

namespace Learning
{
    public class LearningArray : MonoBehaviour
    {
        public int[] highscores = new int[4];
        public string[] leaderboard = new string[] { "A", "B", "C", "D" };

        private void Start() {
            highscores[0] = 100;
            highscores[1] = 13;
            highscores[2] = 76;
            highscores[3] = 50;

            for(int lvl = 0; lvl < highscores.Length; lvl++) {
                Debug.Log("Highscore: " + highscores[lvl]); //asset
                highscores[lvl] = 0; //modify
            } 

            for(int lvl = 0; lvl < highscores.Length; lvl++) {
                Debug.Log("Highscore: " + highscores.GetValue(lvl)); //asset
                highscores.SetValue(lvl, 0); //modify
            } 
        }
    }
}
