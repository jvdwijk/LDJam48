using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFeedback : MonoBehaviour
{

    [SerializeField]
    private Image fireFeedback, damageFeedback;

    [SerializeField]
    private AudioSource damageSound;

    private static DamageFeedback instance;

    public static DamageFeedback Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void FireDamage(bool finished = false)
    {
        fireFeedback.enabled = !finished;
    }

    public void Damage(bool finished = false)
    {
        damageFeedback.enabled = !finished;
        if(!finished)
            damageSound.Play();
    }
}
