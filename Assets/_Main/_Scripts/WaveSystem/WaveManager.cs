using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
   [Header("Wave Settings")]
   [SerializeField]private double _localStep = 0.00001;
   [SerializeField]private List<WavePattern> _wavePatterns = new List<WavePattern>();
   [SerializeField]private Transform[] _areaPoints;
   
   
   private double _localDifficulty = 1.00;
   private WaveSpawner _waveSpawner;

   private int CountOfEnemiesInWave = 0;

   public void ResetLocalDifficulty() => _localDifficulty = 1.00;
   
   private void Start()
   {
      _waveSpawner = new WaveSpawner();
      
      NextWave();
   }

   private void NextWave()
   {
      WavePattern pattern = _wavePatterns[Random.Range(0, _wavePatterns.Count - 1)];
      CountOfEnemiesInWave = pattern.NumberOfEnemies;
      
      _waveSpawner.SpawnEnemies(CountOfEnemiesInWave, _areaPoints);
   }
   
   private void Update()
   {
      _localDifficulty += _localStep;
   }
}
