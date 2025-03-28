using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime
{
    public class Spawn : MonoBehaviour
    {
        void Update()
        {
            if (Random.Range(0, 100) < 2)
            {
                GameObject asteroid = Pool.Instance.Get("asteroid");
                if (asteroid != null)
                {
                    asteroid.transform.position = this.transform.position + new Vector3(Random.Range(-11, 12), 0, 0);
                    asteroid.transform.rotation = Quaternion.identity;
                    asteroid.SetActive(true);
                }
            }
        }
    }
}