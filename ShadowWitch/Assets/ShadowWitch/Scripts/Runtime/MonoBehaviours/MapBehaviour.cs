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
        private MapBase map;
        private List<string> layerGOKeyList;
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
            
        }
        #endregion

        #region methods
        public void Init(MapBase map)
        {
            this.map = map;
            layerGODict = new Dictionary<string, GameObject>();
            layerGOKeyList = new List<string>();
            layerGOList = new List<GameObject>();
        }
        #endregion
    }
}