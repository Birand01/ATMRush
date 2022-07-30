using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            if (!CollectList.Instance.inventory.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Collected";
                other.gameObject.GetComponent<Collect>().enabled = true;
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                CollectList.Instance.Stack(other.gameObject, CollectList.Instance.inventory.Count - 1);
            }
        }
    }
}
