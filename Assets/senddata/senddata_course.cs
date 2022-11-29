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
    public class senddata_course : MonoBehaviour
    {
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        [SerializeField] GameObject _righthand;
        [SerializeField] GameObject _lefthand;
        SheetsService service;
        public int course;
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        private string spreadsheetId;
        private string spreadsheetId1 = "1zT6WxN-KNgAPigdxpDvf0SbpAwTBXbTfdl6eZkyIBwU";
        private string spreadsheetId2 = "1FZcUUHRnbRwBhjiElVUc78W26nMW32HW4as95LqPEMI";
        private string spreadsheetId3 = "1hkrzTyekyAxqdBIMoi5QEXjEgoalrVhEV7WHa_703wE";
        private string spreadsheetId4 = "1guIeFDTBZ-a36TSv4ER8dF4kSWFvBjLR_MqbUb6qIb8";
        private string spreadsheetId5 = "1V1wlXhttD_ajtjCsYP15ofT7ZKL_HUBmeT0nKxafG1s";
        string sheetName = "data";
        private bool sending = false;
        

        List<IList<object>> _orbital = new List<IList<object>>();

        // Use this for initialization
        void Start()
        {
 
            if(course == 1)
            {
                spreadsheetId = spreadsheetId1;
            }
            else if (course == 2)
            {
                spreadsheetId = spreadsheetId2;
            }
            else if (course == 3)
            {
                spreadsheetId = spreadsheetId3;
            }
            else if (course == 4)
            {
                spreadsheetId = spreadsheetId4;
            }
            else if (course == 5)
            {
                spreadsheetId = spreadsheetId5;
            }
            service = OpenSheet();


        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //sheetName = "stage" + _question_Agency.stage.ToString();

            if (_collision_Judgemnt.start_game)
            {
                sending = true;
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string dts = dt.ToString("HH:mm:ss");
                _orbital.Add(new List<object>() { dts, _collision_Judgemnt.collisiontime, _collision_Judgemnt.collisionnumber, _righthand.transform.position.x, _righthand.transform.position.y, _righthand.transform.position.z, _righthand.transform.rotation.x, _righthand.transform.rotation.y, _righthand.transform.rotation.z, _righthand.transform.rotation.w, _lefthand.transform.position.x, _lefthand.transform.position.y, _lefthand.transform.position.z, _lefthand.transform.rotation.x, _lefthand.transform.rotation.y, _lefthand.transform.rotation.z, _lefthand.transform.rotation.w });

            }
            else if (sending)
            {
                sending = false;
                Invoke("send_data", 2.0f);
            }

        }
        void send_data()
        {
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
            wRange = string.Format("{0}!A{1}:Q{2}", sheetName, rowNumber, rowNumber + _orbital.Count - 1);  //行を追加
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