using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    public PlayerMovementData playerMovementData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            if (CollectList.Instance.inventory.Count - 1 == CollectList.Instance.inventory.IndexOf(other.gameObject)) //listenin son elemaný ise
            {
                CollectList.Instance.inventory.Remove(other.gameObject);
                Destroy(other.gameObject);
            }

            else
            {
                int crashObjIndex = CollectList.Instance.inventory.IndexOf(other.gameObject);
                int lastIndex = CollectList.Instance.inventory.Count - 1;

                for (int i = crashObjIndex; i <= lastIndex; i++)
                {
                    RemoveList(CollectList.Instance.inventory[crashObjIndex]);
                }
            }
        }

        else if (other.CompareTag("Character"))
        {
            StartCoroutine(Crash());
            other.transform.DOMove(other.transform.position - new Vector3(0, 0, 20), 1).SetEase(Ease.OutBounce);
        }
    }
    IEnumerator Crash()
    {
        playerMovementData.currentSpeed = playerMovementData.obstacledSpeed;
        yield return new WaitForSeconds(1.5f);
        playerMovementData.currentSpeed = 20;
    }

    public void RemoveList(GameObject crashObj)
    {
        CollectList.Instance.inventory.Remove(crashObj);
        crashObj.tag = "Money";
        crashObj.GetComponent<BoxCollider>().isTrigger = true;
        crashObj.GetComponent<Collect>().enabled = false;

        GameObject bounceMoney = Instantiate(crashObj, RandomPos(transform), Quaternion.identity);
        Destroy(bounceMoney.GetComponent<Rigidbody>());
        bounceMoney.transform.DOMove(bounceMoney.transform.position - new Vector3(0, 2, 0), 1).SetEase(Ease.OutBounce);
        Destroy(crashObj);
    }

    public Vector3 RandomPos(Transform obstacle)
    {
        float x = Random.Range(-4, 4);
        float z = Random.Range(20, 30);
        Vector3 posisiton = new Vector3(x, 3, obstacle.position.z + z);
        return posisiton;
    }
}
