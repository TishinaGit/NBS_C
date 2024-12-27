using Inventory;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TakeBlood : MonoBehaviour
{
    [SerializeField] private Image _bloodSprite;
    [SerializeField] private TMP_Text _textCount;
    [SerializeField] private Sprite _emptySprite;

    private InventoryPanel _inventoryPanel;
    private List<InventoryCell> _cell; 

    [Inject] public void Construct(List<InventoryCell> Cells, InventoryPanel InventoryPanel)
    {
        _cell = Cells;
        _inventoryPanel = InventoryPanel;
    }

    private void OnEnable()
    {
        SearchBloodInCell(); 
    } 
    public void SearchBloodInCell()
    {
        for (int i = 0; i < _cell.Count; i++)
        {
            if (_cell[i].CurrentData.Type == ItemTypeEnum.Blood)
            { 
                _bloodSprite.sprite = _cell[i].CurrentData.AvatarItem;
                _textCount.text = _cell[i].CurrentData.Count.ToString(); 
            } 
        }
    }

    public void BTM_FillIn()
    {
        CheckForNumber();
        _inventoryPanel.RemoveItem(ItemTypeEnum.Blood, 1);
        SearchBloodInCell(); 
    }

    public void CheckForNumber()
    {
        for (int i = 0; i < _cell.Count; i++)
        {
            if (_cell[i].CurrentData.Type == ItemTypeEnum.Blood)
            { 
                if (_cell[i].CurrentData.Count == 1)
                {
                    _bloodSprite.sprite = _emptySprite;
                    _textCount.text = "no";
                }
            }
        }
    }
}
