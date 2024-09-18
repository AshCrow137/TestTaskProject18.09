using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerSript>(out PlayerSript player))
        {
            GlobalEventManager.InvokeFinishEvent();
            Destroy(gameObject);
        }
    }
}
