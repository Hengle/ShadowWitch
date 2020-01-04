using System;
using ShadowWitch.Runtime.Map;
using UnityEngine;
using ShadowWitch.Runtime.DataStructures;

namespace ShadowWitch.Runtime.MonoBehaviours
{
    [ExecuteInEditMode]
    public class MapBehaviour : MonoBehaviour
    {
        #region fields
        private MapBase map;
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
        
        #region methods
        public void Init(MapBase map)
        {
            this.map = map;
        }
        #endregion
    }
}