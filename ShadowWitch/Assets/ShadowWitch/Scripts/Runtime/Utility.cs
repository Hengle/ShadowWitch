namespace ShadowWitch.Runtime
{
    public static class Utility
    {
        #region methods
        public static int GetRolColumnID(int row, int column, int width)
        {
            return (row - 1) * width + column;
        }
        #endregion
    }
}