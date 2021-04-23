using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if (collider.GetComponent<PositionReset>())
        {
            collider.GetComponent<PositionReset>().ResetAfterDelay();
        }
    }
}
