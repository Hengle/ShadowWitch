using System;
using System.Collections.Generic;
using ShadowWitch.Runtime.Map;
using UnityEngine;
using ShadowWitch.Runtime.DataStructures;

namespace ShadowWitch.Runtime.MonoBehaviours
{
    [ExecuteInEditMode]
    public class MapBehaviour : MonoBehaviour, ISerializationCallbackReceiver
    {
        #region fields
        [SerializeField]
        private MapBase map;
        [SerializeField]
        private List<string> layerGOKeyList;
        [SerializeField]
        private List<GameObject> layerGOList;
        private Dictionary<string, GameObject> layerGODict;
        #endregion
        
        #region properties
        public SizeInt MapSize
        {
            get { return map.MapSize; }
        }

        public Size CellSize
        {
            get { return map.CellSize; }
        }
        #endregion

        #region interface implementations
        public void OnBeforeSerialize()
        {
            layerGOKeyList.Clear();
            layerGOList.Clear();

            foreach (var pair in layerGODict)
            {
                layerGOKeyList.Add(pair.Key);
                layerGOList.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            layerGODict.Clear();
            
            for (int i = 0; i < layerGOKeyList.Count; ++i)
            {
                layerGODict.Add(layerGOKeyList[i], layerGOList[i]);    
            }
        }
        #endregion

        #region methods
        public void Init(MapBase map, Dictionary<string, GameObject> layerGODict)
        {
            this.map = map;
            layerGOKeyList = new List<string>();
            layerGOList = new List<GameObject>();
            this.layerGODict = layerGODict;
        }
        #endregion
    }
}