using System.Collections;
using UnityEngine;

public class PopUpController : SingletonMono<PopUpController>
{
    [SerializeField] private Sprite[] _virusSprites;
    [SerializeField] private Sprite[] _antivirusSprites;

    public Sprite[] VirusSprites => _virusSprites;
    public Sprite[] AntivirusSprites => _antivirusSprites;

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
            targetMonitor.PopUpObject.SetActive(true);

            Vector3 randomPos = new Vector3(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f), 0f);
            targetMonitor.PopUpObject.transform.localPosition = randomPos;
        }
    }

    private IEnumerator SpawnCooldown()
    {
        _canSpawn = false;

        yield return new WaitForSeconds(Random.Range(0, 6));

        SpawnPopUp();

        _canSpawn = true;
    }
}