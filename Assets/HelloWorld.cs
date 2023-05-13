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

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawRay(transform.position, Vector3.down);
    //    var trackingRaycast = Physics.BoxCast(transform.position, transform.lossyScale / 2f, Vector3.down, out RaycastHit hit, transform.rotation, 1f);
    //    Gizmos.DrawWireCube(transform.position + Vector3.down * hit.distance, transform.lossyScale);

    //    //if (trackingRaycast)
    //    //{
    //    //    Gizmos.color = Color.green;

    //    //    Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
    //    //}
    //}

}
