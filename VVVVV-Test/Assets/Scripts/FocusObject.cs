using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusObject : MonoBehaviour
{
    [SerializeField] private Transform _focusedObject;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(_focusedObject.position.x, _focusedObject.position.y, -10f);
        transform.position = newPos;
    }
}
