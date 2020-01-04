namespace ShadowWitch.Editor.Layer
{
    public abstract class LayerBase
    {
        #region properties
        public abstract string Name { get; }
        #endregion

        #region methods
        public abstract void DrawCell();
        #endregion
    }
}