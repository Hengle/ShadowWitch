using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowWitch.Runtime.DataStructures
{
    public struct RowColumnInt
    {
        #region fields
        public int Row;
        public int Column;
        #endregion

        #region constructors
        public RowColumnInt(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }
        #endregion

        #region methods
        public static explicit operator RowColumnInt(RowColumn rowColumn)
        {
            return new RowColumnInt((int)rowColumn.Row, (int)rowColumn.Column);
        }
        #endregion
    }
}
