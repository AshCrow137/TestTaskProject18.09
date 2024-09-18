using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableMoneyScript : Pickable
{

    protected override void OnPickUp(PlayerSript player)
    {
       
        GlobalEventManager.InvokePickUpEvent(PickableValue);
        base.OnPickUp(player);
        
        
    }
}
