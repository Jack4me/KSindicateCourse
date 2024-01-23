using Logic;
using Logic.EnemySpawners;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor {
    [CustomEditor(typeof(SpawnMarker))]
    public class SpawnerMarkerEditor : UnityEditor.Editor {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmp(SpawnMarker spawnPoint, GizmoType gizmo){
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawnPoint.transform.position, 0.5f);
        }
    }
}