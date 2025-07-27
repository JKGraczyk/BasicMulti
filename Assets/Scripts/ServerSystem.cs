using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.NetCode;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation)]
partial struct ServerSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    //[BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
       foreach ((
            RefRO<RpcScript> RpcScript,
            RefRO<ReceiveRpcCommandRequest> receiveRpcCommandRequest, Entity entity)
        in SystemAPI.Query<RefRO<RpcScript>, RefRO<ReceiveRpcCommandRequest>>() .WithEntityAccess())
        {
            Debug.Log ("Received Rpc: " + RpcScript.ValueRO.data);
            entityCommandBuffer.DestroyEntity(entity);
        }
        entityCommandBuffer.Playback(state.EntityManager);
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
