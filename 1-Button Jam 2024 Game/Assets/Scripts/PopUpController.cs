using System.Collections;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    [SerializeField] private Transform[] _screens;
    [SerializeField] private Sprite[] _virusSprites;
    [SerializeField] private Sprite[] _antiVirusSprites;

    private bool _canSpawn = true;

    private void Update()
    {
        if (_canSpawn)
        {
            StartCoroutine(SpawnCooldown());
        }
    }

    private void SpawnPopUp()
    {
        Transform targetScreen = _screens[Random.Range(0, _screens.Length)];
        Monitor targetMonitor = targetScreen.parent.GetComponent<Monitor>();
        if (!targetMonitor.HasPopUp)
        {
            targetMonitor.PopUp.SetActive(true);

            Vector3 randomPos = new Vector3(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f), 0f);
            targetMonitor.PopUp.transform.localPosition = randomPos;

            targetMonitor.HasPopUp = true;
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