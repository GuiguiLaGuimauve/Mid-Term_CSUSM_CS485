using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanner : MonoBehaviour {

    public GameObject goal;
    public GameObject Enemy;

	// Use this for initialization
	void Start () {
        Invoke("SpawnAgent", 1);
    }

    // Update is called once per frame
    void SpawnAgent()
    {
        GameObject na = (GameObject)Instantiate(Enemy, this.transform.position, this.transform.rotation);
        na.GetComponent<FollowThePlayer>().position = goal.transform;
        Invoke("SpawnAgent", Random.Range(10, 20));
    }
}
