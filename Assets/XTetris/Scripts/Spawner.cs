using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    // Groups
    public GameObject[] groups;

    void Start() {
        // Spawn initial Group
        SpawnNext();
    }

    public void SpawnNext() {
        // Random Index
        int i = Random.Range(0, groups.Length);

        // Spawn Group at current Position
        Instantiate(groups[i],
            transform.position,
            Quaternion.identity);
    }
}