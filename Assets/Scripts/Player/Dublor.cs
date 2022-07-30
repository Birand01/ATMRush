using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dublor : MonoBehaviour
{
    public FinishCamera finishCam;
    

    private void Start()
    {
        transform.DOMove(new Vector3(0, 0.7f, 407), 1);
        transform.DORotate(new Vector3(0, 0, 0), 1).OnComplete(() => finishCam.target = transform);
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RankCube"))
        {
            other.transform.DOMoveZ(other.transform.position.z - 2, 1f);
            this.transform.DOMoveY(this.transform.position.y + 6, 1f);
        }
    }

   
}
