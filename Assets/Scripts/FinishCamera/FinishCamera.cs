using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCamera : MonoBehaviour
{
    [HideInInspector] public Transform target;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }

        //else if (GameManager.insance.isGameFinish)
        //{
        //    transform.RotateAround(target.position, Vector3.up, -30 * Time.deltaTime);
        //    StartCoroutine(Rotate());
        //}
    }

    //public IEnumerator Rotate()
    //{
    //    yield return new WaitForSeconds(1);
    //    enabled = false;
    //}
}
