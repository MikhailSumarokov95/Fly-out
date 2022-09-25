using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToxicFamilyGames.MenuEditor;

public class CreateManager : MonoBehaviour, IShoper
{
    [SerializeField] private Transform carSpawnPoint;
    [SerializeField] private GameObject characterSkin;
    private GameObject _carSkin;

    public void CreateCar() => 
        Instantiate(_carSkin, carSpawnPoint.position, _carSkin.transform.rotation);

    public void CreateCharacter(Vector3 positionSpawn, Quaternion rotationSpawn) => 
        Instantiate(characterSkin, positionSpawn, rotationSpawn);

    public void OnSelect(GameObject carSkin) => _carSkin = carSkin;
}
