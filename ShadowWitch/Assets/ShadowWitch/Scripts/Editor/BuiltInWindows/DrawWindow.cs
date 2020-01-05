using System;
using ShadowWitch.Editor.Layer;
using ShadowWitch.Editor.Window;
using UnityEditor;
using UnityEngine;

namespace ShadowWitch.Editor.BuiltInWindows
{
    public class DrawWindow : WindowBase
    {
        #region fields
//        private GameObject currentPrefab;
        private GameObject prefabInstance;
        #endregion
        
        #region properties
        public override string Name
        {
            get { return "Draw Window"; }
        }
        #endregion
        
        #region methods
        public override void OnEnable()
        {
            EditorEventManager.GetEditorEventEvent += OnGetEditorEventEvent;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

            if (EditorManager.CurrentPrefab != null)
            {
                prefabInstance = UnityEngine.Object.Instantiate<GameObject>(EditorManager.CurrentPrefab);
            }
        }

        public override void OnDisable()
        {
            // when play the game, unity will call OnDisable then call OnEnable
            EditorEventManager.GetEditorEventEvent -= OnGetEditorEventEvent;
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            UnityEngine.Object.DestroyImmediate(prefabInstance);
        }
        
        public override void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            EditorGUI.BeginChangeCheck();
            LayerManager.CurrentLayerIndex = EditorGUILayout.Popup("Current Layer", LayerManager.CurrentLayerIndex, LayerManager.GetLayerNames());

            if (EditorGUI.EndChangeCheck())
            {
                // todo
            }
            
            EditorGUI.BeginChangeCheck();
            EditorManager.CurrentPrefab = EditorGUILayout.ObjectField("Current Prefab", EditorManager.CurrentPrefab, typeof(GameObject), false) as GameObject;
            
            if (EditorGUI.EndChangeCheck())
            {
                Debug.Log("prefab changed");
                UnityEngine.Object.DestroyImmediate(prefabInstance);
                prefabInstance = UnityEngine.Object.Instantiate<GameObject>(EditorManager.CurrentPrefab);
            }
            EditorGUILayout.EndVertical();
        }
        
        private void OnGetEditorEventEvent(object sender, EventArgs e)
        {
            if (prefabInstance == null)
            {
                return;
            }
            
            Event currentEvent = EditorEventManager.CurrentEvent;

//            if (currentEvent.type != EventType.MouseMove && currentEvent.type != EventType.MouseDown)
//            {
//                return;
//            }
            
            Ray ray = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition);
            
            if (!Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity))
            {
                return;
            }

            prefabInstance.transform.position = raycastHit.point;;
            LayerManager.CurrentLayer.DrawCell();
        }
        
        private void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                UnityEngine.Object.DestroyImmediate(prefabInstance);
                EditorManager.CurrentPrefab = null;
                prefabInstance = null;
            }
        }
        #endregion
    }
}