using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private Mesh mesh;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void Update()
    {
        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 10f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;

        for (int i = 0; i <= rayCount; i++)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            Vector3 vertex; //= origin + new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * viewDistance; ;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)), viewDistance);
            if(raycastHit2D.collider == null)
            {
                
                vertex = origin + new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * viewDistance;
            } else
            {
                Debug.Log("Hit on: ");
                Debug.Log(raycastHit2D.point);
                vertex = raycastHit2D.point;
            }


            vertices[vertexIndex] = vertex;

            if(i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }



        /*vertices[1] = new Vector3(5, 0);
        vertices[2] = new Vector3(0, -5);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;*/

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}
