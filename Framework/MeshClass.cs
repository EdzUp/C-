using UnityEngine;
using System.Collections;

public class MeshClass {
	public Mesh CreateQuad( float OffsetX, float OffsetY, float tx, float ty, float bx, float by ) {
		Mesh mesh = new Mesh();
		
		Vector3[] vertices = new Vector3[]
		{
			new Vector3( OffsetX +0.5f,			OffsetY +0.5f,				0 ),
			new Vector3( OffsetX +0.5f, 			OffsetY +( 0.0f -0.5f ),	0 ),
			new Vector3( OffsetX +( 0.0f-0.5f ),	OffsetY +0.5f,				0 ),
			new Vector3( OffsetX +( 0.0f-0.5f ), 	OffsetY +( 0.0f-0.5f ),		0 ),
		};
		
		Vector2[] uv = new Vector2[]
		{
			new Vector2(bx, by),
			new Vector2(bx, ty),
			new Vector2(tx, by),
			new Vector2(tx, ty),
		};
		
		int[] triangles = new int[]
		{
			0, 1, 2,
			2, 1, 3,
		};
		
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.triangles = triangles;
		mesh.RecalculateNormals();
		
		return mesh;
	}
}
