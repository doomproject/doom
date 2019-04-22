using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour, IPickup
{
    public void Pickup()
    {
        Destroy(this.gameObject);
    }
}
