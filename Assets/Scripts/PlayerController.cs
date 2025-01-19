using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    private Rigidbody2D _rigidBody2D;
    private Vector2 _move;
    public int MaxHealth = 5;
    private int _currentHealth;
    public int Health => _currentHealth;
    public float Speed = 3.0f;
    public float TimeInvincible = 2.0f;
    private bool _isInvincible;
    private float _damageCooldown;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _move = MoveAction.ReadValue<Vector2>();
        //Debug.Log(_move);
        if (!_isInvincible)
            return;
        _damageCooldown -= Time.deltaTime;
        if (Time.time > _damageCooldown)
        {
            _isInvincible = false;
        }
    }

    void FixedUpdate()
    {
        var position = _rigidBody2D.position + _move * Time.fixedDeltaTime * Speed;
        _rigidBody2D.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        switch (amount)
        {
            // taking damage
            // already invincible
            case < 0 when _isInvincible:
                return;
            case < 0:
                _isInvincible = true; // become invincible
                _damageCooldown = Time.time + TimeInvincible; // set invincibility time
                break;
            // healing
            // already at full health
            case > 0 when _currentHealth == MaxHealth:
                return;
        }
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, MaxHealth);
        Debug.Log($"Health: {_currentHealth}/{MaxHealth}");
        if (_currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
