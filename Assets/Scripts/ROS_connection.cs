using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

public class ROS_connection : MonoBehaviour{

    public ObjectSpawner obj;
    void Start(){
        ROSConnection.GetOrCreateInstance().Subscribe<StringMsg>("/objectString", object_callback);
    }

    void object_callback(StringMsg msg){
        Debug.Log(msg);
        obj.loadObject(msg.data);
    }

    void Update(){
        
    }
}
