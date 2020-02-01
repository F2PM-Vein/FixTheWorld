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
    // Start is called before the first frame update
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

    void GameOver()
    {

    }

    public void DayEnded()
    {
        days++;
        txtDays.SetText(days.ToString());
    }
}
