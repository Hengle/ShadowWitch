using UnityEngine;

namespace ShadowWitch.Editor.Layer.BuiltinLayers
{
    public class GroundTileLayer : LayerBase
    {
        #region properties
        public override string Name
        {
            get { return EditorStringReferences.GroundTileLayerName; }
        }
        #endregion
        
        #region methods
        public override void DrawCell()
        {
            Event currentEvent = EditorEventManager.CurrentEvent;
            
            if (currentEvent.type == EventType.MouseDown)
            {
                UnityEngine.Object.Instantiate<GameObject>(EditorManager.CurrentPrefab);
            }
        }
        #endregion
    }
}