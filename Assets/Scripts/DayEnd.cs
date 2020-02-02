using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DayEnd : MonoBehaviour
{
    public int days = 1, citiesDead=0;
    public TextMeshPro txtDays;
    public TextMeshPro txtcitiesDead;

    public float fireSpreadChance = 0.5f; // 0 to 1 = 0% to 100%
    public float virusSpreadChance = 0.5f; // 0 to 1 = 0% to 100%

    public void DayEnded()
    {
        days++;
        txtDays.SetText(days.ToString());
        //for each city in list
        spreadFire();
        spreadVirus();

        // Abby fix

        //if (days > 9)
        //{

        //}
    }

    public void spreadFire()
    {
        foreach (Transform city in GameManager.Instance.citiesList)
        {
            CityStatus cityStatus = city.GetComponent<CityStatus>();

            if (cityStatus.fireStatus > 0) // Can spread fire
            {
                cityStatus.fireStatus++;
                if (cityStatus.fireStatus >= 3) // max fire destroyed
                {
                    cityStatus.fireStatus = 3;
                    Button cityButton = city.GetComponent<Button>();
                    cityButton.interactable = false;

                    citiesDead++;
                    txtcitiesDead.SetText(citiesDead.ToString());

                    if (citiesDead > 1)
                    {
                        Time.timeScale = 0;
                        Debug.Log("gameOver" + Time.timeScale);
                    }
                    else
                    {
                        Debug.Log("Still going");
                    }

                }
                else //onfire but not destroyed
                {
                    //city.GetComponentInChildren<>
                    if (Random.value >= fireSpreadChance) // Chance that fire should fire should spread from this city
                    {
                        // Select random neighbour city
                        CityNeighbours cityNeighbours = city.GetComponent<CityNeighbours>();
                        int neighbourIndex = Random.Range(0, cityNeighbours.cityNeighbours.Count);
                        Transform neighbourCity = cityNeighbours.cityNeighbours[neighbourIndex];

                        CityStatus neighbourStatus = neighbourCity.GetComponent<CityStatus>();
                        if (neighbourStatus.fireStatus < 1) // Only spread if it's not already on fire
                        {
                            // Spread fire to this city
                            neighbourStatus.fireStatus++;
                            GameObject prefab = Instantiate(GameManager.Instance.prefab, neighbourCity);
                            EpidemicPrefab epidemicPrefab = prefab.GetComponentInChildren<EpidemicPrefab>();
                            epidemicPrefab.epidemicType = EpidemicPrefab.EpidemicType.Fire;
                            GameManager.Instance.prefab.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.epidemicsList[0].Name;

                        }
                        // Debug.Log("C=" + neighbourIndex);
                        // Debug.Log("Epidemic spread");
                    }
                }
            }

        }
        #region Trash
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
        #endregion
    }

    public void spreadVirus()
    {
        foreach (Transform city in GameManager.Instance.citiesList)
        {
            CityStatus cityStatus = city.GetComponent<CityStatus>();

            if (cityStatus.infectedStatus > 0) // Can spread infected
            {
                cityStatus.infectedStatus++;
                if (cityStatus.infectedStatus >= 3) // max infected destroyed
                {
                    cityStatus.infectedStatus = 3;
                    Button cityButton = city.GetComponent<Button>();
                    cityButton.interactable = false;
                    //city.GetChild(city.childCount);
              
                    citiesDead++;
                    txtcitiesDead.SetText(citiesDead.ToString());

                    if (citiesDead > 1)
                    {
                        //gameover();
                        Debug.Log("gameOver"+Time.timeScale);
                        Time.timeScale = 0;
                    }
                    else
                    {
                        Debug.Log("Still going");
                    }

                }
                else // is infected but not destroyed
                {
                    //city.GetComponentInChildren<>
                    if (Random.value >= virusSpreadChance) // Chance that virus should virus should spread from this city
                    {
                        // Select random neighbour city
                        CityNeighbours cityNeighbours = city.GetComponent<CityNeighbours>();
                        int neighbourIndex = Random.Range(0, cityNeighbours.cityNeighbours.Count);
                        Transform neighbourCity = cityNeighbours.cityNeighbours[neighbourIndex];

                        CityStatus neighbourStatus = neighbourCity.GetComponent<CityStatus>();

                        if (neighbourStatus.infectedStatus < 1) // Only spread if it's not already on infected
                        {
                            // Spread infected to this city
                            neighbourStatus.infectedStatus++;
                            GameObject prefab = Instantiate(GameManager.Instance.prefab, neighbourCity);

                            Vector3 newPos = prefab.transform.position;
                            newPos.x = 100;
                            //prefab.transform.position = newPos;

                            EpidemicPrefab epidemicPrefab = prefab.GetComponentInChildren<EpidemicPrefab>();
                            epidemicPrefab.epidemicType = EpidemicPrefab.EpidemicType.Virus;
                            GameManager.Instance.prefab.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.epidemicsList[1].Name;

                        }
                    }
                }

            }

        }
    }
}


