using System;

namespace Data {
    [Serializable]
    public class PositionAtLvL {
        public string lvLName;
        public Vector3Data position;

        public PositionAtLvL(string LvLName, Vector3Data Position){
            this.lvLName = LvLName;
            this.position = Position;
        }

        public PositionAtLvL(string InitialLvLName){
            lvLName = InitialLvLName;
        }
    }
}