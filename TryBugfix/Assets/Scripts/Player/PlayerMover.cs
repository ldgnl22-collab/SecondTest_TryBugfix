using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string TAG_WALL = "Wall";

    [SerializeField] private float _meterPerSecond = 5f;

    private Rigidbody _body;
    private Vector3 _direction;

    private void Awake()
    {
        CacheComponents();
    }

    private void Update()
    {
        MoveByTransform();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_WALL))
        {
            Debug.Log("PlayerMover: 벽에 닿았습니다.");
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private void CacheComponents()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void MoveByTransform()
    {
        transform.position += _direction * _meterPerSecond * Time.deltaTime;
    }
}
