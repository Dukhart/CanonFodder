using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<GameObject> objects = new List<GameObject>(); // game objects to pool
    private List<List<GameObject>> pool = new List<List<GameObject>>(); // the pool
    [SerializeField] int amount; // number of each object to pool

    // Start is called before the first frame update
    void Start()
    {
        pool.Clear();
        SpawnPoolObjects();
    }
    // spawn all the pools objects
    void SpawnPoolObjects()
    {
        // for every object in the pool
        for (int i = 0; i < objects.Count; i++)
        {
            // make a list
            List<GameObject> objList = new List<GameObject>();
            for (int j = 0; j < amount; j++)
            {
                GameObject obj = Instantiate(objects[i], transform);
                obj.SetActive(false);
                objList.Add(obj);
            }
            pool.Add(objList);
        }
    }

    public GameObject GetGameObject(int objectIndex)
    {
        if (objectIndex >= objects.Count)
        {
            Debug.LogError("pool object index out of range");
            return null;
        }
        GameObject obj = null;
        // find the first in active object in the pool
        for (int i = 0; i < amount; i++)
        {
            if (!pool[objectIndex][i].activeSelf)
            {
                obj = pool[objectIndex][i];
                obj.SetActive(true);
                break;
            }
        }
        // if obj is null all pool objects should be active
        if (obj == null)
        {
            Debug.LogError("pool unable to find valid object!");
        }
        return obj;
    }
    public GameObject GetGameObject(GameObject obj)
    {
        if (!objects.Contains(obj))
        {
            Debug.LogError("Pool doesn't have matching game object!");
            return null;
        }
        return GetGameObject(objects.IndexOf(obj));
    }
}
