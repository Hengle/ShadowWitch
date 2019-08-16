using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowWitch.Runtime.DataStructures
{
    public struct RowColumn
    {
        #region fields
        public float Row;
        public float Column;
        #endregion

        #region constructors
        public RowColumn(float row, float col)
        {
            this.Row = row;
            this.Column = col;
        }
        #endregion

        #region methods
        public static implicit operator RowColumn(RowColumnInt rowColumnInt)
        {
            return new RowColumn(rowColumnInt.Row, rowColumnInt.Column);
        }
        #endregion
    }
}
