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
        }
        #endregion
    }
}