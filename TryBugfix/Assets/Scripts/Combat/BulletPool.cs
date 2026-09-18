using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _poolSize = 10;

    private List<GameObject> _pool;

    public static BulletPool Instance { get; private set; }

    private void Awake()
    {
        SetSingleton();
        CreatePool();
    }

    public GameObject Take()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].activeSelf)
            {
                continue;
            }

            _pool[i].SetActive(true);
            return _pool[i];
        }

        return null;
    }

    public void Return(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    private void SetSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void CreatePool()
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, transform);
            bullet.SetActive(false);
            _pool.Add(bullet);
        }
    }
}
