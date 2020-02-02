using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Epidemic;

public class GameInitializer: MonoBehaviour
{
    #region Gamestart
    void Start()
    {
        //add txt to GM
        if (GameManager.Instance.txtDays == null)
        {
            var txtParent = GameObject.Find("PNL_GameUI").GetComponentInChildren<TextMeshPro>();
            GameManager.Instance.txtDays.SetText(txtParent.text);
        }

        //Add cities to List
        if (GameManager.Instance.citiesList.Count == 0)
        {
            var cityParent = GameObject.Find("PNL_Cities");
            if (cityParent != null)
            {
                for (int i = 0; i < cityParent.transform.childCount; ++i)
                {
                    GameManager.Instance.citiesList.Add(cityParent.transform.GetChild(i));
                }
            }
        }
        #endregion Game 
        #region The first Epidemic

        if (GameManager.Instance.epidemicStarted == false)
        {

            //chooses the epidemic to begin with
        
            int start = Random.Range(0, GameManager.Instance.citiesList.Count);
        
            GameManager.Instance.epidemicChoiceResult = Random.Range(0, GameManager.Instance.epidemicsList.Count);
            GameManager.Instance.epidemicsList[GameManager.Instance.epidemicChoiceResult].epidemicProgress = Progress.HAPPENING;

            CityStatus cityStatus = GameManager.Instance.citiesList[start].GetComponent<CityStatus>();

            GameObject prefab = Instantiate(GameManager.Instance.prefab, GameManager.Instance.citiesList[start].transform);
    
            if (GameManager.Instance.epidemicChoiceResult == 0) // fire
            {
                cityStatus.fireStatus++;

                prefab.GetComponentInChildren<EpidemicPrefab>().epidemicType = EpidemicPrefab.EpidemicType.Fire;
                prefab.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.epidemicsList[0].Name;
                //GameManager.Instance.citySOsList[start].onFire = true;
            }
            else
            {
                // GameManager.Instance.citiesList[start].GetComponent<CityStatus>().isInfected = true;

                cityStatus.infectedStatus++;
                prefab.GetComponentInChildren<EpidemicPrefab>().epidemicType = EpidemicPrefab.EpidemicType.Virus;
                prefab.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.epidemicsList[1].Name;
                //GameManager.Instance.citySOsList[start].Infected = true;

                Vector3 newPos = prefab.transform.position;
                newPos.x += 100;
                prefab.transform.position = newPos;
            }

            GameManager.Instance.epidemicStarted = true;
   
        }
        #endregion
    }
}

