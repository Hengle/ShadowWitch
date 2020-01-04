using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace ShadowWitch.Editor.Window
{
    public class MainWindow : EditorWindow
    {
        #region fields
        private int currentWindowIndex = 0;
        #endregion
        
        #region unity methods
        private void OnEnable()
        {
            for (int i = 0; i < WindowManager.GetWindowCount(); ++i)
            {
                WindowBase window = WindowManager.GetWindow(i);
                window.OnEnable();
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < WindowManager.GetWindowCount(); ++i)
            {
                WindowBase window = WindowManager.GetWindow(i);
                window.OnDisable();
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            currentWindowIndex = GUILayout.Toolbar(currentWindowIndex, WindowManager.GetWindowNames());
            WindowBase currentWindow = WindowManager.GetWindow(currentWindowIndex);
            currentWindow.OnGUI();
            EditorGUILayout.EndVertical();
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
