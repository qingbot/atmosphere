using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AtmospherePass : ScriptableRenderPass
{

    private ScriptableRenderer render;

    private RenderTexture rt;

    private Material material;
    public AtmospherePass()
    {
        var shader = Shader.Find("Unlit/Atmosphere");
        material = new Material(shader);
        
    }

    public void SetRender(ScriptableRenderer render)
    {
        this.render = render;
    }

    public void SetRenderPassEvent(RenderPassEvent e)
    {
        renderPassEvent = e;
    }
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        if (renderingData.cameraData.cameraType == CameraType.SceneView)
            return;

        if (rt == null)
        {
            var camera = renderingData.cameraData.camera;
            rt = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 0, renderingData.cameraData.cameraTargetDescriptor.colorFormat);
            rt.Create();
        }

        var command = CommandBufferPool.Get("Atmosphere");

        command.Blit(render.cameraColorTarget, rt);

        command.SetGlobalTexture("_cameraTexture1", rt);

        command.SetRenderTarget(render.cameraColorTarget);

        command.DrawProcedural(Matrix4x4.identity, material, 0, MeshTopology.Triangles, 4);

        context.ExecuteCommandBuffer(command);

        command.Release();
    }

    //更新参数
    private void Update()
    {
        
    }
}
