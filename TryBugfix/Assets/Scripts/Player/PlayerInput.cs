using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string AXIS_HORIZONTAL = "Horizontal";
    private const string AXIS_VERTICAL = "Vertical";

    private PlayerMover _mover;

    private void Awake()
    {
        CacheComponents();
    }

    private void Update()
    {
        ReadMoveInput();
    }

    private void CacheComponents()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void ReadMoveInput()
    {
        float horizontal = Input.GetAxisRaw(AXIS_HORIZONTAL);
        float vertical = Input.GetAxisRaw(AXIS_VERTICAL);
        _mover.SetDirection(new Vector3(horizontal, 0f, vertical));
    }
}
