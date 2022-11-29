using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public class sendorbit : MonoBehaviour
    {
        [SerializeField] private FusionBodyTransformCalculator _fusionBodyTransformCalculator;
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        [SerializeField] FusionWeightController _fusionWeightController;
        [SerializeField] NetworkDiscoveryStarter _networkDiscoveryStarter;
        //[SerializeField] question_agency _question_Agency;
        [SerializeField] GameObject _righthand;
        [SerializeField] GameObject _lefthand;
        SheetsService service;
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        string spreadsheetId_dynamic_host = "1s23ZbKWtfIhoTN9Vpak6iBLHlKjsAR8sifABhT3402U";
        string spreadsheetId_dynamic_client = "1cGI3ZxQkG1xpq72gaMfGb5XdvgLjgN96LQmdpNYH5OA";
        string spreadsheetId_constant_host = "1aYbpLL6ODz8vxw4MKWHqcs1CAf70iy9KqFastY4i1_w";
        string spreadsheetId_constant_client = "1aYbpLL6ODz8vxw4MKWHqcs1CAf70iy9KqFastY4i1_w";
        public string spreadsheetId;
        string sheetName = "data";
        private bool sending = false;
        private float _time = 0;

        List<IList<object>> _orbital = new List<IList<object>>();

        // Use this for initialization
        void Start()
        {
            service = OpenSheet();
        }

        // Update is called once per frame
        void Update()
        {
            if (_fusionBodyTransformCalculator.connectionjudge)
            {
                _time += Time.deltaTime;
            }
            if (_networkDiscoveryStarter.opponent && _fusionWeightController.Experimental_Condition.ToString() == "Dynamic")
            {
                spreadsheetId = spreadsheetId_dynamic_host;
            }
            else if (!_networkDiscoveryStarter.opponent && _fusionWeightController.Experimental_Condition.ToString() == "Dynamic")
            {
                spreadsheetId = spreadsheetId_dynamic_client;
            }
            else if (_networkDiscoveryStarter.opponent && _fusionWeightController.Experimental_Condition.ToString() == "Constant")
            {
                spreadsheetId = spreadsheetId_constant_host;
            }
            else if (!_networkDiscoveryStarter.opponent && _fusionWeightController.Experimental_Condition.ToString() == "Constant")
            {
                spreadsheetId = spreadsheetId_constant_client;
            }
            //sheetName = "stage" + _question_Agency.stage.ToString();

            if (_collision_Judgemnt.start_game)
            {
                sending = true;
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string dts = dt.ToString("HH:mm:ss");
                _orbital.Add(new List<object>(){dts,_time,_collision_Judgemnt.collisionnumber, _righthand.transform.position.x, _righthand.transform.position.y, _righthand.transform.position.z, _righthand.transform.rotation.x, _righthand.transform.rotation.y, _righthand.transform.rotation.z, _righthand.transform.rotation.w, _lefthand.transform.position.x, _lefthand.transform.position.y, _lefthand.transform.position.z, _lefthand.transform.rotation.x, _lefthand.transform.rotation.y, _lefthand.transform.rotation.z, _lefthand.transform.rotation.w });

            }
            else if(sending){
                sending = false;
                Invoke("send_data",2.0f);
            }

        }
        void send_data(){
            writeSheet();
            _orbital = new List<IList<object>>();
        }

        //****************************************************************
        //Scopeで読み取りのみ、読み書きなど指定する。
        //scopeを変更したら、credentialsしなおすため、
        // ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        //をいったん削除して再度認証プロセスを通すこと
        //****************************************************************


        //****************************************************************
        //Main - 10秒毎に追加する。終了するときはCtl-Cで。
        //****************************************************************
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
        private void ReadWrite(SheetsService service)
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
            wRange = string.Format("{0}!A{1}:Q{2}", sheetName, rowNumber,rowNumber + _orbital.Count - 1);  //行を追加
            ValueRange valueRange = new ValueRange();
            valueRange.Range = wRange;
            valueRange.MajorDimension = "ROWS";
            valueRange.Values = _orbital;
            var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, wRange);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var uUVR = updateRequest.Execute();
        }

    }
}