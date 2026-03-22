using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour
{
    [Header("Настройки зоны")]
    [SerializeField] private Transform player; 
    [SerializeField] private float zoneRadius = 5f;

    [Header("Настройки таймера")]
    [SerializeField] private float targetTime = 3f;
    [SerializeField] private float fillSpeed = 1f;
    [SerializeField] private float emptySpeed = 1f;

    [Header("Визуализация")]
    [SerializeField] private UnityEngine.UI.Image fillImage;
    [SerializeField] private GameObject progressBar;

    private Coroutine timerCoroutine;
    private float currentProgress = 0f;
    private bool isInZone = false;

    void Start()
    {
        if (progressBar != null)
            progressBar.SetActive(false);

        currentProgress = 0f;
        UpdateFillImage();
    }

    void FixedUpdate()
    {
        bool currentlyInZone = IsPlayerInZone();

        if (currentlyInZone != isInZone)
        {
            isInZone = currentlyInZone;
            OnZoneStateChanged();
        }
    }

    bool IsPlayerInZone()
    {
        if (player == null) return false;

        float distance = Vector2.Distance(transform.position, player.position);
        return distance <= zoneRadius;
    }

    void OnZoneStateChanged()
    {
        if (isInZone)
        {
            if (progressBar != null)
                progressBar.SetActive(true);

            StartTimer(true);
        }
        else
            StartTimer(false);
    }

    void StartTimer(bool isFilling)
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(ProgressCoroutine(isFilling));
    }

    IEnumerator ProgressCoroutine(bool isFilling)
    {
        float targetProgress = isFilling ? 1f : 0f;
        float speed = isFilling ? fillSpeed : emptySpeed;

        while (Mathf.Abs(currentProgress - targetProgress) > 0.01f)
        {
            float delta = Time.deltaTime * speed;

            if (isFilling)
                currentProgress += delta;
            else
                currentProgress -= delta;

            currentProgress = Mathf.Clamp01(currentProgress);

            UpdateFillImage();

            if (isFilling && currentProgress >= 0.99f)
            {
                currentProgress = 1f;
                UpdateFillImage();
                OnTimerComplete();
                break;
            }
            else if (!isFilling && currentProgress <= 0.01f)
            {
                currentProgress = 0f;
                UpdateFillImage();
                OnTimerReset();
                break;
            }

            yield return null;
        }

        timerCoroutine = null;
    }

    void UpdateFillImage()
    {
        if (fillImage != null)
            fillImage.fillAmount = currentProgress;
    }

    void OnTimerComplete()
    {
        Finish();
    }

    void OnTimerReset()
    {
        if (progressBar != null)
            progressBar.SetActive(false);
    }

    void Finish()
    {
        Debug.Log("Finish метод вызван!");
    }

    public void ResetTimer()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        currentProgress = 0f;
        UpdateFillImage();

        if (progressBar != null)
            progressBar.SetActive(false);

        isInZone = false;
        timerCoroutine = null;
    }

    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, zoneRadius);
    }
}