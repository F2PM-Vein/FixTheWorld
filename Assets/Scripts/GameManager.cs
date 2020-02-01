using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int days = 1;
    public TextMeshPro txtDays;
    public List<Item.ItemSO> itemsList = new List<Item.ItemSO>();
    public List<Epidemic.EpidemicSO> epidemicsList = new List<Epidemic.EpidemicSO>();
    public static GameManager Instance { get; private set; }
    public GameObject prefab;

    //Game Manager Instantiater
    private void Awake()
    {
        //objectname.Gamemanager.Instance.objectname.Tostring();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Adds SOs to lists dynamically
    void Start()
    {
        object[] tempEpidemicList = Resources.LoadAll("Epidemics", typeof(Epidemic.EpidemicSO));

        foreach (Epidemic.EpidemicSO Epidemic in tempEpidemicList)
        {
            Epidemic.EpidemicSO ei = (Epidemic.EpidemicSO)Epidemic;
            epidemicsList.Add(ei);
        }

        object[] tempItemsList = Resources.LoadAll("Items", typeof(Item.ItemSO));

        foreach (Item.ItemSO Item in tempItemsList)
        {
            Item.ItemSO il = (Item.ItemSO)Item;
            itemsList.Add(il);
        }

    }

    //Instantiates epidemics 
   public void EpidemicSpread()
    {
  
        Instantiate(prefab);
        var result = Random.Range(1, epidemicsList.Count);
        prefab.GetComponent<SpriteRenderer>();
        prefab.name = epidemicsList[result].Name;
      
        Debug.Log("Epidemic instantiated");

    }

    void GameOver()
    {

    }

    public void DayEnded()
    {
        days++;
        txtDays.SetText(days.ToString());
    }
}
