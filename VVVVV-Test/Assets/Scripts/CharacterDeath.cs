using System.Collections;
using System.Collections.Generic;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_Tag)) StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        _animator.SetTrigger("isDead");
        _rb.bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(_DeathAnimation.length);

        SceneManager.LoadScene(1);
    }
}
