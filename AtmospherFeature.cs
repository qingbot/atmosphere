using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AtmospherFeature : ScriptableRendererFeature
{
    private AtmospherePass atmospherePass;

    [SerializeField] private RenderPassEvent atmosphereRenderEvent = RenderPassEvent.AfterRenderingOpaques;
    public override void Create()
    {
        atmospherePass = new AtmospherePass();

        name = "AtmospherePass";

        atmospherePass.SetRenderPassEvent(atmosphereRenderEvent);
    }


    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {

        atmospherePass.SetRender(renderer);

        renderer.EnqueuePass(atmospherePass);
    }

}
