using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ToxicFamilyGames.MenuEditor;
using System.IO;
using System.Text;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text[] namesGamersTable;
    [SerializeField] private TMP_Text[] resultsGamersTable;
    private List<string> _namesGamers;
    private LanguageController _languageController;

    private void Start()
    {
        _languageController = FindObjectOfType<LanguageController>();
    }

    public void StartLeaderBoard()
    {
        var namesOpponents = new string[9];
        var language = _languageController.SelectedLanguage;
        var playerNames =  GetPlayerNames(language);
        for (int i = 0; i < 9; i++)
        {
            namesOpponents[i] = playerNames[Random.Range(0, playerNames.Length)];
        }
        foreach (string name in namesOpponents)
        {
            print(name);
        }
    }

    public string[] GetPlayerNames(string language)
    {
        string names;
        var filePath = Application.dataPath + "/Resources/NameGamers.json";
        var playerNames = JsonUtility.FromJson<PlayerNames>(File.ReadAllText(filePath));
        switch (language)
        {
            case "ru":
                names = playerNames.ru;
                break;
            case "en":
                names = playerNames.en;
                break;
            case "tr":
                names = playerNames.tr;
                break;
            default:
                names = playerNames.en;
                break;
        }
        return ParceName(names);
    }

    private string[] ParceName(string names)
    {
        var playerNames = new List<string>();
        StringBuilder name = new StringBuilder();
        for (int i = 0; i < names.Length; i++)
        {
            if (char.IsLetter(names[i]))
            {
                name.Append(names[i]);
            }
            else
            {
                if (name.Length != 0)
                {
                    playerNames.Add(name.ToString());
                    name.Clear();
                }
            }
        }
        return playerNames.ToArray();
    }

    [System.Serializable]
    public class PlayerNames
    {
        public string ru;
        public string en;
        public string tr;
    }

    //public void SaveToJson()
    //{
    //    var nameG = new NameGamers { ru = "Александра\r\nАлина\r\nАлла\r\nАнастасия\r\nАнжела\r\nАнна\r\nАнтонина\r\nВалентина\r\nВалерия\r\nВероника\r\nВиктория\r\nГалина\r\nДарья\r\nАлександр\r\nАлексей\r\nАнатолий\r\nАндрей\r\nАнтон\r\nАркадий\r\nАртем\r\nБорислав\r\nВадим\r\nВалентин\r\nВалерий\r\nВасилий\r\nВиктор\r\nВиталий\r\nВладимир\r\nВячеслав\r\nГеннадий\r\nГеоргий\r\nГригорий\r\nДаниил\r\nДенис\r\nДмитpий\r\nЕвгений\r\nЕгор\r\nИван\r\nИгорь\r\nИлья\r\nКирилл\r\nЛев\r\nМаксим\r\nМихаил\r\nНикита\r\nНиколай\r\nОлег\r\nСемен\r\nСергей\r\nСтанислав\r\nСтепан\r\nФедор\r\nЮрий",  en = "Liam\r\nNoah\r\nOliver\r\nElijah\r\nJames\r\nWilliam\r\nBenjamin\r\nLucas\r\nHenry\r\nTheodore\r\nJack\r\nLevi\r\nAlexander\r\nJackson\r\nMateo\r\nDaniel\r\nMichael\r\nMason\r\nSebastian\r\nEthan\r\nLogan\r\nOwen\r\nSamuel\r\nJacob\r\nAsher\r\nAiden\r\nJohn\r\nJoseph\r\nWyatt\r\nDavid\r\nLeo\r\nLuke\r\nJulian\r\nHudson\r\nGrayson\r\nMatthew\r\nEzra\r\nGabriel\r\nCarter\r\nIsaac\r\nJayden\r\nLuca\r\nAnthony\r\nDylan\r\nLincoln\r\nThomas\r\nMaverick\r\nElias\r\nJosiah\r\nCharles\r\nCaleb\r\nChristopher\r\nEzekiel\r\nMiles\r\nJaxon\r\nIsaiah\r\nAndrew\r\nJoshua\r\nNathan\r\nNolan\r\nAdrian\r\nCameron\r\nSantiago\r\nEli\r\nAaron\r\nRyan\r\nAngel\r\nCooper\r\nWaylon\r\nEaston\r\nKai\r\nChristian\r\nLandon\r\nColton\r\nRoman\r\nAxel\r\nBrooks\r\nJonathan\r\nRobert\r\nJameson\r\nIan\r\nEverett\r\nGreyson\r\nWesley\r\nJeremiah\r\nHunter\r\nLeonardo\r\nJordan\r\nJose\r\nBennett\r\nSilas\r\nNicholas\r\nParker\r\nBeau\r\nWeston\r\nAustin\r\nConnor\r\nCarson\r\nDominic\r\nXavier\r\nJaxson\r\nJace\r\nEmmett\r\nAdam\r\nDeclan\r\nRowan\r\nMicah\r\nKayden\r\nGael\r\nRiver\r\nRyder\r\nKingston\r\nDamian\r\nSawyer\r\nLuka\r\nEvan\r\nVincent\r\nLegend\r\nMyles\r\nHarrison\r\nAugust\r\nBryson\r\nAmir\r\nGiovanni\r\nChase\r\nDiego\r\nMilo\r\nJasper\r\nWalker\r\nJason\r\nBrayden\r\nCole\r\nNathaniel\r\nGeorge\r\nLorenzo\r\nZion\r\nLuis\r\nArcher\r\nEnzo\r\nJonah\r\nThiago\r\nTheo\r\nAyden\r\nZachary\r\nCalvin\r\nBraxton\r\nAshton\r\nRhett\r\nAtlas\r\nJude\r\nBentley\r\nCarlos\r\nRyker\r\nAdriel\r\nArthur\r\nAce\r\nTyler\r\nJayce\r\nMax\r\nElliot\r\nGraham\r\nKaiden\r\nMaxwell\r\nJuan\r\nDean\r\nMatteo\r\nMalachi\r\nIvan\r\nElliott\r\nJesus\r\nEmiliano\r\nMessiah\r\nGavin\r\nMaddox\r\nCamden\r\nHayden\r\nLeon\r\nAntonio\r\nJustin\r\nTucker\r\nBrandon\r\nKevin\r\nJudah\r\nFinn\r\nKing\r\nBrody\r\nXander\r\nNicolas\r\nCharlie\r\nArlo\r\nEmmanuel\r\nBarrett\r\nFelix\r\nAlex\r\nMiguel\r\nAbel\r\nAlan\r\nBeckett\r\nAmari\r\nKarter\r\nTimothy\r\nAbraham", tr = "Abay\r\nAçelya\r\nAda\r\nAdam\r\nAdile\r\nAhenk\r\nAhu\r\nAhunaz\r\nAjda\r\nAjlan\r\nAkasya\r\nAkay\r\nAkbahar\r\nAkbaran\r\nAybel\r\nAyben\r\nAybeniz\r\nAybike\r\nAybüke\r\nAycan\r\nAyça\r\nAyçiçek\r\nAyçin\r\nAyda\r\nAydan\r\nAydınlık\r\nAydilek\r\nAydinç\r\nAydoğan\r\nİlkgül\r\nİlkim\r\nİlkin\r\nİlkiz\r\nİlknur\r\nİlköz\r\nİlkutlu\r\nİlkyaz\r\nİlter\r\nİmge\r\nİmren\r\nİnci\r\nİncigül\r\nİncilay\r\nİpek\r\nİrem\r\nİris\r\nİsmigül\r\nİyimser\r\nİzel\r\nİzem\r\nİzgi\r\nJale\r\nJalenur\r\nJanset\r\nJerfi\r\nJülide\r\nKader\r\nKadriye\r\nKamelya\r\nKanat\r\nKaraca\r\nKaranfil\r\nKardelen\r\nKayan\r\nKaynak\r\nKayra\r\nKelebek\r\nKerime\r\nKevser\r\nKezban\r\nKısmet\r\nKıvanç\r\nKıvılcım\r\nKıymet" };
    //    string filePath = Application.dataPath + "/Resources/NameGamers.json";
    //    var names = JsonUtility.ToJson(nameG);
    //    print(names);
    //    File.WriteAllText(filePath, names);
    //}
}
