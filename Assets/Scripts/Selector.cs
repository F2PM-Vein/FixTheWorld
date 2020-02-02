using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Selector : MonoBehaviour
{
   
    public void Clicked()
    {
        GameManager.Instance.selected=this.GetComponentInChildren<TextMeshProUGUI>().text.ToString();
        Debug.Log(GameManager.Instance.selected);
    }
}
