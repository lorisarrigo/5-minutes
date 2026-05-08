using System.Collections;
using UnityEngine;

public class AttackSequence : MonoBehaviour
{
    [SerializeField] EarthPooler ErPool;
    [SerializeField] IcePooler IcePool;
    [SerializeField] FireColPooler fireColPool;
    [SerializeField] FireBallPooler fireBPool;
    [SerializeField] LaserPooler laserPool;

    [Header("SpawnPoints")]
    [SerializeField] Transform[] fireBSpawn;
    public Transform[] fireCSpawn;
    [SerializeField] Transform[] iceBSpawn; //0-6: up; 7-9: Left; 10-12: right;
    [SerializeField] Transform[] earthBSpawn;
    [SerializeField] GameObject[] LaserSpawn;

    [Header("Prefabs")]
    [SerializeField] GameObject fireBPrefab;
    [SerializeField] GameObject fireCPrefab;
    [SerializeField] GameObject iceBPrefab;
    [SerializeField] GameObject earthBPrefab;
    [SerializeField] GameObject laserPrefab;

    [Header("Counters")]
    [SerializeField] int ripetition;

    [Header("Laser")]
    public Vector3 targetScale;
    public Vector3 amplifyScale;
    public float laserfinalPos;
    public float duration;

    public static AttackSequence Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(Attacks());
    }
    IEnumerator Attacks()
    {
        #region example
        //ripetition = 3;
        //while (ripetition > 0)
        //{
        //    yield return new WaitForSeconds(1);
        //    Pooler.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
        //    yield return new WaitForSeconds(2);
        //    Pooler.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
        //    yield return new WaitForSeconds(1);
        //    Pooler.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
        //    ripetition--;
        //}
        #endregion
        #region first attack
        ripetition = 5;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(1);
            //Earth L->R Ice R->L
            ErPool.GetBullet(earthBPrefab, earthBSpawn[0].position, earthBSpawn[0].rotation);
            yield return new WaitForSeconds(0.25f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[1].position, earthBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            yield return new WaitForSeconds(0.25f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[2].position, earthBSpawn[2].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[3].position, iceBSpawn[3].rotation);
            yield return new WaitForSeconds(0.25f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[3].position, earthBSpawn[3].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[5].position, iceBSpawn[5].rotation);
            //Earth R->L Ice L->R
            yield return new WaitForSeconds(2.7f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[3].position, earthBSpawn[3].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            yield return new WaitForSeconds(0.25f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[2].position, earthBSpawn[2].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[4].position, iceBSpawn[4].rotation);
            yield return new WaitForSeconds(0.25f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[1].position, earthBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[2].position, iceBSpawn[2].rotation);
            yield return new WaitForSeconds(0.25f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[0].position, earthBSpawn[0].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[0].position, iceBSpawn[0].rotation);
            ripetition--;
        }
        #endregion
        #region second attack
        ripetition = 2;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(5);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            yield return new WaitForSeconds(1);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);

            yield return new WaitForSeconds(5);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position + new Vector3(0, 1f), fireCSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(1);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            ripetition--;
        }
        #endregion
        #region third Attack
        ripetition = 2;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(5);
            LaserSpawn[0].SetActive(true);
            LaserSpawn[1].SetActive(true);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            yield return new WaitForSeconds(3);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            yield return new WaitForSeconds(3);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            LaserSpawn[0].SetActive(false);
            LaserSpawn[1].SetActive(false);
            ripetition--;
        }
        #endregion
    }
}
