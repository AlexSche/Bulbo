using UnityEngine;

public class LevelUpVFX : MonoBehaviour
{
    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] PlayerControllerChannel playerControllerChannel;

    void Start() {
        particleSystem = GetComponent<ParticleSystem>();
        playerControllerChannel.levelChanged += playLevelUpVFX;
    }

    void playLevelUpVFX() {
        particleSystem.Play();
    }
}
