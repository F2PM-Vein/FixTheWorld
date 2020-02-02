using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayEnd : MonoBehaviour
{
    public int days=1;
    public TextMeshPro txtDays;

    public void DayEnded()
    {
        days++;
        txtDays.SetText(days.ToString());
        
    }

    public void EpidemicSpread()
    {
        GameManager.Instance.epidemicSpreadResult = Random.Range(-1, GameManager.Instance.epidemicsList.Count);
        if (GameManager.Instance.epidemicSpreadResult > -1)
        {
            GameManager.Instance.citySpreadResult = Random.Range(0, GameManager.Instance.citiesList.Count);
            Instantiate(GameManager.Instance.prefab, GameManager.Instance.citiesList[GameManager.Instance.citySpreadResult].transform);
            //GameManager.Instance.prefab.GetComponent<SpriteRenderer>();
            GameManager.Instance.prefab.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.epidemicsList[GameManager.Instance.epidemicSpreadResult].Name;

            GameManager.Instance.prefab.name = GameManager.Instance.epidemicsList[GameManager.Instance.epidemicSpreadResult].Name;

            Debug.Log("Epidemic instantiated");
        }


    }

}
