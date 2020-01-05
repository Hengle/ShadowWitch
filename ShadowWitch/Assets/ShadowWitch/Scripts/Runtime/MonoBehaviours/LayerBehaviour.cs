using System.Collections.Generic;
using UnityEngine;

namespace ShadowWitch.Runtime.MonoBehaviours
{
    public class LayerBehaviour : MonoBehaviour, ISerializationCallbackReceiver
    {
        #region fields
        [SerializeField]
        private List<int> cellDataKeyList;
        [SerializeField]
        private List<CellDataBase> cellDataList;
        private Dictionary<int, CellDataBase> cellDataDict;
        #endregion
        
        #region interface implementations
        public void OnBeforeSerialize()
        {
            cellDataKeyList.Clear();
            cellDataList.Clear();

            foreach (var pair in cellDataDict)
            {
                cellDataKeyList.Add(pair.Key);
                cellDataList.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            cellDataDict.Clear();
            
            for (int i = 0; i < cellDataKeyList.Count; ++i)
            {
                cellDataDict.Add(cellDataKeyList[i], cellDataList[i]);    
            }
        }
        #endregion

        #region methods
        public void Init()
        {
            cellDataDict = new Dictionary<int, CellDataBase>();
            cellDataKeyList = new List<int>();
            cellDataList = new List<CellDataBase>();
        }
        #endregion
    }
}