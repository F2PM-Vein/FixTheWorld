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
            Instantiate(GameManager.Instance.prefab, GameManager.Instance.citiesList[start].transform);
            GameManager.Instance.epidemicChoiceResult = Random.Range(0, GameManager.Instance.epidemicsList.Count);
            GameManager.Instance.epidemicsList[GameManager.Instance.epidemicChoiceResult].epidemicProgress = Progress.HAPPENING;

            if (GameManager.Instance.epidemicChoiceResult == 0)
            {
                GameManager.Instance.citySOsList[start].onFire = true;
            }
            else
            {
                GameManager.Instance.citySOsList[start].Infected = true;
            }


            GameManager.Instance.epidemicStarted = true;
   
        }
        #endregion
    }
}

