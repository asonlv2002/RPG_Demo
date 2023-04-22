using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [field: SerializeField] public string Messege { get; set; }

    private void Awake()
    {
        Debug.Log(Messege);
    }

}
