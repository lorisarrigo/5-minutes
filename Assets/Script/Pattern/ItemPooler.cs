using System.Collections.Generic;
using UnityEngine;

public class ItemPooler : MonoBehaviour
{
    [SerializeField] List<GameObject> pool_BulletPrefab = new();

    int instancedCount, pooledCount;

    public GameObject GetBullet(GameObject bullet, Vector3 position, Quaternion rotation)
    {
        return SpawnItemFromPool(bullet, pool_BulletPrefab, position, rotation);
    }
    private GameObject SpawnItemFromPool(GameObject objPrefab, List<GameObject> pool, Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].transform.SetPositionAndRotation(position, rotation);
                pool[i].SetActive(true);
                pooledCount++;
                return pool[i];
            }
        }
        GameObject instancedObj = Instantiate(objPrefab, position, rotation, transform);
        pool.Add(instancedObj);
        instancedCount++;
        return instancedObj;
    }
}
