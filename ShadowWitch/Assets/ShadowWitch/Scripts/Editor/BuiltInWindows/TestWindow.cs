using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ShadowWitch.Editor.Window;
using UnityEditor.Experimental.Networking.PlayerConnection;
using EditorGUILayout = UnityEditor.EditorGUILayout;

namespace ShadowWitch.Editor.BuiltInWindows
{
    public class TestWindow : WindowBase
    {
        #region fields
        private float testValue;
        #endregion

        #region constructors
        public TestWindow()
        {
        }
        #endregion

        #region methods
        public override void OnGUI()
        {
            testValue = EditorGUILayout.FloatField("test value", testValue);
        }
        #endregion
    }
}

