using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    private Rigidbody2D _rigidBody2D;
    private Vector2 _move;
    public int MaxHealth = 5;
    private int _currentHealth;
    public float Speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _currentHealth = 2;
    }

    // Update is called once per frame
    void Update()
    {
        _move = MoveAction.ReadValue<Vector2>();
        //Debug.Log(_move);
    }

    void FixedUpdate()
    {
        var position = _rigidBody2D.position + _move * Time.fixedDeltaTime * Speed;
        _rigidBody2D.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, MaxHealth);
        Debug.Log($"Health: {_currentHealth}/{MaxHealth}");
        if (_currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
