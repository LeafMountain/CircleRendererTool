using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LineRendererExtensions
{
    public static void DrawCircle(this LineRenderer lineRenderer, float radius, int segments)
    {
        if (segments < 3)
            return;

        Vector3[] positions = CircleHelper.GetCiclePositions(radius, segments);
        lineRenderer.positionCount = segments;
        lineRenderer.loop = true;
        lineRenderer.SetPositions(positions);
    }
}
