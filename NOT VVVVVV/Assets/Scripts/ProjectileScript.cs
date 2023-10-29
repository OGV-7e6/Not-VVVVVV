using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private Transform _ProjectileSpawner;
    [SerializeField] private float speed;
    [SerializeField] private AudioSource _enemySound;

    // Start is called before the first frame update
    void Start()
    {
        _enemySound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ProjectileReset"))
        {
            gameObject.transform.position = _ProjectileSpawner.transform.position;
        }
    }
}
