using System;
using System.Net.Configuration;
using UnityEngine;

public class QuadConstruct : MonoBehaviour
{
    [SerializeField] private Material material;

    void Start()
    {
        BuildCubeSide(CubeSideEnum.Top);
        BuildCubeSide(CubeSideEnum.Bottom);
        BuildCubeSide(CubeSideEnum.Left);
        BuildCubeSide(CubeSideEnum.Right);
    }

    private void ConstructQuad(Side side)
    {
        Mesh newMesh = new Mesh();
        newMesh.vertices = side.Vertices;
        newMesh.triangles = side.Triangles;
        newMesh.normals = side.Normals;
        newMesh.uv = side.UVs;
        
        newMesh.RecalculateBounds();

        GameObject sideGameObj = new GameObject(side.SideName.ToString());
        sideGameObj.transform.SetParent(transform);
        
        var meshFilter = sideGameObj.AddComponent<MeshFilter>();
        meshFilter.mesh = newMesh;
        
        var meshRenderer = sideGameObj.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        
    }

    private void BuildCubeSide(CubeSideEnum side)
    {
        Mesh quadMesh = new Mesh();
        
        // All Front vertices
        Vector3 vert000 = new Vector3(0, 0, 0);
        Vector3 vert100 = new Vector3(1, 0, 0);
        Vector3 vert110 = new Vector3(1, 1, 0);
        Vector3 vert010 = new Vector3(0, 1, 0);
        
        // All Back vertices
        Vector3 vert001 = new Vector3(0, 0, 1);
        Vector3 vert101 = new Vector3(1, 0, 1);
        Vector3 vert111 = new Vector3(1, 1, 1);
        Vector3 vert011 = new Vector3(0, 1, 1);
        
        // UVs
        Vector2 uv00 = new Vector2(0, 0);
        Vector2 uv10 = new Vector2(1, 0);
        Vector2 uv11 = new Vector2(1, 1);
        Vector2 uv01 = new Vector2(0, 1);

        switch (side)
        {
            case CubeSideEnum.Top:
                var topSide = new Side(CubeSideEnum.Top, 
                    new[] { vert010, vert011, vert111, vert110 }, 
                    new[] {0, 1, 2, 0, 2, 3},
                    new[] {Vector3.up, Vector3.up, Vector3.up, Vector3.up},
                    new[] {uv00, uv01, uv11, uv10}
                    );
                ConstructQuad(topSide);
                break;
            case CubeSideEnum.Bottom:
                var bottomSide = new Side(CubeSideEnum.Bottom,
                    new [] {vert000, vert001, vert101, vert100},
                    new [] {2, 1, 0, 3, 2, 0},
                    new [] {Vector3.down, Vector3.down, Vector3.down, Vector3.down},
                    new[] {uv00, uv01, uv11, uv10}
                    );
                ConstructQuad(bottomSide);
                break;
            case CubeSideEnum.Left:
                var leftSide = new Side(CubeSideEnum.Left,
                    new [] { vert001, vert011, vert010, vert000},
                    new [] {0, 1, 2, 0, 2, 3},
                    new [] {Vector3.left, Vector3.left, Vector3.left, Vector3.left },
                    new[] {uv00, uv01, uv11, uv10}
                    );
                ConstructQuad(leftSide);
                break;
            case CubeSideEnum.Right:
                var rightSide = new Side(CubeSideEnum.Right,
                    new [] {vert100, vert110, vert111, vert101},
                    new [] {0, 1, 2, 0, 2, 3},
                    new[] {Vector3.right, Vector3.right, Vector3.right, Vector3.right},
                    new[] {uv00, uv01, uv11, uv10}
                    );
                ConstructQuad(rightSide);
                break;
            case CubeSideEnum.Front:
                break;
            case CubeSideEnum.Back:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(side), side, null);
        }
        
        
        // Vector3[] vertices = new Vector3[4];
        // Vector3[] normals = new Vector3[4];
        // Vector2[] uv = new Vector2[4];
        // int[] triangles = new int[6];
        //
        // vertices = new[]
        // {
        //     new Vector3(0, 0, 0), 
        //     new Vector3(1, 0, 0), 
        //     new Vector3(1, 1, 0), 
        //     new Vector3(0, 1, 0), 
        // };
        //
        // triangles = new[] { 0, 3, 2, 0, 2, 1 };
        //
        // normals = new[]
        // {
        //     Vector3.back,
        //     Vector3.back,
        //     Vector3.back,
        //     Vector3.back,
        // };
        //
        // uv = new[]
        // {
        //     new Vector2(0, 0),
        //     new Vector2(1, 0),
        //     new Vector2(1, 1),
        //     new Vector2(0, 1),
        // };
        //
        //
        // quadMesh.vertices = vertices;
        // quadMesh.triangles = triangles;
        // quadMesh.normals = normals;
        // quadMesh.uv = uv;
        //
        // quadMesh.RecalculateBounds();
        //
        //
        // GameObject quadGameObject = new GameObject("Quad");
        // quadGameObject.transform.SetParent(transform);
        //
        // MeshFilter meshFilter = quadGameObject.AddComponent<MeshFilter>();
        // MeshRenderer meshRenderer = quadGameObject.AddComponent<MeshRenderer>();
        // meshRenderer.sharedMaterial = material;
        //
        // meshFilter.mesh = quadMesh;
    }
}

internal class Side
{
    public Side(CubeSideEnum side, Vector3[] vertices, int[] triangles, Vector3[] normals, Vector2[] uVs)
    {
        Vertices = vertices;
        Triangles = triangles;
        Normals = normals;
        UVs = uVs;
        SideName = side;
    }

    public Vector3[] Vertices { get; }
    public int[] Triangles { get; }
    public Vector3[] Normals { get; }
    public Vector2[] UVs { get; }
    public CubeSideEnum SideName { get; }
}

internal enum CubeSideEnum
{
    Top,
    Bottom,
    Left,
    Right,
    Front,
    Back
}
