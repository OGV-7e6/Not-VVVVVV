using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSceneTravel : MonoBehaviour
{
    private Transform _transform;
    private GameObject _spawnEntrance;
    private GameObject _spawnExit;
    private bool _isNextLevel = false;
    private Animator _animator;
    private void OnLevelWasLoaded(int level)
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();

        //Encuentra los puntos de spawn (si existen) y los asigna a sus variables respectivas
        _spawnEntrance = GameObject.Find("EntranceSpawn");
        _spawnExit = GameObject.Find("ExitSpawn");

        //Mueve al personaje a la posicion del spawn correspondiente.
        if (_isNextLevel) _transform.position = _spawnEntrance.transform.position;
        else _transform.position = _spawnExit.transform.position;
        _animator.SetBool("isAlive", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Entrance")) _isNextLevel = false;
        else if (collision.gameObject.CompareTag("Exit")) _isNextLevel = true;
    }
}
