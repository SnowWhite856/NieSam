using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public Vector2 RoomSize;
    public Mesh wallMesh;
    public Material material1;
    public Material material2;
    private List<Matrix4x4> wallMatricesN;
    private List<Matrix4x4> floorMatrices;
    private Vector3 wallSize;

    public void Update()
    {
        CreateWalls();
        CreateFloor();
        RednderWalls();
    }

    private void CreateFloor()
    {
        floorMatrices = new List<Matrix4x4>();

    }

    private void RednderWalls()
    {
        if(wallMatricesN != null)
        {
            Graphics.DrawMeshInstanced(wallMesh, 0, material1, wallMatricesN.ToArray(), wallMatricesN.Count);
            Graphics.DrawMeshInstanced(wallMesh, 1, material2, wallMatricesN.ToArray(), wallMatricesN.Count);
        }
    }

    private void CreateWalls()
    {
        wallMatricesN = new List<Matrix4x4>();

        wallSize = wallMesh.bounds.size;

        int wallCount = Mathf.Max(1, (int)(RoomSize.x / wallSize.x));
        float scale = (RoomSize.x / wallCount) / wallSize.x;

        int wallCountw = Mathf.Max(1, (int)(RoomSize.y / wallSize.x));
        float scalew = (RoomSize.y / wallCountw) / wallSize.x;

        for (int i = 0; i < wallCount; i++)
        {
            var t = transform.position + new Vector3(-RoomSize.x / 2 + wallSize.x * scale / 2 + i * scale * wallSize.x, 0, -RoomSize.y / 2);
            var r = Quaternion.Euler(0, 90, 0);
            var s = new Vector3(scale, 1, 1);

            var mat = Matrix4x4.TRS(t, r, s);
            wallMatricesN.Add(mat);
        }

        for(int i = 0; i < wallCount; i++)
        {
            var t = transform.position + new Vector3(-RoomSize.x / 2 + wallSize.x * scale / 2 + i * scale * wallSize.x, 0, +RoomSize.y / 2);
            var r = Quaternion.Euler(0, 90, 0);
            var s = new Vector3(scale, 1, 1);

            var mat = Matrix4x4.TRS(t, r, s);
            wallMatricesN.Add(mat);
        }

        //Side wall

        for (int i = 0; i < wallCountw; i++)
        {
            var t = transform.position + new Vector3(RoomSize.x / 2, 0, -RoomSize.y / 2 + wallSize.x * scalew / 2 + i * scalew * wallSize.x);
            var r = transform.rotation;
            var s = new Vector3(scalew, 1, 1);

            var mat = Matrix4x4.TRS(t, r, s);
            wallMatricesN.Add(mat);
        }

        for (int i = 0; i < wallCountw; i++)
        {
            var t = transform.position + new Vector3(-RoomSize.x / 2, 0, -RoomSize.y / 2 + wallSize.x * scalew / 2 + i * scalew * wallSize.x);
            var r = transform.rotation;
            var s = new Vector3(scalew, 1, 1);

            var mat = Matrix4x4.TRS(t, r, s);
            wallMatricesN.Add(mat);
        }
    }
}
