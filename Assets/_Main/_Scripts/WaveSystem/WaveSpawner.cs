using UnityEngine;

public class WaveSpawner
{
    public void SpawnEnemies(int numberOfEnemies, Vector2 areaPointOne, Vector2 areaPointTwo)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float x = Random.Range(areaPointOne.x, areaPointTwo.x);
            float y = Random.Range(areaPointOne.y, areaPointTwo.y);
        
            Vector2 randomPos = new Vector2(x, y);

            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = randomPos;
        }
    }
}
