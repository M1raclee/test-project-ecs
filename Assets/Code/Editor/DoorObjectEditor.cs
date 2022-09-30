using System;
using UnityEditor;
using UnityEditor.SceneManagement;

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

        private void GenerateGuid(DoorObject door)
        {
            door.Guid = Guid.NewGuid().ToString();
            
            EditorUtility.SetDirty(door);
            EditorSceneManager.MarkSceneDirty(door.gameObject.scene);
        }
    }
}