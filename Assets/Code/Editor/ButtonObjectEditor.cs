using System.Linq;
using UnityEditor;

namespace Code.Editor
{
    [CustomEditor(typeof(ButtonObject))]
    public class ButtonObjectEditor : UnityEditor.Editor
    {
        private DoorObject _door;

        private void OnEnable()
        {
            var button = (ButtonObject) target;
            _door = FindObjectsOfType<DoorObject>().FirstOrDefault(d => d.Guid == button.TargetGuid);
        }

        public override void OnInspectorGUI()
        {
            var button = (ButtonObject) target;
            _door = (DoorObject) EditorGUILayout.ObjectField(_door, typeof(DoorObject), true);

            if (_door != null && button.TargetGuid != _door.Guid)
            {
                button.TargetGuid = _door.Guid;
                EditorUtility.SetDirty(button);
            }
        }
    }
}