using Inventory; 
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TakeRedPotion : MonoBehaviour
{
    [SerializeField] private InventoryPanel _inventoryPanel;

    [SerializeField] private Image _uiWaterScales;

    [SerializeField] private Sprite _RedPotion_0;
    [SerializeField] private Sprite _RedPotion_1;
    [SerializeField] private Sprite _RedPotion_2;

    private float _minusRedPotion_0 = 0.2f;
    private float _minusRedPotion_1 = 0.4f;
    private float _minusRedPotion_2 = 0.6f;

    [Inject]
    public void Construct(InventoryPanel InventoryPanel)
    {
        _inventoryPanel = InventoryPanel; 
    } 
    public void BTM_TakeBluePotion_0()
    {
        if (_uiWaterScales.fillAmount > 0.19f)
        {
            _inventoryPanel.AddItem(ItemTypeEnum.RedPotion_0, 1,  10); //_RedPotion_0,
            _uiWaterScales.fillAmount = _uiWaterScales.fillAmount - _minusRedPotion_0;
        }  
    }
    public void BTM_TakeBluePotion_1()
    {
        if (_uiWaterScales.fillAmount > 0.39f)
        {
            _inventoryPanel.AddItem(ItemTypeEnum.RedPotion_1, 1,  11); //_RedPotion_1,
            _uiWaterScales.fillAmount = _uiWaterScales.fillAmount - _minusRedPotion_1;
        }   
    }
    public void BTM_TakeBluePotion_2()
    {
        if (_uiWaterScales.fillAmount > 0.59f)
        {
            _inventoryPanel.AddItem(ItemTypeEnum.RedPotion_2, 1,  12);//  _RedPotion_2,
            _uiWaterScales.fillAmount = _uiWaterScales.fillAmount - _minusRedPotion_2;
        }  
    }
}
