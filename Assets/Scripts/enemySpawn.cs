using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class enemySpawn : MonoBehaviour
{

    public GameObject enemygreen;
    private float time;
    private int timeplus;
    private int enemycount;

    void Start()
    {
        timeplus = Random.Range(3, 10);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 8 + timeplus && enemycount < 15)
        {
            int numx = Random.Range(-10, 10);
            int numz = Random.Range(-10, 10);
            Vector3 position = new Vector3(numx + transform.position.x, 0.0f, numz + transform.position.z);
            Instantiate(enemygreen, position, Quaternion.identity);
            enemycount++;
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
