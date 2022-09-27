using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToxicFamilyGames.MenuEditor;
using UnityEngine.Events;

public class CreateManager : MonoBehaviour, IShoper
{
    public UnityEvent<GameObject> onCreateCar;
    public UnityEvent<GameObject> onCreateCharacter;
    [SerializeField] private Transform carSpawnPoint;
    [SerializeField] private GameObject characterSkin;
    private GameObject _carSkin;
    private GameObject _car;
    private GameObject _character;

    public void CreateCar()
    {
        if (_car != null) Destroy(_car);
        _car = Instantiate(_carSkin, carSpawnPoint.position, _carSkin.transform.rotation);
        onCreateCar?.Invoke(_car);
    }


    public void CreateCharacter(Vector3 positionSpawn, Quaternion rotationSpawn)
    {
        _character = Instantiate(characterSkin, positionSpawn, rotationSpawn);
        onCreateCharacter?.Invoke(_character);
    }

    public void DestroyCharacter() => Destroy(_character);

    public void OnSelect(GameObject carSkin) => _carSkin = carSkin;
}
