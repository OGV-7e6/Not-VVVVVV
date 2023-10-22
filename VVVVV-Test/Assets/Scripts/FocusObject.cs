using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusObject : MonoBehaviour
{
    private Transform _trasform;
    [SerializeField] private string _focusedObjectName;
    public GameObject _focusedObject;
    private static FocusObject Instance;

    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null) Destroy(gameObject);
        else Instance = this;

        
    }
    private void Start()
    {
        _trasform = GetComponent<Transform>();
        /*_focusedObject = ;*/
    }


    // Update is called once per frame
    void Update()
    {
        _trasform.position = _focusedObject.transform.position;
    }
}
