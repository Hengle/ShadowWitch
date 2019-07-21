using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using EditorGUI = UnityEditor.Experimental.Networking.PlayerConnection.EditorGUI;

namespace ShadowWitch.Editor.Window
{
    public class MainWindow : EditorWindow
    {
        #region unity methods
        private void OnEnable()
        {
            Debug.Log("onenable");
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (typeof(WindowBase).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                {
                    WindowBase window = ScriptableObject.CreateInstance(type) as WindowBase;

                    if (window == null)
                    {
                        continue;
                    }
                    
                    EditorManager.AddWindow(window);
                }
            }
        }

        private void OnGUI()
        {
            // EditorGUILayout.LabelField("Test");
            for (int i = 0; i < EditorManager.GetWindowCount(); ++i)
            {
                WindowBase window = EditorManager.GetWindow(i);
                window.OnGUI();
            }
        }
        #endregion
        
        #region methods
        [MenuItem(EditorStringReferences.MenuName + "/Open")]
        private static void Open()
        {
            MainWindow mainWindow = UnityEditor.EditorWindow.GetWindow<MainWindow>(EditorStringReferences.MainWindowName, true);
            mainWindow.Show();
        }
        #endregion
    }
}
