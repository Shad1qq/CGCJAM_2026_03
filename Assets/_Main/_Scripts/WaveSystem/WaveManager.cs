using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class WaveManager : MonoBehaviour
{
   [Header("Wave Settings")]
   [SerializeField]private double _localStep = 0.00001;
   [SerializeField]private int _durationToNextWave = 5;
   
   [SerializeField]private List<WavePattern> _wavePatterns = new List<WavePattern>();
   [SerializeField]private Transform[] _areaPoints;
   
   private double _localDifficulty = 1.00;
   private WaveSpawner _waveSpawner;

   private int CountOfEnemiesInWave = 0;

   public void ResetLocalDifficulty() => _localDifficulty = 1.00;
   
   private void Start()
   {
      _waveSpawner = new WaveSpawner();
   }

   private async UniTask NextWave()
   {
      WavePattern pattern = _wavePatterns[Random.Range(0, _wavePatterns.Count - 1)];
      CountOfEnemiesInWave = pattern.NumberOfEnemies;

      await UniTask.WaitForSeconds(_durationToNextWave);
      
      Debug.Log(CountOfEnemiesInWave + " Spawned");
      
      _waveSpawner.SpawnEnemies(CountOfEnemiesInWave, _areaPoints, pattern.Enemies);
   }
   
   private async void Update()
   {
      _localDifficulty += _localStep;
      if (CountOfEnemiesInWave <= 0)
      { 
         Debug.Log("Use");
         await NextWave();
      }
   }
}
