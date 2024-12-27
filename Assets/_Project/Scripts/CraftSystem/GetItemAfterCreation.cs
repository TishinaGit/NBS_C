using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections; 

using Inventory;
using System;

namespace CraftSystem
{
    public class GetItemAfterCreation : MonoBehaviour
    {
        [SerializeField] private Crafts _crafts;

        public Sprite _itemAvatar;
        public ItemTypeEnum ItemType;
        public TMP_Text CountText;
        public Image AvatarItem;
        public int Id;

        public bool isBTMClick = false;

        public static event Action RefreshCell;

        private void OnEnable()
        {
            CraftPanelInCellMove.SearchDataCell += ItemTakeCheck;
        }

        private void OnDisable()
        {
            CraftPanelInCellMove.SearchDataCell -= ItemTakeCheck;
        }

        private void Update()  
        {
            CheckBool();
        }

        public void SetPropertiesCreateItem(ItemTypeEnum itemTypeEnum, string text, Sprite sprite, int ID)
        {
            ItemType = itemTypeEnum;
            CountText.text = text;
            AvatarItem.sprite = sprite;
            Id = ID;
        }

        public void BTM_TakeItem()
        {
            isBTMClick = true;
            _crafts.CraftPotion(); 
        }

        private void CheckBool()
        {
            if (isBTMClick == true)
            {
                StartCoroutine(UpdateBool());
                RefreshCell?.Invoke(); 
            }
        }

        private IEnumerator UpdateBool()
        { 
            yield return new WaitForSeconds(0.2f);
            isBTMClick = false;
        }

        public void ItemTakeCheck()
        {
            for (int i = 0; i < _crafts._cellItemData.Count; i++)
            {
                Debug.Log(_crafts._cellItemData.Count);
                if (_crafts._cellItemData.Count <= 1)
                {
                    Debug.Log("1");
                    SetPropertiesCreateItem(ItemTypeEnum.None, " ", _itemAvatar, 0);
                }
            }

        }
    }
}
