using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class DebugVertices : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;

	void OnDrawGizmos()
	{
		if (vertices == null)
		{
			mesh = GetComponent<MeshFilter>().sharedMesh;
			vertices = mesh.vertices;
		}
		foreach (var v in vertices)
		{
			var objectPos = v;
			var worldPos = transform.position + objectPos;
			var viewVert = SceneView.GetAllSceneCameras()[0].WorldToViewportPoint(worldPos);

			UnityEditor.Handles.Label(worldPos, $"{objectPos}, {worldPos}, {viewVert}");
		}
	}
}
