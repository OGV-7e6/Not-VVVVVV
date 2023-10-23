using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FocusObject : MonoBehaviour
{
    [SerializeField] public Transform _focusedObject;

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 newPos = new UnityEngine.Vector3(_focusedObject.position.x, _focusedObject.position.y, -10f);
        transform.position = newPos;
    }
}
