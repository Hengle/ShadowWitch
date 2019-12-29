using System;
using ShadowWitch.Editor.Window;
using ShadowWitch.Runtime.BuiltInMaps;
using ShadowWitch.Runtime.DataStructures;
using ShadowWitch.Runtime.Map;
using ShadowWitch.Runtime.MonoBehaviours;
using UnityEditor.Experimental.Networking.PlayerConnection;
using UnityEngine;
using EditorGUILayout = UnityEditor.EditorGUILayout;

namespace ShadowWitch.Editor.BuiltInWindows
{
    public class CreateWindow : WindowBase
    {
        #region fields
        private int currentSelectedMapTypeIndex = 0;
        private SizeInt mapSize;
        
        private Type[] mapTypes;
        private string[] mapTypeNames;
        #endregion
        
        #region constructors
        public CreateWindow()
        {
            mapTypes = EditorManager.GetMapTypes();
            mapTypeNames = new string[mapTypes.Length];

            for (int i = 0; i < mapTypes.Length; ++i)
            {
                mapTypeNames[i] = mapTypes[i].ToString();
            }
        }
        #endregion
        
        #region methods
        public override void OnGUI()
        {
            currentSelectedMapTypeIndex = EditorGUILayout.Popup("Select Map Type", currentSelectedMapTypeIndex, mapTypeNames);
                
            if (GUILayout.Button("Create Map"))
            {
                GameObject mapGO = new GameObject("Map");
                MapBehaviour mapBehaviour = mapGO.AddComponent<MapBehaviour>();
                Type mapType = mapTypes[currentSelectedMapTypeIndex];
                MapBase map = mapType.Assembly.CreateInstance(mapType.ToString()) as MapBase;
                mapBehaviour.Init(map);
            }
        }
        #endregion
    }
}