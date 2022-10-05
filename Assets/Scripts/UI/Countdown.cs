using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [Tooltip("Alloted time in seconds.")]
    [SerializeField] private float allottedTime;

    [Space]
    [SerializeField] private TextMeshProUGUI remainingTimeText;
    [SerializeField] private string precedingText;

    [Space]
    [SerializeField] private UnityEvent finishEvent;

    void Update()
    {
        allottedTime -= Time.deltaTime;
        UpdateText();

        if (allottedTime < -0.01f)
        {
            finishEvent.Invoke();
        }
    }

    private void UpdateText()
    {
        remainingTimeText.text = precedingText + " " + (int)allottedTime;
    }
}
