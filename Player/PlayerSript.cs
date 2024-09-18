using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerProperties))]
[RequireComponent(typeof(AudioSource))]
public class PlayerSript : MonoBehaviour
{
    public static PlayerSript Instance;
    [SerializeField]
    private float forwardSpeed = 10;
    [SerializeField]
    private float sideSpeed = 20;
    private CharacterController controller;

    [SerializeField]
    private bool bMove = false;

    [SerializeField]
    private float smoothTime = 0.1f;

    private float currentVelocity;
    private float targetAngle = 0;

    [SerializeField]
    private AudioSource audioSource;
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(this);

        }
        else
        {
            Instance = this;
        }
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        GlobalEventManager.FinishEvent.AddListener(OnFinish);
        GlobalEventManager.StartEvent.AddListener(OnGameStart);
    }


    private void OnGameStart()
    {
        bMove = true;
    }
    private void OnFinish()
    {
        bMove=false;
    }
    private void OnGameEnd()
    {

    }
    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
    private void MoveForward()
    {
        float direction = DynamicJoystick.Instance.Horizontal;
        controller.Move(transform.right * Time.deltaTime * sideSpeed * direction + transform.forward * Time.deltaTime * forwardSpeed);
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    private void FixedUpdate()
    {
        if (bMove)
        {
            MoveForward();
           
        }
    }

    public void RotatePlayer(int direction)

    //1 = right, -1 = left 
    {

        targetAngle = transform.eulerAngles.y + 90* direction;
    }
}
