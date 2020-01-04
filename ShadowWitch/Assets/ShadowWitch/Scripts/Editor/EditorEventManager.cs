using ShadowWitch.Runtime.MonoBehaviours;
using UnityEditor;
using UnityEngine;
using System;

namespace ShadowWitch.Editor
{
    [CustomEditor(typeof(MapBehaviour))]
    public class EditorEventManager : UnityEditor.Editor
    {
        #region events
        public static EventHandler<EventArgs> GetEditorEventEvent;
        #endregion

        #region fields
        private static bool isStoreEvent;
        private static Event currentEvent;
        private static Camera sceneViewCamera;
        #endregion
        
        #region properties
        public static bool IsStoreEvent
        {
            get { return isStoreEvent; }
            set { isStoreEvent = value; }
        }

        public static Event CurrentEvent
        {
            get { return currentEvent; }
        }

        public static Camera SceneViewCamera
        {
            get { return sceneViewCamera; }
        }
        #endregion
        
        #region unity methods
        private void OnSceneGUI()
        {
            if (isStoreEvent == false)
            {
                return;
            }
            
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
            currentEvent = Event.current;
            sceneViewCamera = SceneView.lastActiveSceneView.camera;

            if (GetEditorEventEvent != null)
            {
                GetEditorEventEvent(this, EventArgs.Empty);
            }
        }

//        [InitializeOnLoadMethod]
//        private static void InitSceneGUIDelegate()
//        {
//            SceneView.duringSceneGui += OnDuringSceneGui;
//        }
//
//        private static void OnDuringSceneGui(SceneView sceneView)
//        {
//            
//        }
        #endregion
    }
}