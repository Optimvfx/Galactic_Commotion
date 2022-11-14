using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] meteorEnemy;
    public Transform[] spawnPoint;

    private int _random;
    private int _randomPosition;

    public float _startDelayBetweenSpawns;
    private float _delayBetweenSpawns;

    void Start()
    {
        _delayBetweenSpawns = _startDelayBetweenSpawns;
    }

    void Update() 
    {
        MeteorSpawn();
    }

    void MeteorSpawn()
    {
        if (_delayBetweenSpawns <= 0)
        {
            _random = Random.Range(0, meteorEnemy.Length);
            _randomPosition = Random.Range(0, spawnPoint.Length);

            Instantiate(meteorEnemy[_random], spawnPoint[_randomPosition].transform.position, Quaternion.identity);
            _delayBetweenSpawns = _startDelayBetweenSpawns;
        }
        else
        {
            _delayBetweenSpawns -= Time.deltaTime;
        }
    }
}
