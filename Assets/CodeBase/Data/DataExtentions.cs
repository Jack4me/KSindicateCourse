using Unity.VisualScripting;
using UnityEngine;

namespace Data {
    public static class DataExtentions {
        public static Vector3Data AsVectorData(this Vector3 Vector){
            return new Vector3Data(Vector.x, Vector.y, Vector.z);
        }

        public static Vector3 AsUnityVector(this Vector3Data Vector3Data){
            return new Vector3(Vector3Data.x, Vector3Data.y, Vector3Data.z);
        }

        public static Vector3 AddY(this Vector3 Vector, float HeightY){
            Vector.y += HeightY;
            return Vector;
        }

        public static string ToJson(this object Obj){
            return JsonUtility.ToJson(Obj);
        }

        public static T ToDeserlalized<T>(this string Json){
            return JsonUtility.FromJson<T>(Json);
        }
    }
}