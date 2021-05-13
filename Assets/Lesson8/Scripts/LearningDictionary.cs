using System.Collections.Generic;
using UnityEngine;

namespace Learning
{
    public class LearningDictionary : MonoBehaviour
    {
        public Dictionary<string, int> scores = new Dictionary<string, int>();

        private void Start() {
            scores.Add("A", 10);
            scores.Add("B", 15);
            scores.Add("C", 5);
            scores.Add("D", 30);
        }
    }
}
