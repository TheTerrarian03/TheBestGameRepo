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
            Instantiate(enemy);
        }
    }
}
