using System;
using ShadowWitch.Editor.Window;
using UnityEditor;
using UnityEngine;

namespace ShadowWitch.Editor.BuiltInWindows
{
    public class DrawWindow : WindowBase
    {
        #region fields
        private GameObject currentPrefab;
        private GameObject prefabInstance;
        #endregion
        
        #region methods
        public override void OnEnable()
        {
            EditorEventManager.GetEditorEventEvent += OnGetEditorEventEvent;
        }

        public override void OnDisable()
        {
            EditorEventManager.GetEditorEventEvent -= OnGetEditorEventEvent;
        }
        
        public override void OnGUI()
        {
            EditorEventManager.IsStoreEvent = true;
            EditorGUI.BeginChangeCheck();
            currentPrefab = EditorGUILayout.ObjectField("Current Prefab", currentPrefab, typeof(GameObject), false) as GameObject;
            
            if (EditorGUI.EndChangeCheck())
            {
                Debug.Log("prefab changed");
                UnityEngine.Object.DestroyImmediate(prefabInstance);
                prefabInstance = UnityEngine.Object.Instantiate<GameObject>(currentPrefab);
            }
        }
        
        private void OnGetEditorEventEvent(object sender, EventArgs e)
        {
            if (prefabInstance == null)
            {
                return;
            }
            
            Event currentEvent = EditorEventManager.CurrentEvent;

            if (currentEvent.type != EventType.MouseMove && currentEvent.type != EventType.MouseDown)
            {
                return;
            }
            
            Ray ray = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition);
            
            if (!Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity))
            {
                return;
            }

            prefabInstance.transform.position = raycastHit.point;;

            if (currentEvent.type == EventType.MouseDown)
            {
                UnityEngine.Object.Instantiate<GameObject>(prefabInstance);
            }
        }
        #endregion
    }
}