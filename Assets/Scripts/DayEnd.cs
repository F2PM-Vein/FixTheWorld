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


}
