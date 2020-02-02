using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public int days = 1;
    public TextMeshPro txtDays;
    public bool epidemicStarted = false;
    public int epidemicSpreadResult;
    public int citySpreadResult, numeberOfNeighboursResult, spreadResult;
    public GameObject prefab;

    public List<Item.ItemSO> itemsList = new List<Item.ItemSO>();
    public List<Epidemic.EpidemicSO> epidemicsList = new List<Epidemic.EpidemicSO>();
    public List<City.CitySO> CitySOsList = new List<City.CitySO>();
    public List<Transform> citiesList = new List<Transform>();

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

        object[] tempCitiesList = Resources.LoadAll("Cities", typeof(City.CitySO));

        foreach (City.CitySO City in tempCitiesList)
        {
            City.CitySO cl = (City.CitySO)City;
            CitySOsList.Add(cl);
        }
    }

//Game Over   
void GameOver()
    {
        //if (citiesDead >= 2)
        //{
            
        //}
    }

}

