using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _intervalSeconds = 1f;
    [SerializeField] private float _rangeX = 4f;
    [SerializeField] private float _rangeZ = 0f;

    private WaitForSeconds _waitInterval;

    private void Awake()
    {
        CacheWait();
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void CacheWait()
    {
        _waitInterval = new WaitForSeconds(_intervalSeconds);
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            yield return _waitInterval;
        }
    }

    private void Spawn()
    {
        float x = transform.position.x + Random.Range(-_rangeX, _rangeX);
        float z = transform.position.z + Random.Range(-_rangeZ, _rangeZ);
        Vector3 position = new Vector3(x, transform.position.y, z);
        Instantiate(_prefab, position, Quaternion.identity);
    }
}
