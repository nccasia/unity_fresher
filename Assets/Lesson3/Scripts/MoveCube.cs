using UnityEngine;

namespace Assets.Lesson3.Scripts
{
    public class MoveCube : MonoBehaviour
    {
        private Transform _transform;

        public float speed;
        // Start is called before the first frame update
        void Start()
        {
            this._transform = GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            _transform.position += Vector3.left * Time.deltaTime * speed;
        
        }
    }
}
