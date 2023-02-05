using UnityEngine;

public class generatingObstacles : MonoBehaviour
{
    public uint waitForTime;
    public int rangeGeneratedObstacles;
    public int maxGeneratedObstacles { get; private set; }
    public int minGeneratedObstacles { get; private set; }
    public float obstaclesVelocity;

    public Transform parentTransform;

    void Start()
    {
        minGeneratedObstacles = 1;
    }

    void Update()
    {

        if (Time.time > waitForTime)
		{
            minGeneratedObstacles++;
            maxGeneratedObstacles = minGeneratedObstacles + rangeGeneratedObstacles;
        }

        spawnObstacle(Random.RandomRange(minGeneratedObstacles, maxGeneratedObstacles));

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (GameObject obstacle in obstacles)
		{
            if (obstacle.transform.position.z <= -2 && obstacle != null)
			{
                GameObject.Destroy(obstacle);
			}
		}

        parentTransform.position = new Vector3(0, 0, parentTransform.position.z - obstaclesVelocity * Time.deltaTime);
    }

	public void spawnObstacle(int howMany)
    {
        if (Time.time > waitForTime)
        {
            for (int i = 0; i < howMany; i++)
            {
                if ((int)Mathf.Round(Random.RandomRange(0f, 2f)) == 0)
                {
                    GameObject.Instantiate(GameObject.Find("Cactus1"), new Vector3(Random.RandomRange(-10f, 10f), 1, 20 - Random.RandomRange(-5f, 5f)), Quaternion.identity, parentTransform);
                }
                else
                {
                    GameObject.Instantiate(GameObject.Find("Cactus2"), new Vector3(Random.RandomRange(-10f, 10f), 1, 20 - Random.RandomRange(-5f, 5f)), Quaternion.Euler(new Vector3(0, 0, 0)), parentTransform);
                }
            }

            waitForTime += 2;
        }
    }
}