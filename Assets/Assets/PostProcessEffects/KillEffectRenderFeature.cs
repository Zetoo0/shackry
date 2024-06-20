using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable,VolumeComponentMenuForRenderPipeline("KillEffect/TestKillEffect",typeof( UniversalRenderPipeline))]
public class KillEffectRenderFeature : ScriptableRendererFeature
{
    public override void Create()
    {
        throw new System.NotImplementedException();
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        throw new System.NotImplementedException();
    }

    public class KillEffectRenderPass : ScriptableRenderPass
    {
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            
        }
    }

    public bool IsActive()
    {
        throw new System.NotImplementedException();
    }

    public bool IsTileCompatible()
    {
        throw new System.NotImplementedException();
    }
}
