using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [Tooltip("If this keycard no longer exists, destroy this door when the player runs into it")]
    public GameObject keycard;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player") && keycard == null)
        {
            Destroy(this.gameObject);
        }
    }
}
