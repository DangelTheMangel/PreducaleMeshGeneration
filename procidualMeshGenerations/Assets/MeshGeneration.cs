using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class MeshGeneration : MonoBehaviour
{
    Mesh mesh;
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2 meshSize;
    public float incrementDivider = 10;
    public float hightMultyplyer = 10;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        vertices = new Vector3[(int)((meshSize.x +1) * (meshSize.y + 1))];
        triangles = new int[(int)(meshSize.x * meshSize.y * 6)];
        // make creating mesh
        for (int index = 0,z = 0; z <= meshSize.y; z++) {
            for (int x = 0; x <= meshSize.x; x++)
            {
                float y = Mathf.PerlinNoise(x/incrementDivider, z / incrementDivider) * hightMultyplyer;
                vertices[index] = new Vector3(x, y, z);
                index++;
            }
        }

        int verIndex = 0;
        int trieIndex = 0;
        for (int z = 0; z < meshSize.y; z++)
        {
            for (int x = 0; x < meshSize.x; x++)
            {
                triangles[trieIndex + 0] = verIndex + 0;
                triangles[trieIndex + 1] = (int)verIndex + (int)meshSize.x + 1;
                triangles[trieIndex + 2] = verIndex + 1;
                triangles[trieIndex + 3] = verIndex + 1;
                triangles[trieIndex + 4] = verIndex + (int)meshSize.x + 1;
                triangles[trieIndex + 5] = verIndex + (int)meshSize.x + 2;

                verIndex++;
                trieIndex += 6;
            }
            verIndex++;

        }
        
        //update mesh
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
    void createTriangles(int index, Vector3 vec) {
        triangles[index] = (int)vec.x;
        triangles[index+1] = (int)vec.y;
        triangles[index+2] = (int)vec.z;

    }
    void createVertice(int index, Vector3 vector)
    {
        vertices[index] = vector;
    }

    private void LateUpdate()
    {
      
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < vertices.Length; i++) {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}

/*

createVertice(0, new Vector3(0, 0, 0));
createVertice(1, new Vector3(0, 0, 1));
createVertice(2, new Vector3(1, 0, 0));
createVertice(0, new Vector3(1, 0, 1));
createTriangles(0, new Vector3(0, 1, 2));
createTriangles(1, new Vector3(1, 3, 2));
*/