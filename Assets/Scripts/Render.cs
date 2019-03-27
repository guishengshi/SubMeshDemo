using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Render : MonoBehaviour {
    public Mesh mesh;
    public Material[] mats;
    public string commandBufferName;
    private CommandBuffer mCommandBuffer;
    private Camera mMainCam;


    void OnEnable()
    {
        MeshRenderer render = GetComponent<MeshRenderer>();
        if (null == render) {
            this.gameObject.AddComponent<MeshRenderer>();
        }
        CleanUp();
    }


    void OnDisable()
    {
        CleanUp();
    }


    void OnWillRenderObject()
    {
        var act = gameObject.activeInHierarchy && enabled;
        if (!act)
        {
            CleanUp();
            return;
        }
        if (null == Camera.main || null == mesh || null == mats || mats.Length <= 0)
        {
            return;
        }
        CleanUp();
        mMainCam = Camera.main;
        mCommandBuffer = new CommandBuffer();
        mCommandBuffer.name = commandBufferName;
        Matrix4x4 M = transform.localToWorldMatrix;
        int count = Mathf.Max(mesh.subMeshCount, mats.Length);
        for (int i = 0; i < count; i++)
        {
            mCommandBuffer.DrawMesh(mesh, M, mats[i], i, 0);
        }
        mMainCam.AddCommandBuffer(CameraEvent.AfterForwardOpaque, mCommandBuffer);
    }


    private void CleanUp() {
        if (null != mMainCam && null != mCommandBuffer)
        {
            mMainCam.RemoveCommandBuffer(CameraEvent.AfterForwardOpaque, mCommandBuffer);
        }
        if (null != mCommandBuffer)
        {
            mCommandBuffer.Clear();
            mCommandBuffer = null;
        }
    }


    void OnDestroy()
    {
        CleanUp();
    }

}
