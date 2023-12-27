using System;

namespace Data {
    [Serializable]
    public class Vector3Data {
        public float x;
        public float y;
        public float z;

        public Vector3Data(float X, float Y, float Z){
            this.x = X;
            this.y = Y;
            this.z = Z;
        }

        
    }
}