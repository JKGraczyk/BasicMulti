using UnityEngine;
using Unity.NetCode;

[UnityEngine.Scripting.Preserve]
public class BootstrapScript : ClientServerBootstrap
{
    public override bool Initialize(string defaultWorldName)
    {
        AutoConnectPort = 7979;
        return base.Initialize(defaultWorldName);
    }
}
