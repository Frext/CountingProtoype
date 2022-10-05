using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GoalCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CounterText;
    [SerializeField] private string precedingText;

    [SerializeField] private IntVariable score;

    void Start()
    {
        score.value = 0;
        UpdateText();
    }

    void OnTriggerEnter(Collider other)
    {
        score.value += 1;
        UpdateText();
    }

    private void UpdateText()
    {
        CounterText.text = precedingText + " " + score.value;
    }
}
