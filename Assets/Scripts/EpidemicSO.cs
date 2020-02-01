using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Epidemic
{
    [SerializeField]
    public enum Progress
    {
        ERADICATED, HAPPENING, NOT_HAPPENING
    }

    [SerializeField]
    public enum Category
    {
        Fire, Flood, Virus
    }

    [System.Serializable]
    public class EntitiesExisting
    {
        public int EpidemicAmount;
    }

    [CreateAssetMenu(menuName = "ScriptableObjects/Epidemic SO", fileName = "Epidemic", order = 1)]
    public class EpidemicSO : ScriptableObject
    {
        public string Name;
        public int epidemicID;
        public Sprite epidemicIcon;
        public string Description;
        public string eradicatedMessage;
        public Category epidemicCategory;

    }
}

