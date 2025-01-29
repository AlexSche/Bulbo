using UnityEngine;

public class LevelUpVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleLevelUp;
    [SerializeField] PlayerControllerChannel playerControllerChannel;

    void Awake() {
        particleLevelUp = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        playerControllerChannel.levelChanged += playLevelUpVFX;
    }

    public void playLevelUpVFX()
    {
        particleLevelUp = GetComponent<ParticleSystem>();
        if (particleLevelUp == null)
        {
            particleLevelUp.Play();
        } else {
            Debug.Log("WHY IS THIS NULL");
        }
    }
}
