using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterDeath : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private AnimationClip _DeathAnimation;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private string _Tag;


    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
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

        yield return new WaitForSeconds(_DeathAnimation.length);

        _rb.bodyType = RigidbodyType2D.Dynamic;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
