using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class SubMeshCreator {

    [MenuItem("MeshCreator/AddSubMesh")]
    public static void AddSubMesh() {
        Mesh mesh = new Mesh();
        AssetDatabase.CreateAsset(mesh, "Assets/Mesh/SubMesh.asset");

        mesh.Clear();

        //z向前
        Vector3[] vertices = new Vector3[] {
            //右上前
            new Vector3(-0.5f, 0.5f, 0.5f),
            //右下前
            new Vector3(-0.5f, -0.5f, 0.5f),
            //左上前
            new Vector3(0.5f, 0.5f, 0.5f),
            //左下前
            new Vector3(0.5f, -0.5f, 0.5f),
            //右上后
            new Vector3(-0.5f, 0.5f, -0.5f),
            //右下后
            new Vector3(-0.5f, -0.5f, -0.5f),
            //左上后
            new Vector3(0.5f, 0.5f, -0.5f),
            //左下后
            new Vector3(0.5f, -0.5f, -0.5f),
        };

        mesh.vertices = vertices;
        mesh.subMeshCount = 6;

        //前面
        int[] triangle = new int[] { 0, 1, 3, 0, 3, 2 };
        mesh.SetTriangles(triangle, 0);

        //后面
        triangle = new int[] { 4, 7, 5, 4, 6, 7 };
        mesh.SetTriangles(triangle, 1);

        //右面
        triangle = new int[] { 0, 4, 5, 0, 5, 1 };
        mesh.SetTriangles(triangle, 2);

        //左面
        triangle = new int[] { 6, 2, 3, 6, 3, 7 };
        mesh.SetTriangles(triangle, 3);

        //上面
        triangle = new int[] { 4, 0, 2, 4, 2, 6 };
        mesh.SetTriangles(triangle, 4);

        //下面
        triangle = new int[] { 7, 3, 1, 7, 1, 5 };
        mesh.SetTriangles(triangle, 5);

        mesh.RecalculateNormals();
    }


    [MenuItem("GameObject/PrintVertices")]
    public static void PrintVertices() {
        GameObject g = Selection.activeGameObject;
        if (null == g) {
            return;
        }
        Mesh mesh = g.GetComponent<MeshFilter>().sharedMesh;
        if (null == mesh) {
            return;
        }
        string str = string.Empty;
        for (int i = 0; i < mesh.vertexCount; i++) {
            str += mesh.vertices[i].ToString();
        }
        Debug.Log(str);
    }


    [MenuItem("MeshCreator/AddMeshWithVertexAttribute")]
    public static void AddMeshWithVertexAttribute() {
        Mesh mesh = new Mesh();
        AssetDatabase.CreateAsset(mesh, "Assets/Mesh/MeshWithVertexAttribute.asset");

        mesh.Clear();

        //z向前
        Vector3[] vertices = new Vector3[] {
            //上面
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            //下面
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, -0.5f, -0.5f),
            //左面
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            //右面
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, -0.5f, -0.5f),
            //前面
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            //后面
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, -0.5f),

            ////右上前
            //new Vector3(-0.5f, 0.5f, 0.5f),
            ////右下前
            //new Vector3(-0.5f, -0.5f, 0.5f),
            ////左上前
            //new Vector3(0.5f, 0.5f, 0.5f),
            ////左下前
            //new Vector3(0.5f, -0.5f, 0.5f),
            ////右上后
            //new Vector3(-0.5f, 0.5f, -0.5f),
            ////右下后
            //new Vector3(-0.5f, -0.5f, -0.5f),
            ////左上后
            //new Vector3(0.5f, 0.5f, -0.5f),
            ////左下后
            //new Vector3(0.5f, -0.5f, -0.5f),
        };

        mesh.vertices = vertices;

        int[] triangle = new int[] { 0, 1, 3, 0, 3, 2,
            4, 6, 5, 5, 6, 7,
            8, 10, 9, 9, 10, 11,
            12, 15, 14, 12, 13, 15,
            16, 18, 17, 18, 19, 17,
            20, 21, 22, 21, 23, 22};
        mesh.SetTriangles(triangle, 0);

        Color[] colors = new Color[6] {
            new Color(1f, 79f / 255f, 79f / 255f, 1f),
            new Color(1f, 26f / 255f, 239f / 255f, 1f),
            new Color(100f / 255f, 51f / 255f, 1f, 1f),
            new Color(51f / 255f, 1f, 238f / 255f, 1f),
            new Color(114f / 255f, 1f, 58f / 255f, 1f),
            new Color(231f / 255f, 1f, 9f / 255f, 1f),
        };
        List<Color> list = new List<Color>();
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 4; j++) {
                list.Add(colors[i]);
            }
        }
        mesh.SetColors(list);

        mesh.RecalculateNormals();
    }


}
