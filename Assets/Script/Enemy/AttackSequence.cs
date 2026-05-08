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
        #region intro attack
        ripetition = 1;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(3);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[0].position, earthBSpawn[0].rotation);
            yield return new WaitForSeconds(2);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[1].position, earthBSpawn[1].rotation);
            yield return new WaitForSeconds(2);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[2].position, earthBSpawn[2].rotation);
            yield return new WaitForSeconds(2);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[3].position, earthBSpawn[3].rotation);
            yield return new WaitForSeconds(3f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[3].position, earthBSpawn[3].rotation);
            yield return new WaitForSeconds(2);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[2].position, earthBSpawn[2].rotation);
            yield return new WaitForSeconds(2);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[1].position, earthBSpawn[1].rotation);
            yield return new WaitForSeconds(2);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[0].position, earthBSpawn[0].rotation);
            ripetition--;
        }
        #endregion
        #region first attack
        ripetition = 1;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(2.5f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[0].position, earthBSpawn[0].rotation);
            yield return new WaitForSeconds(0.5f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[1].position, earthBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            yield return new WaitForSeconds(0.5f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[2].position, earthBSpawn[2].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[3].position, iceBSpawn[3].rotation);
            yield return new WaitForSeconds(0.5f);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[3].position, earthBSpawn[3].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[5].position, iceBSpawn[5].rotation);
            yield return new WaitForSeconds(1f);
            ripetition--;
        }
        #endregion
        #region second attack
        ripetition = 2;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(3);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            yield return new WaitForSeconds(1);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[10].position, iceBSpawn[10].rotation);
            yield return new WaitForSeconds(1);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            yield return new WaitForSeconds(1);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);

            yield return new WaitForSeconds(3);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            yield return new WaitForSeconds(1);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[8].position, iceBSpawn[8].rotation);
            yield return new WaitForSeconds(1);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position + new Vector3(0, 1f), fireCSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(1);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            ripetition--;
        }
        #endregion
        #region third Attack
        ripetition = 1;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(1);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            yield return new WaitForSeconds(0.5f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[10].position, iceBSpawn[10].rotation);
            yield return new WaitForSeconds(0.6f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[8].position, iceBSpawn[8].rotation);
            yield return new WaitForSeconds(0.7f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            yield return new WaitForSeconds(0.8f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            yield return new WaitForSeconds(0.9f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(1f);
            ripetition--;
        }
        #endregion
        #region fourth Attack
        ripetition = 2;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(3);
            LaserSpawn[0].SetActive(true);
            LaserSpawn[1].SetActive(true);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            yield return new WaitForSeconds(3);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            yield return new WaitForSeconds(3);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(1);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            yield return new WaitForSeconds(3);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(0.5f);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            yield return new WaitForSeconds(1.5f);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            LaserSpawn[0].SetActive(false);
            LaserSpawn[1].SetActive(false);
            ripetition--;
        }
        #endregion
        #region fifth Attack
        ripetition = 1;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(5);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            yield return new WaitForSeconds(0.5f);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            yield return new WaitForSeconds(1.5f);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            yield return new WaitForSeconds(3);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position - new Vector3(0, 0.5f), fireCSpawn[1].rotation);
            yield return new WaitForSeconds(2);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            yield return new WaitForSeconds(7);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            yield return new WaitForSeconds(1);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            ripetition--;
        }
        #endregion
        #region sixth Attack
        ripetition = 2;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(4);
            LaserSpawn[0].SetActive(true);
            LaserSpawn[1].SetActive(true);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[1].position, earthBSpawn[1].rotation);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[2].position, earthBSpawn[2].rotation);
            yield return new WaitForSeconds(4);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[0].position, earthBSpawn[0].rotation);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[3].position, earthBSpawn[3].rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            yield return new WaitForSeconds(1);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[1].position, earthBSpawn[1].rotation);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[3].position, earthBSpawn[3].rotation);
            LaserSpawn[0].SetActive(false);
            LaserSpawn[1].SetActive(false);
            ripetition--;
        }
        #endregion
        #region seventh Attack
        ripetition = 1;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(4);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[0].position, iceBSpawn[0].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(2);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            yield return new WaitForSeconds(1.5f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[8].position, iceBSpawn[8].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[3].position, iceBSpawn[3].rotation);
            yield return new WaitForSeconds(1.5f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            yield return new WaitForSeconds(1.5f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[4].position, iceBSpawn[4].rotation);
            yield return new WaitForSeconds(1.5f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[2].position, iceBSpawn[2].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[10].position, iceBSpawn[10].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[0].position, iceBSpawn[0].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[4].position, iceBSpawn[4].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[3].position, iceBSpawn[3].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[5].position, iceBSpawn[5].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[0].position, iceBSpawn[0].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[5].position, iceBSpawn[5].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[10].position, iceBSpawn[10].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[4].position, iceBSpawn[4].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[8].position, iceBSpawn[8].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[2].position, iceBSpawn[2].rotation);
            ripetition--;
        }
        #endregion
        #region eighth Attack
        ripetition = 2;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(0.5f);
            LaserSpawn[0].SetActive(true);
            LaserSpawn[1].SetActive(true);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            yield return new WaitForSeconds(3);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            yield return new WaitForSeconds(3);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(1);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            yield return new WaitForSeconds(3);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(0.5f);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            yield return new WaitForSeconds(1.5f);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            LaserSpawn[0].SetActive(false);
            LaserSpawn[1].SetActive(false);
            yield return new WaitForSeconds(2.5f);
            ripetition--;
        }
        #endregion
        #region ninth Attack
        ripetition = 2;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(3);
            LaserSpawn[0].SetActive(true);
            LaserSpawn[1].SetActive(true);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            yield return new WaitForSeconds(3);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            yield return new WaitForSeconds(2);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position + new Vector3(0, 0.5f), fireCSpawn[1].rotation);
            
            LaserSpawn[0].SetActive(false);
            LaserSpawn[1].SetActive(false);
            ripetition--;
        }
        #endregion
        #region tenth Attack
        ripetition = 1;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(4); 
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position + new Vector3(0, 0.5f), fireCSpawn[1].rotation);
            yield return new WaitForSeconds(4);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position + new Vector3(0, 0.5f), fireCSpawn[1].rotation);
            yield return new WaitForSeconds(4);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position + new Vector3(0, 0.5f), fireCSpawn[1].rotation);
            yield return new WaitForSeconds(4);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[0].position, iceBSpawn[0].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            yield return new WaitForSeconds(2);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            yield return new WaitForSeconds(1.5f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[8].position, iceBSpawn[8].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[3].position, iceBSpawn[3].rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position + new Vector3(0, 0.5f), fireCSpawn[1].rotation);
            yield return new WaitForSeconds(1.5f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[4].position, iceBSpawn[4].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[2].position, iceBSpawn[2].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[10].position, iceBSpawn[10].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position + new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[0].position, iceBSpawn[ 0].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[4].position, iceBSpawn[4].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[3].position, iceBSpawn[3].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[5].position, iceBSpawn[5].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[0].position, iceBSpawn[0].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[5].position, iceBSpawn[5].rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position + new Vector3(0, 0.5f), fireCSpawn[1].rotation);
            yield return new WaitForSeconds(1f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[10].position, iceBSpawn[10].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[4].position, iceBSpawn[4].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[8].position, iceBSpawn[8].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[2].position, iceBSpawn[2].rotation);
            ripetition--;
        }
        
        #endregion
        #region eleventh attack
        ripetition = 4;
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
            yield return new WaitForSeconds(2.5f);
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
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[1].position - new Vector3(0, 0.5f), fireCSpawn[1].rotation);
            ripetition--;
        }
        #endregion
        #region twelfth Attack
        ripetition = 3;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(3);
            LaserSpawn[0].SetActive(true);
            LaserSpawn[1].SetActive(true);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            yield return new WaitForSeconds(3);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            yield return new WaitForSeconds(1);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(3);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            yield return new WaitForSeconds(3);
            laserPool.GetBullet(laserPrefab, LaserSpawn[0].transform.position, LaserSpawn[0].transform.rotation);
            laserPool.GetBullet(laserPrefab, LaserSpawn[1].transform.position, LaserSpawn[1].transform.rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            fireColPool.GetBullet(fireCPrefab, fireCSpawn[0].position - new Vector3(0, 0.5f), fireCSpawn[0].rotation);
            yield return new WaitForSeconds(0.5f);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[1].position, earthBSpawn[1].rotation);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[2].position, earthBSpawn[2].rotation);
            yield return new WaitForSeconds(1.5f);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[0].position, fireBSpawn[0].rotation);
            fireBPool.GetBullet(fireBPrefab, fireBSpawn[1].position, fireBSpawn[1].rotation);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[0].position, earthBSpawn[1].rotation);
            ErPool.GetBullet(earthBPrefab, earthBSpawn[3].position, earthBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[10].position, iceBSpawn[10].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            LaserSpawn[0].SetActive(false);
            LaserSpawn[1].SetActive(false);
            ripetition--;
        }
        #endregion
        #region thirteenth Attack
        ripetition = 1;
        while (ripetition > 0)
        {
            yield return new WaitForSeconds(4);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[0].position, iceBSpawn[0].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[12].position, iceBSpawn[12].rotation);
            yield return new WaitForSeconds(2);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[10].position, iceBSpawn[10].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[2].position, iceBSpawn[2].rotation);
            yield return new WaitForSeconds(2f);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[8].position, iceBSpawn[8].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[3].position, iceBSpawn[3].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[4].position, iceBSpawn[4].rotation);
            yield return new WaitForSeconds(2);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[11].position, iceBSpawn[11].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[4].position, iceBSpawn[4].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            yield return new WaitForSeconds(2);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[9].position, iceBSpawn[9].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[5].position, iceBSpawn[5].rotation);
            yield return new WaitForSeconds(2);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[6].position, iceBSpawn[6].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[2].position, iceBSpawn[2].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[10].position, iceBSpawn[10].rotation);
            yield return new WaitForSeconds(2);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[1].position, iceBSpawn[1].rotation);
            IcePool.GetBullet(iceBPrefab, iceBSpawn[7].position, iceBSpawn[7].rotation);
            ripetition--;
        }
        #endregion
    }
}
