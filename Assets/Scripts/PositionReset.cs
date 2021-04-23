using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PositionReset : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;
    Rigidbody rigidbody;

    const float RESET_TIME = 7f;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        rigidbody = GetComponent<Rigidbody>();
    }

    
    public void ResetAfterDelay(){
        StartCoroutine(ResetAfterDelayCoroutine());
    }

    IEnumerator ResetAfterDelayCoroutine(){
        yield return new WaitForSeconds(RESET_TIME);
        rigidbody.velocity = new Vector3(0,0,0);
        rigidbody.angularVelocity = new Vector3(0,0,0);
        transform.position = startPos;
        transform.rotation = startRot;
    }
}
