using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string TAG_PLAYER = "Player";
    private const string TAG_BULLET = "Bullet";
    private const int SCORE_PER_KILL = 10;

    [SerializeField] private float _meterPerSecond = 2f;
    [SerializeField] private float _lifeSeconds = 10f;

    private void Start()
    {
        ScheduleDestroy();
    }

    private void Update()
    {
        MoveDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_BULLET))
        {
            BulletPool.Instance.Return(other.gameObject);
            Destroy(gameObject);
            GameManager.Instance.AddScore(SCORE_PER_KILL);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_PLAYER))
        {
            Destroy(gameObject);
        }
    }

    private void ScheduleDestroy()
    {
        Destroy(gameObject, _lifeSeconds);
    }

    private void MoveDown()
    {
        transform.position += Vector3.back * _meterPerSecond * Time.deltaTime;
    }
}
