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
    [SerializeField] private Vector3 offsetSpawnCharacter = new Vector3(0, 0, 4f);
    private GameObject _carSkin;
    private GameObject _car;
    private GameObject _character;

    public void CreateCar()
    {
        if (_car != null) Destroy(_car);
        _car = Instantiate(_carSkin, carSpawnPoint.position, _carSkin.transform.rotation);
        onCreateCar?.Invoke(_car);
    } 

    public void CreateCharacter(float powerForce, float angleForce)
    {
        _character = Instantiate(characterSkin, _car.transform.position + offsetSpawnCharacter, characterSkin.transform.rotation);
        var chatacterCh = _character.GetComponent<CharacterPlayer>();
        chatacterCh.PowerStartForce = powerForce;
        chatacterCh.AngleStartForce = angleForce;
        chatacterCh.AngleTurnCarY = _car.transform.eulerAngles.y;
        onCreateCharacter?.Invoke(_character);
    }
    
    public void DestroyCharacter() => Destroy(_character);

    public void OnSelect(GameObject carSkin) => _carSkin = carSkin;
}
