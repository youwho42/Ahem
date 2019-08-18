using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{

    public static NotificationManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private TextMeshProUGUI notificationText;
    [SerializeField]
    private float fadeTime;

    private IEnumerator notificationCo;

    public void SetNewNotification(string message)
    {
        if(notificationCo != null)
        {
            StopCoroutine(notificationCo);
        }
        notificationCo = FadeOutNotification(message);
        StartCoroutine(notificationCo);
    }

    private IEnumerator FadeOutNotification(string message)
    {
        notificationText.text = message;
        float t = 0;
        while (t < fadeTime)
        {
            t += Time.unscaledDeltaTime;
            notificationText.color = new Color(notificationText.color.r, notificationText.color.g, notificationText.color.b, Mathf.Lerp(1f, 0f, t / fadeTime));
            yield return null;
        }
    }

}

