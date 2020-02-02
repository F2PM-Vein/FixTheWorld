using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySelector : MonoBehaviour
{

    public void Clicked()
    {
        string selectedItem = GameManager.Instance.selected;
        CityStatus cityStatus = GetComponent<CityStatus>();

        switch (selectedItem)
        {
            case "Water":
                if (cityStatus.fireStatus>0)
                {
                    cityStatus.fireStatus--;
                    if (cityStatus.fireStatus < 1)
                    {
                        //Destroy(city.GetChild(city.childCount));
                    }
                }
                break;

            case "Medicine":
                if (cityStatus.infectedStatus>0)
                {
                    cityStatus.infectedStatus--;

                    if (cityStatus.infectedStatus<1)
                    {
                        //Destroy(city.GetChild(city.childCount));
                    }
                    // Debug.Log(GameManager.Instance.selected);
                }
                break;
            default:
                Debug.Log("Invalid selection");
                break;
        }

    }
}
