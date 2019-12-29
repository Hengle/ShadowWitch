using ShadowWitch.Runtime.Map;
using UnityEngine;

namespace ShadowWitch.Runtime.MonoBehaviours
{
    public class MapBehaviour : MonoBehaviour
    {
        #region fields
        private MapBase map;
        #endregion
        
        #region methods
        public void Init(MapBase map)
        {
            this.map = map;
        }
        #endregion
    }
}