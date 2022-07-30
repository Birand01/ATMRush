using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FinishControl : Singleton<FinishControl>
{
    public CinemachineVirtualCamera mainCamera;
    public Camera finisCamera;
    public FinalMoneyCreate fmc;
    public GameObject dublör;
    private bool once = false;
    public bool isGameFinished=false;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Conveyor") && !once)
        {
            if (GetComponent<CollectList>().inventory.Count == 1)
            {
                StartCoroutine(NewCamera());
            }

            once = true;
        }
    }

    public IEnumerator NewCamera()
    {
        yield return new WaitForSeconds(2);
        finisCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        isGameFinished = true;
        foreach (GameObject item in fmc.finalMoneys)
        {
            item.SetActive(true);
        }

        dublör.SetActive(true);
    }
}
