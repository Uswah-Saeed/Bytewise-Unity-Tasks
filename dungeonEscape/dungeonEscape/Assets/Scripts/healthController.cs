using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class healthController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem = default;
    [SerializeField]
    GameObject player;
    public Slider slider;
    // public Slider slider;
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (slider.value == 0)
        {
            particleSystem.Play();
            Destroy(player.transform, 1.5f);
            SceneManager.LoadScene(1);
        }
    }
}
