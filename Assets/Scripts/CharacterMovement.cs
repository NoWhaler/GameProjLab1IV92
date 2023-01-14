using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalMovement;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _layerMask;

    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider2D;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            CharacterJump();
        }
    }

    private bool IsGrounded()
    {
        var position = Physics2D.BoxCast(_collider2D.bounds.center, _collider2D.bounds.size,
            0f, Vector2.down, 0.1f,  _layerMask);
        return position;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontalMovement * _speed, _rigidbody2D.velocity.y);
    }

    private void CharacterJump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,_jumpForce);
    }
    
}
