using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject newObject;
        public int size;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static ObjectPool instance;
    private void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.newObject);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.Tag, objectPool);
            Debug.Log(pool.Tag);
        }
    }

    public GameObject PoolSpawn(string newTag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(newTag))
        {
            Debug.LogWarning(newTag + " does not exist.");
            return null;
        }

        for (int i = 0; i < poolDictionary.Count; i++)
            Debug.LogWarning(poolDictionary.Values);






        GameObject newObjSpawn = poolDictionary[newTag].Dequeue();

        newObjSpawn.SetActive(true);
        newObjSpawn.transform.position = position;
        newObjSpawn.transform.rotation = rotation;


        IPoolObject newPoolObj = newObjSpawn.GetComponent<IPoolObject>();


        if (newPoolObj != null)
        {
            newPoolObj.onObjectSpawn();
        }


        poolDictionary[newTag].Enqueue(newObjSpawn);

        return newObjSpawn;
    }


}