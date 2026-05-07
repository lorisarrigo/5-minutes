using System.Collections;
using UnityEngine;

public class AttackSequence : MonoBehaviour
{
    [SerializeField] ItemPooler Pooler;

    [Header("SpawnPoints")]
    [SerializeField] Transform[] fireBSpawn;
    [SerializeField] Transform[] iceBSpawn;
    [SerializeField] Transform[] earthBSpawn;

    [Header("Prefabs")]
    [SerializeField] GameObject fireBPrefab;
    [SerializeField] GameObject iceBPrefab;
    [SerializeField] GameObject earthBPrefab;

    [Header("Counters")]
    [SerializeField] int fireBCounter;
    [SerializeField] int iceBCounter;
    [SerializeField] int earthBCounter;
    void Start()
    {
        StartCoroutine(Attacks());   
    }
    IEnumerator Attacks()
    {
        fireBCounter = 3;
        while (fireBCounter > 0)
        {
            yield return new WaitForSeconds(1);
            Pooler.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            yield return new WaitForSeconds(2);
            Pooler.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            yield return new WaitForSeconds(1);
            Pooler.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            fireBCounter--;
        }
    }
}
