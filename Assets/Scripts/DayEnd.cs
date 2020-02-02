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
        //for each city in list

        //For each neighbouring city
            int v=-1;
            int c = 0;
     
            foreach (Transform cities in GameManager.Instance.citiesList)
        //for(int v = 0; v < GameManager.Instance.citiesList.Count; v++)
        {
            v++;
            if (v < 6)
            {
                c = 0;
                Debug.Log("reset");
                Debug.Log("v=" + v);
                if (GameManager.Instance.citySOsList[v].onFire == true)
                {
                  
                    GameManager.Instance.epidemicSpreadResult = Random.Range(1, 6);
                  
                    if (GameManager.Instance.epidemicSpreadResult >= 3)
                    if(c< GameManager.Instance.citiesList[v].GetComponent<CityNeighbours>().cityNeighbours.Count)
                        {
                            foreach (Transform city in GameManager.Instance.citiesList[v].GetComponent<CityNeighbours>().cityNeighbours)
                            {
                                GameManager.Instance.citySpreadResult = Random.Range(1, 6);

                                if (GameManager.Instance.citySpreadResult >= 3 && GameManager.Instance.citySOsList[v].onFire == false)
                                {
                                    //it has spread there.
                                    Instantiate(GameManager.Instance.prefab, GameManager.Instance.citiesList[c].GetComponent<CityNeighbours>().transform);
                                    Debug.Log("C=" + c);
                                    GameManager.Instance.prefab.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.epidemicsList[0].Name;
                                    Debug.Log("Epidemic spread");
                                    c++;

                                }

                       
                            }
                        }
                    

                }

            }
        }
            }
                  
    }


