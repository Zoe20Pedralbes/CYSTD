using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyManager : MonoBehaviour
{
    public static DummyManager dummyManager;
    public Text idText;
    //Este id estar� en otro sitio

    public List<GameObject> DisableDummyList;
    private Dictionary<string, GameObject> dummyDictionary;

    public Dictionary<string, GameObject> DummyDictionary { get => dummyDictionary; set => dummyDictionary = value; }

    

    private void Start()
    {
        if (dummyManager != null)
        {
            Debug.LogError("Hay m�s de 1 dummyManager en la escena");
            Destroy(gameObject);
        }
        dummyManager = this;
        DummyDictionary = new Dictionary<string, GameObject>();
    }

    public void AssignToDictionary(string id)
    {
        if (DisableDummyList.Count > 0)
        {
            DummyDictionary.Add(id, DisableDummyList[0]);
            DisableDummyList.RemoveAt(0);
            SpawnDummy(id);
        }
        //dummyObjects.Add(id[i], DummyList.DummyList[i]);
        // SpawnDummy
        if (DummyDictionary.Count >= 4)
        {
            //SpawnDummy();
        }

    }
    public void SpawnDummy(string id)
    {
        for (int i = 0; i < DummyDictionary.Count && i < 5; i++)
        {

            Debug.Log("Dummy Spawned: " + DummyDictionary[id].name);
            DummyDictionary[id].gameObject.GetComponent<Dummy>().SetId(id);
            DummyDictionary[id].gameObject.SetActive(true);
        }
    }
}
