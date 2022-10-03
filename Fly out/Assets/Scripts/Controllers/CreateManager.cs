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
    private List<GameObject> _character;

    private void Start()
    {
        _character = new List<GameObject>();
    }

    public void CreateCar()
    {
        if (_car != null) Destroy(_car);
        _car = Instantiate(_carSkin, carSpawnPoint.position, _carSkin.transform.rotation);
        onCreateCar?.Invoke(_car);
    } 

    public void CreateCharacter(float powerForce, float angleForce)
    {
        _character.Add(Instantiate(characterSkin, _car.transform.position + offsetSpawnCharacter, characterSkin.transform.rotation));
        var chatacterCh = _character[_character.Count - 1].GetComponent<CharacterPlayer>();
        chatacterCh.PowerStartForce = powerForce;
        chatacterCh.AngleStartForce = angleForce;
        chatacterCh.AngleTurnCarY = _car.transform.eulerAngles.y;
        onCreateCharacter?.Invoke(_character[_character.Count - 1]);
    }

    public void DestroyCharacters()
    {
        for (int i = 0; i < _character.Count; i++)
        {
            Destroy(_character[i]);
        }
        _character.Clear();
    }

    public void OnSelect(GameObject carSkin) => _carSkin = carSkin;
}
