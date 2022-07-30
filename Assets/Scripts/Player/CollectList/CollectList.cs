using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectList : Singleton<CollectList>
{
    public List<GameObject> inventory = new List<GameObject>();
    private GameObject character;

    public static CollectList Instance { get; private set; }
    protected override void Awake()
    {

        character = GameObject.FindGameObjectWithTag("Character");
        inventory.Add(character);
        if (Instance == null)
            Instance = this;
    }
  

    public void Stack(GameObject obj, int index)
    {
        obj.transform.parent = character.transform;
        Vector3 newPos = inventory[index].transform.localPosition;

        if (inventory[index].CompareTag("Character"))
        {
            newPos = new Vector3(0, 1, 5);
        }
        else
        {
            newPos.z += 1;
        }

        obj.transform.localPosition = newPos;
        inventory.Add(obj); 
        StartCoroutine(CubeScale());
        UIManager.GetInstance().ScoreUpdate();
    }
    public void Follow()
    {
        for (int i = 1; i < inventory.Count; i++)
        {
            if (inventory[i].transform.localPosition != null)
            {
                Vector3 pos = inventory[i].transform.localPosition;
                pos.x = inventory[i - 1].transform.localPosition.x;
                inventory[i].transform.DOLocalMove(pos, 0.001f);
            }
        }
    }
    public IEnumerator CubeScale()
    {
        for (int i = inventory.Count - 1; i >= 1; i--)
        {
            int index = i;
            Vector3 scale = Vector3.one * 1.5f;
            inventory[index].transform.DOScale(scale, 0.1f).OnComplete(() => inventory[index].transform.DOScale(Vector3.one, 0.1f));
            yield return new WaitForSeconds(0.03f);
        }
    }
}
