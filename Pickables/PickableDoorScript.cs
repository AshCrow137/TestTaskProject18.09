using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableDoorScript : CheckpointScript
{
    [SerializeField]
    private int PickableValue;
    [SerializeField]
    private int pointMultiplyer = 1;
    protected override void TriggerCheckpoint()
    {
        base.TriggerCheckpoint();
        GlobalEventManager.InvokePickUpEvent(PickableValue);
        PlayerProperties.Instance.setMultiplayer(pointMultiplyer);
    }


}
