using UnityEngine; 
using System.Collections.Generic;

namespace Task
{
    public class TakeTask : MonoBehaviour
    {
        [SerializeField] private ListTaskSo _listTaskSo;
        [SerializeField] private List<UITaskData> _uiTaskData;

        public int _indexCurrentTask;
         
        private void Awake()
        {
            RandomPotion();
            InitIndexTask();
             PlayerPrefs.SetInt("_indexCurrentTask", _indexCurrentTask);
        }

        //public void Update()
        //{
        //    if (Input.GetKey(KeyCode.R))
        //    {
        //        _indexCurrentTask = 0;
        //        PlayerPrefs.SetInt("_indexCurrentTask", _indexCurrentTask);
        //    }
        //}

        private void InitIndexTask()
        {
            for (int i = 0; i < _listTaskSo.ListTasks.Count; i++)
            {
                _listTaskSo.ListTasks[i].IndexTask(i);
            }
        } 

        private void RandomPotion()
        {
            int _saveIndex = PlayerPrefs.GetInt("_indexCurrentTask");
            var task = _listTaskSo.ListTasks[_saveIndex]; 
            for (int i = 0; i < task.listTasks.Count; i++)
            {
                _uiTaskData[i]._description.text = task.listTasks[i].DescriptionItem;
                _uiTaskData[i]._spritePotion.sprite = task.listTasks[i].AvatarItem;
                _uiTaskData[i]._spritePotionComplete.sprite = task.listTasks[i].AvatarItem;
                _uiTaskData[i]._itemType = task.listTasks[i].ItemTypeEnum;
                _uiTaskData[i]._countPotion.text = task.listTasks[i].Count.ToString();
            }
        }

        public void PlusIndexList(int index)
        {
            if (_indexCurrentTask >= _listTaskSo.ListTasks.Count)
            {
                return;
            }
            else
            {
                _indexCurrentTask += index;
                PlayerPrefs.SetInt("_indexCurrentTask", _indexCurrentTask);
                RandomPotion();
            }

        }

    }
}

