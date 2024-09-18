using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class Pickable : MonoBehaviour
{
    [SerializeField]
    protected int PickableValue = 1;
    [SerializeField]
    protected float rotationSpeed = 3;
    [SerializeField]
    private AudioClip pickUpSound;

    [SerializeField]
    protected ParticleSystem particles;
    [SerializeField]
    protected GameObject mesh;
    private void Awake()
    {


    }
    private void Update()
    {
        transform.Rotate(Vector3.up  * rotationSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerSript>(out PlayerSript player))
        {
            player.PlaySound(pickUpSound);
            OnPickUp(player);
        }
    }
    protected virtual void OnPickUp(PlayerSript player)
    {
        particles.Play();
        mesh.SetActive(false);
    }
}
