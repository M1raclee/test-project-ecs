using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Code.Editor
{
    [CustomEditor(typeof(DoorObject))]
    public class DoorObjectEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var door = (DoorObject) target;

            if (string.IsNullOrEmpty(door.Guid))
                GenerateGuid(door);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Open"))
                Open();
            else if (GUILayout.Button("Close"))
                Close();
            else if (GUILayout.Button("Set opened position"))
                SetOpenedPosition();
            else if (GUILayout.Button("Set closed position"))
                SetClosedPosition();
        }

        private void Open()
        {
            var door = (DoorObject) target;
            door.transform.position = door.OpenedPosition;
        }

        private void Close()
        {
            var door = (DoorObject) target;
            door.transform.position = door.ClosedPosition;
        }

        private void SetOpenedPosition()
        {
            var door = (DoorObject) target;
            door.OpenedPosition = door.transform.position;
            EditorUtility.SetDirty(door);
        }
        
        private void SetClosedPosition()
        {
            var door = (DoorObject) target;
            door.ClosedPosition = door.transform.position;
            EditorUtility.SetDirty(door);
        }

        private void GenerateGuid(DoorObject door)
        {
            door.Guid = Guid.NewGuid().ToString();

            EditorUtility.SetDirty(door);
            EditorSceneManager.MarkSceneDirty(door.gameObject.scene);
        }
    }
}