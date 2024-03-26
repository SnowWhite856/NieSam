using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public Vector2 RoomSize;

    [Header("Mesh")]
    public Mesh wallMesh;
    public Mesh floorMesh;

    [Header("Materials")]
    public Material floorMaterial;
    public Material wallMaterial1;
    public Material wallMaterial2;

    private List<Matrix4x4> wallMatrices;
    private List<Matrix4x4> floorMatrices;
    private Vector3 floorSize;
    private Vector3 wallSize;

    private int wallCount;
    private int wallCountw;
    private float scale;
    private float scalew;
    private int floorCount;
    private int floorCountw;
    private float floorScale;
    private float floorScalew;


    public void Update()
    {
        CreateWalls();
        CreateFloor();
        Rednder();
    }

    private void CreateFloor()
    {
        floorMatrices = new List<Matrix4x4>();

        floorCount = Mathf.Max(1, (int)(RoomSize.x / floorSize.x));
        floorScale = (RoomSize.x / floorCount) / floorSize.x;

        floorCountw = Mathf.Max(1, (int)(RoomSize.y / floorSize.x));
        floorScalew = (RoomSize.y / floorCountw) / floorSize.x;

        floorSize = floorMesh.bounds.size;
        for (int j = 0; j < floorCountw; j++)
        {
            for (int i = 0; i < floorCount; i++)
            {
                var t = transform.position + new Vector3(-RoomSize.x / 2 + floorSize.x * floorScale / 2 + i * floorScale * floorSize.x, -wallSize.y / 2, -RoomSize.y / 2 + floorSize.x * floorScalew / 2 + j * floorScalew * floorSize.x);
                var r = transform.rotation;
                var s = new Vector3(floorScale, 1, floorScalew);

                var mat = Matrix4x4.TRS(t, r, s);
                floorMatrices.Add(mat);
            }
        }
    }

    private void Rednder()
    {
        if(wallMatrices != null)
        {
            Graphics.DrawMeshInstanced(wallMesh, 0, wallMaterial1, wallMatrices.ToArray(), wallMatrices.Count);
            Graphics.DrawMeshInstanced(wallMesh, 1, wallMaterial2, wallMatrices.ToArray(), wallMatrices.Count);
            Graphics.DrawMeshInstanced(floorMesh, 0, wallMaterial2, floorMatrices.ToArray(), floorMatrices.Count);
        }
    }

    private void CreateWalls()
    {
        wallMatrices = new List<Matrix4x4>();

        wallSize = wallMesh.bounds.size;

        wallCount = Mathf.Max(1, (int)(RoomSize.x / wallSize.x));
        scale = (RoomSize.x / wallCount) / wallSize.x;

        wallCountw = Mathf.Max(1, (int)(RoomSize.y / wallSize.x));
        scalew = (RoomSize.y / wallCountw) / wallSize.x;

        //X walls

        for (int i = 0; i < wallCount; i++)
        {
            var t = transform.position + new Vector3(-RoomSize.x / 2 + wallSize.x * scale / 2 + i * scale * wallSize.x, 0, -RoomSize.y / 2);
            var r = Quaternion.Euler(0, 90, 0);
            var s = new Vector3(scale, 1, 1);

            var mat = Matrix4x4.TRS(t, r, s);
            wallMatrices.Add(mat);
        }

        for(int i = 0; i < wallCount; i++)
        {
            var t = transform.position + new Vector3(-RoomSize.x / 2 + wallSize.x * scale / 2 + i * scale * wallSize.x, 0, +RoomSize.y / 2);
            var r = Quaternion.Euler(0, 90, 0);
            var s = new Vector3(scale, 1, 1);

            var mat = Matrix4x4.TRS(t, r, s);
            wallMatrices.Add(mat);
        }

        //Y wall

        for (int i = 0; i < wallCountw; i++)
        {
            var t = transform.position + new Vector3(RoomSize.x / 2, 0, -RoomSize.y / 2 + wallSize.x * scalew / 2 + i * scalew * wallSize.x);
            var r = transform.rotation;
            var s = new Vector3(scalew, 1, 1);

            var mat = Matrix4x4.TRS(t, r, s);
            wallMatrices.Add(mat);
        }

        for (int i = 0; i < wallCountw; i++)
        {
            var t = transform.position + new Vector3(-RoomSize.x / 2, 0, -RoomSize.y / 2 + wallSize.x * scalew / 2 + i * scalew * wallSize.x);
            var r = transform.rotation;
            var s = new Vector3(scalew, 1, 1);

            var mat = Matrix4x4.TRS(t, r, s);
            wallMatrices.Add(mat);
        }
    }
}
