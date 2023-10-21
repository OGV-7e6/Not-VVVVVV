using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusObject : MonoBehaviour
{
    private Transform _trasform;
    [SerializeField] private GameObject _focusedObject;

    // Start is called before the first frame update
    void Start()
    {
        _trasform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _trasform.position = _focusedObject.transform.position;
    }
}
