using System.Collections.Generic;
using UnityEngine;

namespace Learning
{
    public class LearningList : MonoBehaviour
    {
        public List<string> leaderboard = new List<string>();

        private void Start() {
            leaderboard.Add("A");
            leaderboard.Add("B");
            leaderboard.Add("C");
            leaderboard.Add("D");
        }
    }
}
