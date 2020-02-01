using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public List<Item.ItemSO> itemsList = new List<Item.ItemSO>();
    public List<Epidemic.EpidemicSO> epidemicsList = new List<Epidemic.EpidemicSO>();

    // Start is called before the first frame update
    void Start()
    {
        object[] tempEpidemicList = Resources.LoadAll("Epidemic", typeof(Epidemic.EpidemicSO));
        Epidemic.EpidemicSO ei = (Epidemic.EpidemicSO)tempEpidemicList[0];
        epidemicsList.Add(ei);

        object[] tempItemsList = Resources.LoadAll("Items", typeof(Item.ItemSO));
        Item.ItemSO il = (Item.ItemSO)tempEpidemicList[0];
        itemsList.Add(il);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
