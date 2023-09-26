using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornado : MonoBehaviour
{
    public Transform tornadoCenter;
    public float pullForce;
    public float refreshRate;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OBJ")
        {
            StartCoroutine(pullObject(other, true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "OBJ")
        {
            StartCoroutine(pullObject(other, false));
        }
    }

    IEnumerator pullObject(Collider x, bool shouldPull)
    {
        if(shouldPull)
        {
            Vector3 forceDir = tornadoCenter.position - x.transform.position;
            x.GetComponent<Rigidbody>().AddForce(forceDir.normalized * pullForce * Time.deltaTime);
            yield return refreshRate;
            StartCoroutine(pullObject(x, shouldPull));
        }
    }
}
