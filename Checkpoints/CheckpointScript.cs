using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]
public class CheckpointScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private string animName = "FlagGetUp";
    [SerializeField]
    private AudioClip activateSound;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerSript>(out PlayerSript player))
        {
            player.PlaySound(activateSound);
            if(animator)
            {
                animator.Play(animName);
            }
            
            TriggerCheckpoint();
        }
    }
    protected virtual void TriggerCheckpoint()
    {
        //trigger checkpoint code
    }
}
