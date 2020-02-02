using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayEnd : MonoBehaviour
{
    public int days = 1;
    public TextMeshPro txtDays;

    public float fireSpreadChance = 0.5f; // 0 to 1 = 0% to 100%

    public void DayEnded()
    {
        days++;
        txtDays.SetText(days.ToString());
        //for each city in list
        
        // Abby fix
        foreach (Transform city in GameManager.Instance.citiesList)
        {
            CityStatus cityStatus = city.GetComponent<CityStatus>();

            if (cityStatus.onFire) // Can spread fire
            {
                //city.GetComponentInChildren<>
                if (Random.value >= fireSpreadChance) // Chance that fire should fire should spread from this city
                {
                    // Select random neighbour city
                    CityNeighbours cityNeighbours = city.GetComponent<CityNeighbours>();
                    int neighbourIndex = Random.Range(0, cityNeighbours.cityNeighbours.Count);
                    Transform neighbourCity = cityNeighbours.cityNeighbours[neighbourIndex];

                    CityStatus neighbourStatus = neighbourCity.GetComponent<CityStatus>();
                    if (!neighbourStatus.onFire) // Only spread if it's not already on fire
                    {
                        // Spread fire to this city
                        neighbourCity.GetComponent<CityStatus>().onFire = true;
                        Instantiate(GameManager.Instance.prefab, neighbourCity);
                        GameManager.Instance.prefab.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.epidemicsList[0].Name;
                    }

                    // Debug.Log("C=" + neighbourIndex);
                    // Debug.Log("Epidemic spread");
                }
            }
        }

        //For each neighbouring city
        // int cityIndex = -1;
        // int neighbourIndex = 0;

        /*
        foreach (Transform cities in GameManager.Instance.citiesList)
        //for(int v = 0; v < GameManager.Instance.citiesList.Count; v++)
        {
            cityIndex++;
            if (cityIndex <= 5)
            {
                // neighbourIndex = 0;
                Debug.Log("reset");
                Debug.Log("v=" + cityIndex);
                if (GameManager.Instance.citySOsList[cityIndex].onFire == true)
                {
                    GameManager.Instance.epidemicSpreadResult = Random.Range(1, 6);

                    if (GameManager.Instance.epidemicSpreadResult >= 3)
                    {
                        if (neighbourIndex < GameManager.Instance.citiesList[cityIndex].GetComponent<CityNeighbours>().cityNeighbours.Count)
                        {
                            foreach (Transform city in GameManager.Instance.citiesList[cityIndex].GetComponent<CityNeighbours>().cityNeighbours)
                            {
                                GameManager.Instance.citySpreadResult = Random.Range(1, 6);

                                if (GameManager.Instance.citySpreadResult >= 3 && GameManager.Instance.citySOsList[cityIndex].onFire == false)
                                {
                                    //it has spread there.
                                    Instantiate(GameManager.Instance.prefab, GameManager.Instance.citiesList[neighbourIndex].GetComponent<CityNeighbours>().transform);
                                    Debug.Log("C=" + neighbourIndex);
                                    GameManager.Instance.prefab.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.epidemicsList[0].Name;
                                    Debug.Log("Epidemic spread");
                                    neighbourIndex++;

                                }
                            }
                        }
                    }
                }
            }
        }
        */
    }
}


