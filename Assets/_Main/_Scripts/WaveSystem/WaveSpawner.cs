using UnityEngine;

public class WaveSpawner
{
    public void SpawnEnemies(int numberOfEnemies, Transform[] areaPoints)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform currentPoint = areaPoints[Random.Range(0, areaPoints.Length-1)];
            //Random enemy
        }
        
    }
}
