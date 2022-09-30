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
            _door = (DoorObject) EditorGUILayout.ObjectField(_door, typeof(DoorObject), true);

            if (_door != null)
            {
                var button = (ButtonObject) target;
                button.TargetGuid = _door.Guid;
            }
        }
    }
}