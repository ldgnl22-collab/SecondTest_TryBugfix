using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const string TAG_ENEMY = "Enemy";

    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private float _invincibleSeconds = 2f;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private GameFlow _gameFlow;

    private readonly WaitForSeconds _waitBlink = new WaitForSeconds(0.1f);
    private Renderer _renderer;
    private int _health;
    private bool _isInvincible;
    
    private Coroutine _blinkRoutine;

    private void Awake()
    {
        CacheComponents();
    }

    private void Start()
    {
        InitHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_ENEMY))
        {
            TakeDamage();
        }
    }

    private void CacheComponents()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void InitHealth()
    {
        _health = _maxHealth;
        _healthView.Show(_health);
    }

    private void TakeDamage()
    {
        if (_isInvincible)
        {
            return;
        }

        _health--;

        if (_health <= 0)
        {
            _gameFlow.ShowGameOver();
        }
        else
        {
            BeginInvincible();
        }

        _healthView.Show(_health);
    }

    private void BeginInvincible()
    {
        _isInvincible = true;
        BeginBlink();
        StartCoroutine(InvincibleRoutine());
    }

    private IEnumerator InvincibleRoutine()
    {
        yield return new WaitForSeconds(_invincibleSeconds);
        _isInvincible = false;
        EndBlink();
    }

    private void BeginBlink()
    {
        if (_blinkRoutine != null) return;
        _blinkRoutine = StartCoroutine(BlinkRoutine());
    }

    private void EndBlink()
    {
        StopCoroutine(_blinkRoutine);
        _blinkRoutine = null;
        _renderer.enabled = true;
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            _renderer.enabled = !_renderer.enabled;
            yield return _waitBlink;
        }
    }
}
