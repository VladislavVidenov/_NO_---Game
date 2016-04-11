using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private string backGroundMusicName;

    private string path = "event:/";
    private string ambient;
    private EventInstance backGroundMusic;

    private float sfxVolume;
    private float musicVolume;

    private void Start() {
        sfxVolume = Assets.AudioVolumeManager.Sfx;
        musicVolume = Assets.AudioVolumeManager.Music;
        ambient = path + "Ambient" + backGroundMusicName;
        backGroundMusicName = path + backGroundMusicName;
        backGroundMusic = FMOD_StudioSystem.instance.GetEvent(backGroundMusicName);
        if (backGroundMusic!=null)backGroundMusic.setVolume(musicVolume);
        StartBackGroundMusic();
    }

    private void OnDestroy() {
        StopBackGroundMusic();
    }

    

    public void StartBackGroundMusic(){
        if (backGroundMusicName != null) backGroundMusic.start();
    }

    public void StopBackGroundMusic() {
        if (backGroundMusicName != null) backGroundMusic.stop(STOP_MODE.ALLOWFADEOUT);
    }

    public void playSFX(string sfxName, float x = 0, float y = 0, float z = 900000000){
        Vector3 pos = z == 900000000 ? transform.position : new Vector3(x, y, z);
        FMOD_StudioSystem.instance.PlayOneShot(path + sfxName, pos ,sfxVolume);
    }

    public void playMusic(AudioToCall data) {
        EventInstance audio = FMOD_StudioSystem.instance.GetEvent(data.eventName);
        if (data.parameterName != "") {
            ParameterInstance audioParameter;
            audio.getParameter(data.parameterName, out audioParameter);
            audioParameter.setValue(data.value);
        }
        audio.start();
    }

    public void updateVolumes(float music, float sfx) {
        musicVolume = music;
        sfxVolume = sfx;
        if (backGroundMusicName != null) backGroundMusic.setVolume(musicVolume);
        
    }

}