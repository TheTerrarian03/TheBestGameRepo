using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public float spawnDelay;
    [SerializeField] GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnByWhile();
        //SpawnByForLoop();
    }

    private void SpawnByForLoop()
    {

    }
    private void SpawnByWhile()
    {
        StartCoroutine(SpawnTimer());
    }
    IEnumerator SpawnTimer()
    {
        while (true)
        {
            spawnDelay = Random.Range(2, 4);
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(enemy, new Vector3(-0.8664f, 3.29f, -22.3994f));
        }
    }
}
// https://stackoverflow.com/questions/40782245/convert-vector3-to-transform
// https://stackoverflow.com/questions/36781086/how-to-convert-vector3-to-quaternion
// Quaternion.Euler(Vector3.up)