using UnityEngine;

namespace Enemy {
    public static class PhysicsDebug {

        public static void DrawDebug(Vector3 WorldPos, float Radius, float Seconds){
            Debug.DrawRay(WorldPos, Radius * Vector3.up, Color.red, Seconds);
            Debug.DrawRay(WorldPos, Radius * Vector3.down, Color.red, Seconds);
            Debug.DrawRay(WorldPos, Radius * Vector3.left, Color.red, Seconds);
            Debug.DrawRay(WorldPos, Radius * Vector3.right, Color.red, Seconds);
            Debug.DrawRay(WorldPos, Radius * Vector3.forward, Color.red, Seconds);
            Debug.DrawRay(WorldPos, Radius * Vector3.back, Color.red, Seconds);
        }
    }
}