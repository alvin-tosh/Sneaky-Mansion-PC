using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding; // Reference to the GameEnding script
    bool m_IsPlayerInRange;
    void OnTriggerEnter (Collider other) //  detect when Player Enters in range of the Trigger
    {
        if (other.transform == player) // check that Player is actually in range whenever OnTriggerEnter is called.
        {
            m_IsPlayerInRange = true;
        }


    }
    void OnTriggerExit (Collider other) // detect when Player leaves the Trigger.
    {
        if (other.transform == player) // check that Player is actually in range whenever OnTriggerEnter is called.
        {
            m_IsPlayerInRange = false;
        }


    }

    void Update ()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up; // direction from the PointOfView GameObject to Player is Player’s position minus the PointOfView GameObject’s position. 
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer (); // calls the CaughtPlayer method in GameEnding script

                }

            }

        }

    }
    

}
