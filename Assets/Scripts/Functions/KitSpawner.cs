using UnityEngine;

public class KitSpawner : MonoBehaviour
{
    public GameObject[] kits;
    public Transform[] kitsSpawnPoints;

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
        KitSpawn();
    }

    void KitSpawn()
    {
        if (_delayBetweenSpawns <= 0)
        {
            _random = Random.Range(0, kits.Length);
            _randomPosition = Random.Range(0, kitsSpawnPoints.Length);

            Instantiate(kits[_random], kitsSpawnPoints[_randomPosition].transform.position, Quaternion.identity);
            _delayBetweenSpawns = _startDelayBetweenSpawns;
        }
        else
            _delayBetweenSpawns -= Time.deltaTime;
    }
}
