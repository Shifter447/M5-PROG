using UnityEngine;

public class BallCreator : MonoBehaviour
{
    public GameObject prefab;
    private float elapsedTime = 0f;

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Color color = RandomColor();
            Vector3 randPos = RandomPosition(-10f, 10f);
            CreateBall(color, randPos);
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 1f)
        {
            Color color = RandomColor();
            Vector3 randPos = RandomPosition(-10f, 10f);
            GameObject ball = CreateBall(color, randPos);
            DestroyBall(ball);

            elapsedTime = 0f;
        }
    }


    private Color RandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            1f 
        );
    }

    private Vector3 RandomPosition(float min, float max)
    {
        return new Vector3(
            Random.Range(min, max),
            Random.Range(1f, 10f), 
            Random.Range(min, max)
        );
    }

    private GameObject CreateBall(Color c, Vector3 position)
    {
        GameObject ball = Instantiate(prefab, position, Quaternion.identity);

        Material mat = ball.GetComponent<MeshRenderer>().material;

        mat.SetColor("_Color", c);

        if (mat.shader.name == "Universal Render Pipeline/Lit")
        {
            mat.SetColor("_BaseColor", c);
        }

        return ball;
    }

    private void DestroyBall(GameObject ball)
    {
        Destroy(ball, 3f);
    }
}