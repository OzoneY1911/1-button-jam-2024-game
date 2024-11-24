using System.Collections;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    [SerializeField] private Transform[] _screens;
    [SerializeField] private GameObject[] _popUps;

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
        if (!targetScreen.parent.GetComponent<Monitor>().HasPopUp)
        {
            GameObject popUp = Instantiate(_popUps[0], targetScreen);

            Vector3 randomPos = new Vector3(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f), 0f);
            popUp.transform.localPosition = randomPos;

            targetScreen.parent.GetComponent<Monitor>().HasPopUp = true;
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