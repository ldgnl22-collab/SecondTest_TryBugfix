using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _muzzle;

    private void Update()
    {
        ReadFireKey();
    }

    private void ReadFireKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = BulletPool.Instance.Take();

        if (bullet == null)
        {
            return;
        }
        
        bullet.GetComponent<Bullet>().Launch(_muzzle.position, Vector3.forward);
    }
}
