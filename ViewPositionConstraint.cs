#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDKBase;

[ExecuteInEditMode]
public class ViewPositionConstraint : MonoBehaviour, IEditorOnly
{
    public VRCAvatarDescriptor TargetAvatar
    {
        get;
        private set;
    }

    public Vector3 Offset;
    public bool Active;

    private Vector3 ViewPosition;
    private Vector3 PreviousViewPosition;

    void Update()
    {
        TargetAvatar = GetComponentInParent<VRCAvatarDescriptor>();

        if (TargetAvatar != null && Active)
        {
            ViewPosition = transform.position + Vector3.Scale(Offset, transform.lossyScale);
            TargetAvatar.ViewPosition = ViewPosition;

            if (PreviousViewPosition != ViewPosition)
            {
                EditorUtility.SetDirty(TargetAvatar);
                PreviousViewPosition = ViewPosition;
            }
        }
    }
}

[CustomEditor(typeof(ViewPositionConstraint))]
public class ViewPositionConstraintEditor : Editor
{
    ViewPositionConstraint ViewPositionConstraint;

    SerializedProperty active;
    SerializedProperty offset;

    private void OnEnable()
    {
        EditorApplication.update += UpdateCallback;
    }

    private void OnDisable()
    {
        EditorApplication.update -= UpdateCallback;
    }

    void UpdateCallback()
    {
        Repaint();
    }

    public override void OnInspectorGUI()
    {
        ViewPositionConstraint = (ViewPositionConstraint)target;

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.ObjectField(new GUIContent("Detected Avatar"), ViewPositionConstraint.TargetAvatar, typeof(VRCAvatarDescriptor), true);
        EditorGUI.EndDisabledGroup();

        active = serializedObject.FindProperty("Active");
        EditorGUILayout.PropertyField(active, new GUIContent("Active"));

        offset = serializedObject.FindProperty("Offset");
        EditorGUILayout.PropertyField(offset, new GUIContent("Offset"));

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Activate"))
        {
            offset.vector3Value = ViewPositionConstraint.TargetAvatar.ViewPosition - ViewPositionConstraint.transform.position;
            active.boolValue = true;
        }

        if (GUILayout.Button("Zero"))
        {
            offset.vector3Value = Vector3.zero;
            active.boolValue = true;
        }

        GUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}

#endif
