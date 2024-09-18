using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerRotationZone : MonoBehaviour
{
    private enum RotationDirection: int
    {
        Right = 1,
        Left = -1
    }
    [SerializeField]
    private RotationDirection direction;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerSript>(out PlayerSript player))
        {
            player.RotatePlayer((int)direction);
            Destroy(gameObject);
        }
        
    }
}
