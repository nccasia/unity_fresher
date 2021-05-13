using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learning
{
    public class LearningArrayList : MonoBehaviour
    {
        public ArrayList inventory = new ArrayList();
        public GameObject item;

        private void Start() {
            inventory.Add(1);
            inventory.Add("B");
            inventory.Add("C");
            inventory.Add(item);
        }
    }
}
