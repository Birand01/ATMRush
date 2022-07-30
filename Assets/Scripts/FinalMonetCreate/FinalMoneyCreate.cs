using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FinalMoneyCreate : MonoBehaviour
{
    public GameObject money;
    public List<GameObject> finalMoneys = new List<GameObject>();

    private void Start()
    {
        for (int i = 1; i < 70; i++)
        {
            GameObject obj = Instantiate(money, transform.position +new Vector3(0, i *0.75f, 0), Quaternion.identity, transform);
            finalMoneys.Add(obj);
            obj.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dublor"))
        {
            StartCoroutine(Delay());
        }
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.35f);
        transform.DOMoveY(UIManager.GetInstance().score, UIManager.GetInstance().score * 0.05f);
    }
}
