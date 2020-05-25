using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpAnim : MonoBehaviour
{
    [SerializeField] private ParticleSystem effect1, effect2;
    public bool test = false;
    void Start()
    {
        PlayerStatus.OnLevelUp += ActivateLevelUpAnimation;
    }

    void Update()
    {
        if (test)
        {
            ActivateLevelUpAnimation();
            test = false;
        }
    }

    public void ActivateLevelUpAnimation()
    {
        effect1.Play();
        effect2.Play();
    }

    private void OnDestroy()
    {
        PlayerStatus.OnLevelUp -= ActivateLevelUpAnimation;
    }
}
