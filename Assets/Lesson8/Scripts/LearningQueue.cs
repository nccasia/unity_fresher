using System.Collections.Generic;
using UnityEngine;

namespace Learning
{
    public class LearningQueue : MonoBehaviour
    {
        public Queue<GameObject> waitingFight = new Queue<GameObject>();

        private void Start()
        {

        }

        public void HandleIncoming(GameObject person)
        {
            waitingFight.Enqueue(person);
        }

        public void Fight()
        {
            waitingFight.Dequeue();
        }
    }
}
