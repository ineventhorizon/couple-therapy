using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class RoadManager : MonoBehaviour

{
    [SerializeField] private GameObject myRoad;
    [SerializeField] private Transform parent;
    [SerializeField] private List<GameObject> roads;
    [SerializeField] private List<Transform> roadPath;
    [BoxGroup("Road Settings")]
    public float roadLength = 14f;
    [BoxGroup("Road Settings")]
    public int roadCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button("Create")]
    private void CreateRoad()
    {
        var index = roads.Count == 0 ? 0 : roads.Count ;
        var roadPosition = index * (Vector3.forward*roadLength);
        var newRoad = Instantiate(myRoad, roadPosition, Quaternion.identity, parent);
        roads.Add(newRoad);
        roadPath.Add(newRoad.transform);

    }
    [Button("Delete")]
    void DeleteRoad()
    {
        if (roads.Count == 0) return;
        DestroyImmediate(roads[roads.Count - 1]);
        roads.RemoveAt(roads.Count - 1);
        roadPath.RemoveAt(roadPath.Count - 1);
    }

    [Button("Delete All")]
    void DeleteAll()
    {
        for (int i = 0; i < roads.Count; i++)
        {
            DestroyImmediate(roads[i]);
        }
        roads.Clear();
        roadPath.Clear();
    }

    [Button("Create Multiple")]
    void CreateMultipleRoad()
    {
        for(int i = 0; i < roadCount; i++)
        {
            CreateRoad();
        }
    }
}
