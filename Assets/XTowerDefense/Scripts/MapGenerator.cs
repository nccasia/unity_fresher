using System.Threading;
using UnityEditor;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject prefabBuildingBLock;
    public Transform Root;
    public int width;
    public int height;
    public Vector2 Size;

    [ContextMenu("Generate building-blocks")]
    public void Generate()
    {
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                var pos = Root.position + new Vector3(i * Size.x, 0, j * Size.y);
                var go = Instantiate(prefabBuildingBLock, pos, Quaternion.identity);
                go.transform.parent = Root;
            }
        }
    }

    [ContextMenu("Clear")]
    public void ClearBlocks()
    {
        while (Root.childCount > 0)
        {
            DestroyImmediate(Root.GetChild(0).gameObject);
        }
    }
}