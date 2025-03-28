using System;
using UnityEngine;

namespace Runtime
{
    public class Move : MonoBehaviour
    {
        public Vector3 velocity;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("asteroid"))
            {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
        
        void Update()
        {
            transform.Translate(velocity * Time.deltaTime);
        }
    }
}