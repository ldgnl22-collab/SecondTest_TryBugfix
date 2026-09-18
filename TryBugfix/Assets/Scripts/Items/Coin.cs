using UnityEngine;

public class Coin : MonoBehaviour
{
    private const string TAG_PLAYER = "Player";

    [SerializeField] private float _lifeSeconds = 6f;

    private void Start()
    {
        ScheduleDestroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            other.GetComponent<PlayerWallet>().Collect();
            Destroy(gameObject);
        }
    }

    private void ScheduleDestroy()
    {
        Destroy(gameObject, _lifeSeconds);
    }
}
