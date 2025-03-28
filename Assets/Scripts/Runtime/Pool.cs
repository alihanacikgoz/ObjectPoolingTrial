using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    [Serializable]
    public class PoolItem
    {
        public GameObject prefab;
        public int amount;
        public bool expandable;
        public int power;
    }

    public class Pool : MonoBehaviour
    {
        public static Pool Instance {get; private set;}
        public List<PoolItem> items;
        public List<GameObject> poolItems;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }
        
        void Start()
        {
            CreatingPoolItems();
        }

        private void CreatingPoolItems()
        {
            poolItems = new List<GameObject>();
            foreach (PoolItem item in items)
            {
                for (int i = 0; i < item.amount; i++)
                {
                    GameObject go = Instantiate(item.prefab, transform);
                    go.SetActive(false);
                    poolItems.Add(go);
                }
            }
        }

        public GameObject Get(string tag)
        {
            for (int i = 0; i < poolItems.Count; i++)
            {
                if (!poolItems[i].activeInHierarchy && poolItems[i].CompareTag(tag))
                {
                    return poolItems[i];
                }
            }

            foreach (PoolItem item in items)
            {
                if (item.prefab.CompareTag(tag) && item.expandable)
                {
                    GameObject obj = Instantiate(item.prefab, transform);
                    obj.SetActive(false);
                    poolItems.Add(obj);
                    return obj;
                }
            }
            return null;
        }
    }
}