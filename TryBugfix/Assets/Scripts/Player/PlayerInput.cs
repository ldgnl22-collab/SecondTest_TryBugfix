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
    // [Bug-01] 원인 : update의 'u'가 소문자로 되어있습니다 / 수정 : 해당 'u'를 대문자로 변경
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
