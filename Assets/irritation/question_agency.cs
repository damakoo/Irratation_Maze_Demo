using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System;


namespace CoEmbodimentSystem
{
    public class question_agency : MonoBehaviour
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        
        string sheetName = "survey";
        string spreadsheetId;

        [SerializeField] FusionWeightController _fusionWeightController;
        [SerializeField] NetworkDiscoveryStarter _networkDiscoveryStarter;
        [SerializeField] GameObject _question;
        [SerializeField] GameObject _answer;
        [SerializeField] GameObject _no;
        [SerializeField] GameObject _completely;
        [SerializeField] GameObject _one;
        [SerializeField] GameObject _two;
        [SerializeField] GameObject _three;
        [SerializeField] GameObject _four;
        [SerializeField] GameObject _five;
        [SerializeField] GameObject _six;
        [SerializeField] GameObject _seven;
        [SerializeField] sendorbit _sendorbit;
        SheetsService service;

        
        string Host;

        public bool survey = false;
        public bool survey_finish = false;
        private int choose = 4;
        Vector3 _default;
        public int stage = 1;

        List<object> _agency = new List<object>();
        private bool sending = false;

        // Start is called before the first frame update
        void Start()
        {
            _default = _one.GetComponent<RectTransform>().localScale;
            _question.SetActive(false);
            _answer.SetActive(false);
            _no.SetActive(false);
            _completely.SetActive(false);
            _one.SetActive(false);
            _two.SetActive(false);
            _three.SetActive(false);
            _four.SetActive(false);
            _five.SetActive(false);
            _six.SetActive(false);
            _seven.SetActive(false);

            service = OpenSheet();

        }

        // Update is called once per frame
        void Update()
        {            

            if (survey)
            {
                survey = false;
                choose = 4;
                _question.SetActive(true);
                _answer.SetActive(true);
                _no.SetActive(true);
                _completely.SetActive(true);
                _one.SetActive(true);
                _two.SetActive(true);
                _three.SetActive(true);
                _four.SetActive(true);
                _five.SetActive(true);
                _six.SetActive(true);
                _seven.SetActive(true);
            }



            if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
            {
                if (choose < 7)
                {
                    choose += 1;
                }
            }
            if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
            {
                if (choose > 1)
                {
                    choose -= 1;
                }
            }
            if (OVRInput.GetDown(OVRInput.Button.One) && _question.activeSelf)
            {
                spreadsheetId = _sendorbit.spreadsheetId;
                _agency.Add(choose);
                survey_finish = true;
                _question.SetActive(false);
                _answer.SetActive(false);
                _no.SetActive(false);
                _completely.SetActive(false);
                _one.SetActive(false);
                _two.SetActive(false);
                _three.SetActive(false);
                _four.SetActive(false);
                _five.SetActive(false);
                _six.SetActive(false);
                _seven.SetActive(false);
                stage += 1;
            }
            if(stage == 6 && !sending){
                sending = true;
                writeSheet();
            }



            if (choose == 1)
            {
                _one.GetComponent<Text>().color = UnityEngine.Color.red;
                _one.GetComponent<RectTransform>().localScale = _default + new Vector3(0.0001f, 0.0001f, 0.0001f);
                _two.GetComponent<Text>().color = UnityEngine.Color.black;
                _two.GetComponent<RectTransform>().localScale = _default;
                _three.GetComponent<Text>().color = UnityEngine.Color.black;
                _three.GetComponent<RectTransform>().localScale = _default;
                _four.GetComponent<Text>().color = UnityEngine.Color.black;
                _four.GetComponent<RectTransform>().localScale = _default;
                _five.GetComponent<Text>().color = UnityEngine.Color.black;
                _five.GetComponent<RectTransform>().localScale = _default;
                _six.GetComponent<Text>().color = UnityEngine.Color.black;
                _six.GetComponent<RectTransform>().localScale = _default;
                _seven.GetComponent<Text>().color = UnityEngine.Color.black;
                _seven.GetComponent<RectTransform>().localScale = _default;
            }
            else if (choose == 2)
            {
                _one.GetComponent<Text>().color = UnityEngine.Color.black;
                _one.GetComponent<RectTransform>().localScale = _default;
                _two.GetComponent<Text>().color = UnityEngine.Color.red;
                _two.GetComponent<RectTransform>().localScale = _default + new Vector3(0.0001f, 0.0001f, 0.0001f);
                _three.GetComponent<Text>().color = UnityEngine.Color.black;
                _three.GetComponent<RectTransform>().localScale = _default;
                _four.GetComponent<Text>().color = UnityEngine.Color.black;
                _four.GetComponent<RectTransform>().localScale = _default;
                _five.GetComponent<Text>().color = UnityEngine.Color.black;
                _five.GetComponent<RectTransform>().localScale = _default;
                _six.GetComponent<Text>().color = UnityEngine.Color.black;
                _six.GetComponent<RectTransform>().localScale = _default;
                _seven.GetComponent<Text>().color = UnityEngine.Color.black;
                _seven.GetComponent<RectTransform>().localScale = _default;
            }
            else if (choose == 3)
            {
                _one.GetComponent<Text>().color = UnityEngine.Color.black;
                _one.GetComponent<RectTransform>().localScale = _default;
                _two.GetComponent<Text>().color = UnityEngine.Color.black;
                _two.GetComponent<RectTransform>().localScale = _default;
                _three.GetComponent<Text>().color = UnityEngine.Color.red;
                _three.GetComponent<RectTransform>().localScale = _default + new Vector3(0.0001f, 0.0001f, 0.0001f);
                _four.GetComponent<Text>().color = UnityEngine.Color.black;
                _four.GetComponent<RectTransform>().localScale = _default;
                _five.GetComponent<Text>().color = UnityEngine.Color.black;
                _five.GetComponent<RectTransform>().localScale = _default;
                _six.GetComponent<Text>().color = UnityEngine.Color.black;
                _six.GetComponent<RectTransform>().localScale = _default;
                _seven.GetComponent<Text>().color = UnityEngine.Color.black;
                _seven.GetComponent<RectTransform>().localScale = _default;
            }
            else if (choose == 4)
            {
                _one.GetComponent<Text>().color = UnityEngine.Color.black;
                _one.GetComponent<RectTransform>().localScale = _default;
                _two.GetComponent<Text>().color = UnityEngine.Color.black;
                _two.GetComponent<RectTransform>().localScale = _default;
                _three.GetComponent<Text>().color = UnityEngine.Color.black;
                _three.GetComponent<RectTransform>().localScale = _default;
                _four.GetComponent<Text>().color = UnityEngine.Color.red;
                _four.GetComponent<RectTransform>().localScale = _default + new Vector3(0.0001f, 0.0001f, 0.0001f);
                _five.GetComponent<Text>().color = UnityEngine.Color.black;
                _five.GetComponent<RectTransform>().localScale = _default;
                _six.GetComponent<Text>().color = UnityEngine.Color.black;
                _six.GetComponent<RectTransform>().localScale = _default;
                _seven.GetComponent<Text>().color = UnityEngine.Color.black;
                _seven.GetComponent<RectTransform>().localScale = _default;
            }
            else if (choose == 5)
            {
                _one.GetComponent<Text>().color = UnityEngine.Color.black;
                _one.GetComponent<RectTransform>().localScale = _default;
                _two.GetComponent<Text>().color = UnityEngine.Color.black;
                _two.GetComponent<RectTransform>().localScale = _default;
                _three.GetComponent<Text>().color = UnityEngine.Color.black;
                _three.GetComponent<RectTransform>().localScale = _default;
                _four.GetComponent<Text>().color = UnityEngine.Color.black;
                _four.GetComponent<RectTransform>().localScale = _default;
                _five.GetComponent<Text>().color = UnityEngine.Color.red;
                _five.GetComponent<RectTransform>().localScale = _default + new Vector3(0.0001f, 0.0001f, 0.0001f);
                _six.GetComponent<Text>().color = UnityEngine.Color.black;
                _six.GetComponent<RectTransform>().localScale = _default;
                _seven.GetComponent<Text>().color = UnityEngine.Color.black;
                _seven.GetComponent<RectTransform>().localScale = _default;
            }
            else if (choose == 6)
            {
                _one.GetComponent<Text>().color = UnityEngine.Color.black;
                _one.GetComponent<RectTransform>().localScale = _default;
                _two.GetComponent<Text>().color = UnityEngine.Color.black;
                _two.GetComponent<RectTransform>().localScale = _default;
                _three.GetComponent<Text>().color = UnityEngine.Color.black;
                _three.GetComponent<RectTransform>().localScale = _default;
                _four.GetComponent<Text>().color = UnityEngine.Color.black;
                _four.GetComponent<RectTransform>().localScale = _default;
                _five.GetComponent<Text>().color = UnityEngine.Color.black;
                _five.GetComponent<RectTransform>().localScale = _default;
                _six.GetComponent<Text>().color = UnityEngine.Color.red;
                _six.GetComponent<RectTransform>().localScale = _default + new Vector3(0.0001f, 0.0001f, 0.0001f);
                _seven.GetComponent<Text>().color = UnityEngine.Color.black;
                _seven.GetComponent<RectTransform>().localScale = _default;
            }
            else if (choose == 7)
            {
                _one.GetComponent<Text>().color = UnityEngine.Color.black;
                _one.GetComponent<RectTransform>().localScale = _default;
                _two.GetComponent<Text>().color = UnityEngine.Color.black;
                _two.GetComponent<RectTransform>().localScale = _default;
                _three.GetComponent<Text>().color = UnityEngine.Color.black;
                _three.GetComponent<RectTransform>().localScale = _default;
                _four.GetComponent<Text>().color = UnityEngine.Color.black;
                _four.GetComponent<RectTransform>().localScale = _default;
                _five.GetComponent<Text>().color = UnityEngine.Color.black;
                _five.GetComponent<RectTransform>().localScale = _default;
                _six.GetComponent<Text>().color = UnityEngine.Color.black;
                _six.GetComponent<RectTransform>().localScale = _default;
                _seven.GetComponent<Text>().color = UnityEngine.Color.red;
                _seven.GetComponent<RectTransform>().localScale = _default + new Vector3(0.0001f, 0.0001f, 0.0001f);
            }
        }
        void writeSheet()
        {
            ReadWrite(service);
        }

        //****************************************************************
        //OpenSheet() - 認証プロセスとAPI serviceの作成
        //****************************************************************
        static SheetsService OpenSheet()
        {
            GoogleCredential credential;
            //認証プロセス。credPathが作成されていないとBrowserが起動して認証ページが開くので認証を行って先に進む
            using (var stream = new FileStream(Application.streamingAssetsPath + "/alteredfestival-c107771445f8.json", FileMode.Open, FileAccess.Read))
            {
                //CredentialファイルがcredPathに保存される(ここのコードを以下のように修正)
                credential = GoogleCredential.FromStream(stream).CreateScoped(SheetsService.Scope.Spreadsheets);
            }
            //API serviceを作成、Requestパラメータを設定
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }

        //****************************************************************
        //OpenSheet() - 本当はAppendしたいんだが動かない(というかエントリがない)ので、
        // 1. 今あるデータを全部読み出す
        // 2. 行数を調べてその次の行にデータを書く
        //****************************************************************
        void ReadWrite(SheetsService service)
        {
            ValueRange rVR;
            string wRange;
            //データを読み出す
            int rowNumber = 1;
            wRange = string.Format("{0}!A{1}:B", sheetName, rowNumber); //行を全部読む
            SpreadsheetsResource.ValuesResource.GetRequest getRequest
                = service.Spreadsheets.Values.Get(spreadsheetId, wRange);
            rVR = getRequest.Execute();
            var values = rVR.Values;
            if (values != null && values.Count > 0) rowNumber = values.Count + 1;
            //空行に新たにデータを書き込む
            wRange = string.Format("{0}!A{1}:F{1}", sheetName, rowNumber);  //行を追加
            ValueRange valueRange = new ValueRange();
            valueRange.Range = wRange;
            valueRange.MajorDimension = "ROWS";
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string dts = dt.ToString("HH:mm:ss");
            _agency.Insert(0,dts);
            valueRange.Values = new List<IList<object>> { _agency };
            var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, wRange);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var uUVR = updateRequest.Execute();
        }

    }

}