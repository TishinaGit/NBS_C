using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Inventory;
using Zenject;

namespace Task
{
    public class SubmitTask : MonoBehaviour
    {
        [SerializeField] private TakeTask _takeTask;
        [SerializeField] private ListTaskSo _listTaskSo;
        [SerializeField] private InventoryPanel _inventoryPanel; 
        [SerializeField] private List<UITaskData> _uiTasks;

        [SerializeField] private List<InventoryCell> _slotItemData;
        [SerializeField] private List<InventoryCell> _suitableItem;

        private int _maxAmountTask = 3;
        public int InStockInt = 0;

        [Inject]
        public void Construct(InventoryPanel InventoryPanel, List<InventoryCell> SlotItemData)
        {
            _inventoryPanel = InventoryPanel;
            _slotItemData = SlotItemData;
        }

        private void OnEnable()
        {
            SlotCheckInStock(); 
        }

        private void OnDisable()
        {
            RemoveListSuitableItem();
            InStockInt = 0;
        } 

        private void SlotCheckInStock()
        {
            foreach (var task in _uiTasks)
            {
                int _countPotionInt = int.Parse(task._countPotion.text);
                var dataCell = _slotItemData.FirstOrDefault(slot => task._itemType == slot.CurrentData.Type &&
                                                            _countPotionInt == slot.CurrentData.Count ||
                                                            task._itemType == slot.CurrentData.Type &&
                                                            _countPotionInt <= slot.CurrentData.Count);
                if (dataCell != null)
                {
                    AddDataCellInList(dataCell);
                }
               
            } 
        }
         
        private void AddDataCellInList(InventoryCell cell)
        { 
            if (cell != null && cell.CurrentData.Type != ItemTypeEnum.None)
            {
                _suitableItem.Add(cell);
                ComparisonItems(cell);
            } 
        }

        private void ComparisonItems(InventoryCell cell)
        {
            var task = _listTaskSo.ListTasks[_takeTask._indexCurrentTask];
             
            if (_suitableItem != null && _suitableItem.Count > 0 && cell != null)
            {
                for (int i = 0; i < _suitableItem.Count; i++)
                {
                    if (task.listTasks[i].ItemTypeEnum == cell.CurrentData.Type)
                    { 
                        InStockInt++;
                    }
                }
            } 
        }

        public void BTM_PassTask()
        {
            if (InStockInt == _maxAmountTask)
            {
                RemoveItems();
                RemoveListSuitableItem(); 
                _takeTask.PlusIndexList(1);
                InStockInt = 0; 
                SlotCheckInStock();
            }
        }

        private void RemoveItems()
        {
            var task = _listTaskSo.ListTasks[_takeTask._indexCurrentTask];
            
            for (int i = 0; i < _suitableItem.Count; i++)
            {  
                for (int j = 0; j < task.listTasks[i].Count; j++)
                {
                    _inventoryPanel.RemoveItem(_suitableItem[i].CurrentData.Type, task.listTasks[i].Count);
                }
                
            }
        }

        private void RemoveListSuitableItem()
        { 
            if (_suitableItem != null && _suitableItem.Count > 0)
            {
                _suitableItem.Clear( );
            } 
        }
    }
}

