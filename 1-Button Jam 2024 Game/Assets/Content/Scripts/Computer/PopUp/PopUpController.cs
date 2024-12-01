using System.Collections;
using UnityEngine;

public class PopUpController : SingletonMono<PopUpController>
{
    [SerializeField] private Sprite[] _defaultVSprites;
    [SerializeField] private Sprite[] _defaultAVSprites;
    [SerializeField] private Sprite[] _consoleVSprites;
    [SerializeField] private Sprite[] _consoleAVSprites;
    [SerializeField] private Sprite[] _abstractVSprites;
    [SerializeField] private Sprite[] _abstractAVSprites;
    [SerializeField] private Sprite[] _smileysVSprites;
    [SerializeField] private Sprite[] _smileysAVSprites;

    private Monitor[] _monitors => MonitorController.Instance.Monitors;
    private bool _canSpawn = true;

    private void FixedUpdate()
    {
        if (_canSpawn)
        {
            StartCoroutine(SpawnCooldown());
        }
    }

    private void SpawnPopUp()
    {
        Monitor targetMonitor = _monitors[Random.Range(0, _monitors.Length)];
        if (!targetMonitor.HasPopUp)
        {
            switch (targetMonitor.Type)
            {
                case MonitorType.Default:
                    targetMonitor.PopUpScript.Emerge(_defaultVSprites, _defaultAVSprites);
                    break;
                case MonitorType.Console:
                    targetMonitor.PopUpScript.Emerge(_consoleVSprites, _consoleAVSprites);
                    break;
                case MonitorType.Abstract:
                    targetMonitor.PopUpScript.Emerge(_abstractVSprites, _abstractAVSprites);
                    break;
                case MonitorType.Smileys:
                    targetMonitor.PopUpScript.Emerge(_smileysVSprites, _smileysAVSprites);
                    break;
            }
        }
    }

    private IEnumerator SpawnCooldown()
    {
        _canSpawn = false;

        yield return new WaitForSeconds(Random.Range(0.5f, 4.5f));

        SpawnPopUp();

        _canSpawn = true;
    }
}