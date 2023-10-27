using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator _animator;
    private Transform _transform;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private AudioSource _walkSound;
    [SerializeField] private AudioSource _enemySound;

    private float _speed;
    private int _gravity;
    private bool _isFacingRight;


    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();

        _speed = 20f;
        _gravity = 8;
        _rb.gravityScale = _gravity;
        _isFacingRight = true;
        _walkSound.Play();
        _enemySound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //AnimacionMovimiento
        if (_rb.velocity.x != 0f) _animator.SetBool("isMoving", true);
        else _animator.SetBool("isMoving", false);

        //AnimacionCaida
        if (IsGrounded()) _animator.SetBool("isFalling", false);
        else _animator.SetBool("isFalling", true);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyTurn"))
        {
            flip();
            _speed *= -1f;
        }

        //Cambio de gravedad
        if (collision.gameObject.CompareTag("EnemyJump"))
        {
            _transform.Rotate(0, 0, 180);
            _gravity *= -1;
            _rb.gravityScale = _gravity;
            flip();
        }
    }
}
