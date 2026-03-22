using JetBrains.Annotations;
using UnityEngine;

public class WaveSpawner
{
    public void SpawnEnemies(int numberOfEnemies, Transform[] areaPoints, GameObject[] objectsToSpawn)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform currentPoint = areaPoints[Random.Range(0, areaPoints.Length-1)];
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length-1)]; 
            
            GameObject.Instantiate(objectToSpawn, currentPoint.position, Quaternion.identity);
        }
        
    }
}
