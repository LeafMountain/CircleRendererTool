using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LineRenderer))]
public class CircleRendereHandles : Editor
{
    private GUIStyle style = new GUIStyle();

    private void OnEnable()
    {
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.black;
    }

    private void OnSceneGUI()
    {
        LineRenderer lineRenderer = (LineRenderer)target;
        Transform transform = lineRenderer.transform;

        EditorGUI.BeginChangeCheck();
        Vector3 offset = lineRenderer.transform.position;
        float currentRadius = lineRenderer.GetPosition(0).magnitude; // Only works if it's not in world space
        float radius = Handles.RadiusHandle(transform.rotation, offset, currentRadius);
        float currentScale = lineRenderer.positionCount;
        int scale = (int)Handles.ScaleSlider(currentScale, offset, -transform.right, transform.rotation, 1, 1);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(lineRenderer, "Changed circle");
            lineRenderer.DrawCircle(radius, scale);
        }
    }
}
