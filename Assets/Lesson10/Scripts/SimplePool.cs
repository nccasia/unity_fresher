using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Lesson10.Scripts
{
    public class SimplePool : MonoBehaviour
    {
        private static SimplePool _instance;
        [SerializeField] private List<GameObject> _pool;
        private Vector3 _defaultPosition = new Vector3(-1000, -1000, -1000);
        
        public GameObject prefabToPool;
        public int Size = 100;

        public static SimplePool Instance
        {
            get
            {
                return _instance;
            }
            private set {}
        }

        private void Awake()
        {
            _pool = new List<GameObject>();
            _instance = this;

            for (var i = 0; i < Size; i++)
            {
                var instance = Instantiate(prefabToPool);
                instance.transform.position = _defaultPosition;
                instance.SetActive(false);
                
                _pool.Add(instance);
            }
        }

        public GameObject Get()
        {
            GameObject ball = null;
            foreach (var b in _pool)
            {
                if (b.activeInHierarchy == false)
                {
                    ball = b;
                    break;
                }
            }

            if (ball == null) // out of pool, allocate new ball
            {
                ball = Instantiate(prefabToPool);
                _pool.Add(ball);
            }
            
            Assert.IsNotNull(ball);
            
            ball.SetActive(true);

            return ball;
        }

        public void Release(GameObject go)
        {
            go.transform.position = _defaultPosition;
            go.transform.rotation = Quaternion.identity;
            go.GetComponent<Rigidbody>().velocity = Vector3.zero;
            go.SetActive(false);
        }
    }
}