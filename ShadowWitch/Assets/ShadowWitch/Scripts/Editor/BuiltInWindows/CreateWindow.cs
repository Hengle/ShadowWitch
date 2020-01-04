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
        private SizeInt mapSize = new SizeInt(10, 10);
        private Size cellSize = new Size(1f, 1f);
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
        
        #region properties
        public override string Name
        {
            get { return "Create Window"; }
        }
        #endregion
        
        #region methods
        public override void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            currentSelectedMapTypeIndex = EditorGUILayout.Popup("Select Map Type", currentSelectedMapTypeIndex, mapTypeNames);
            EditorGUILayout.BeginHorizontal();
            int mapSizeWidth = EditorGUILayout.IntField("Map Width", mapSize.Width);
            int mapSizeHeight = EditorGUILayout.IntField("Map Height", mapSize.Height);
            mapSize = new SizeInt(mapSizeWidth, mapSizeHeight);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            float cellSizeWidth = EditorGUILayout.FloatField("Cell Width", cellSize.Width);
            float cellSizeHeight = EditorGUILayout.FloatField("Cell Height", cellSize.Height);
            cellSize = new Size(cellSizeWidth, cellSizeHeight);
            EditorGUILayout.EndHorizontal();
            
            if (GUILayout.Button("Create Map"))
            {
                CreateNewWindow();
            }
            
            EditorGUILayout.EndVertical();
        }

        private void CreateNewWindow()
        {
            MapBehaviour mainMapBehaviour = EditorManager.CreateMainMap(mapTypes[currentSelectedMapTypeIndex], mapSize, cellSize);
        }
        #endregion
    }
}