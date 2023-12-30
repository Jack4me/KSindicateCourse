using Logic;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor {
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor : UnityEditor.Editor {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmp(EnemySpawner enemySpawner, GizmoType gizmo){
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(enemySpawner.transform.position, 0.5f);
        }
    }
}