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

        GameManager.Instance.epidemicSpreadResult = Random.Range(-1, GameManager.Instance.epidemicsList.Count);
        //for each city in cities list 



        //if (GameManager.Instance.epidemicSpreadResult > -1)
        //{
        //}
            ////Is it spreading?
            //GameManager.Instance.citySpreadResult = Random.Range(-1, GameManager.Instance.citiesList.Count);
            
            ////if not then return
            //if (GameManager.Instance.citySpreadResult < 3)
            //{
            //    return;
            //}
         
            //how many cities is it spreading to
            //GameManager.Instance.numeberOfNeighboursResult = Random.Range(1, GameManager.Instance.CitySOsList.Count);
           
                for (int v = 0; v < GameManager.Instance.CitySOsList.Count; v++)
                {
           
                //For each neighbouring city
                foreach (Transform City in GameManager.Instance.CitySOsList[v].cityNeighbours)
                {
      
                    GameManager.Instance.epidemicSpreadResult = Random.Range(0, GameManager.Instance.CitySOsList.Count);
                }
                Instantiate(GameManager.Instance.prefab, GameManager.Instance.citiesList[GameManager.Instance.citySpreadResult].transform);
                }
            

            GameManager.Instance.prefab.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.epidemicsList[GameManager.Instance.epidemicSpreadResult].Name;
            //GameManager.Instance.prefab.name = GameManager.Instance.epidemicsList[GameManager.Instance.epidemicSpreadResult].Name;
            //GameManager.Instance.citiesList[GameManager.Instance.citySpreadResult].GetComponent<City>();

            //Debug.Log("Epidemic spread");
        
        //else
        //{
        //    Debug.Log("did not spread");
        //}

    }

}
