using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private Transform _ProjectileSpawner;
    [SerializeField] private float speed;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         _rb.velocity = new Vector2(speed * -1,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ProjectileReset"))
        {
            gameObject.transform.position = _ProjectileSpawner.transform.position;
        }
    }
}
