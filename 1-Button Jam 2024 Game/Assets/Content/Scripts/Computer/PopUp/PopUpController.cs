using System.Collections;
using UnityEngine;

public class PopUpController : SingletonMono<PopUpController>
{
    [SerializeField] private Sprite[] _virusSprites;
    [SerializeField] private Sprite[] _antiVirusSprites;

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
            targetMonitor.PopUpScript.Emerge(_virusSprites, _antiVirusSprites);
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