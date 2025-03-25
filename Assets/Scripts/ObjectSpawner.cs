using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour{

    public void loadObject(string objects){
        Debug.Log(objects);
        Dictionary<string, string> dictionary = new Dictionary<string, string>{
            {"mela", "Models/apple/apple"},
            {"sedia",  "Models/chair/Built-in/Prefabs/chair"},
            {"default", "Models/Cube/cube"}
        };

        string path;
        string[] tokens = objects.Split(' ');

        foreach (string token in tokens){
            Debug.Log($"questo è l token {token}");
            if (dictionary.TryGetValue(token, out string value)){
                Debug.Log($"Valore trovato: {value}");
                path = value;
            }else{
                Debug.Log("Chiave non trovata.");
                path = dictionary["default"];
            }

            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab != null){
                Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
            }
        }
    }
}
