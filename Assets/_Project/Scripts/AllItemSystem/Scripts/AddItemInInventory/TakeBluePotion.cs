using Inventory;
using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using Zenject;

public class TakeBluePotion : MonoBehaviour
{
    [SerializeField] private InventoryPanel _inventoryPanel;

    [SerializeField] private Image _uiWaterScales;

    [SerializeField] private Sprite _bluePotion_0;
    [SerializeField] private Sprite _bluePotion_1;
    [SerializeField] private Sprite _bluePotion_2;

    private float _minusBluePotion_0 = 0.2f;
    private float _minusBluePotion_1 = 0.4f;
    private float _minusBluePotion_2 = 0.6f;
     
    [Inject]
    public void Construct(InventoryPanel InventoryPanel)
    {
        _inventoryPanel = InventoryPanel;
    }

    private void Awake()
    {
        _uiWaterScales.fillAmount = 1f;
    }

    private void Update()
    {
        if (_uiWaterScales.fillAmount != 1f)
        {
             _uiWaterScales.fillAmount += 0.05f * Time.deltaTime; 
        }
    }
  
    public void BTM_TakeBluePotion_0()
    {
        if (_uiWaterScales.fillAmount > 0.19f)
        {
            _inventoryPanel.AddItem(ItemTypeEnum.BluePotion_0, 1,   7); 
            _uiWaterScales.fillAmount = _uiWaterScales.fillAmount - _minusBluePotion_0;
        }  
    }
    public void BTM_TakeBluePotion_1()
    {
        if (_uiWaterScales.fillAmount > 0.39f)
        {
            _inventoryPanel.AddItem(ItemTypeEnum.BluePotion_1, 1, 8); 
            _uiWaterScales.fillAmount = _uiWaterScales.fillAmount - _minusBluePotion_1;
        } 

    }
    public void BTM_TakeBluePotion_2()
    {
        if (_uiWaterScales.fillAmount > 0.59f)
        {
            _inventoryPanel.AddItem(ItemTypeEnum.BluePotion_2, 1, 9); 
            _uiWaterScales.fillAmount = _uiWaterScales.fillAmount - _minusBluePotion_2;
        }  
    }
}
