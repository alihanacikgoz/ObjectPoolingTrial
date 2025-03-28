using System;
using UnityEngine;

namespace Runtime
{
    public class DestroyInvis : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            this.gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
