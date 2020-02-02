using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    [SerializeField]
    public enum Category
    {
        Water, Medicine, Dam
    }

    [CreateAssetMenu(menuName = "ScriptableObjects/Item SO", fileName = "Item", order = 1)]
    public class ItemSO : ScriptableObject
    {
        public string Name;
        public int itemID;
        public Sprite itemIcon;
        public string itemDescription;
        public Category itemCategory;
        [FMODUnity.EventRef]
        public string Clip = null;

        [SerializeField]
        public enum Category
        {
            Fire, Flood, Virus
        }
    }
}
