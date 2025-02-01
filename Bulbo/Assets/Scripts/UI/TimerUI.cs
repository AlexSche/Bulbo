using System.Collections;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timer_text;
    float timer = 0;
    public void startTimer()
    {
        resetTimer();
        StartCoroutine(coutingSeconds());
    }

    public void resetTimer()
    {
        timer = 0;
        StopAllCoroutines();
    }

    IEnumerator coutingSeconds()
    {
        while (true)
        {
            timer_text.text = timer.ToString();
            yield return new WaitForSeconds(1);
            timer++;
        }
    }

}
