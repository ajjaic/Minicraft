using UnityEngine;
using UnityEngine.UI;

public class CubeDetails : MonoBehaviour
{
    [SerializeField] private Canvas vertexCanvas;
    [SerializeField] private Text vertext;
    
    void Start()
    {
        MeshFilter mesh = GetComponent<MeshFilter>();
        Mesh meshData = mesh.mesh;

        foreach (var vertex in meshData.vertices)
        {
            var vertexStr = vertex.ToString();
            var newVertext = Instantiate(vertext, vertex, Quaternion.identity);
            newVertext.text = vertexStr;
            newVertext.transform.parent = vertexCanvas.transform;
        }

        foreach (Vector2 uv in meshData.uv)
        {
            print(uv);
        }
    }

}
