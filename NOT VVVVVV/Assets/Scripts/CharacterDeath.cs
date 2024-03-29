using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterDeath : MonoBehaviour
{
    
    private Animator _animator;
    [SerializeField] private AnimationClip _deathAnimation;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private string _Tag;
    [SerializeField] private AudioSource _vfx;


    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_Tag))
        {
            StartCoroutine(Die());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_Tag))  
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        _animator.SetBool("isAlive", false);
        _rb.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger("isDead");

        _vfx.Play();

        yield return new WaitForSeconds(_deathAnimation.length);

        _rb.bodyType = RigidbodyType2D.Dynamic;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
