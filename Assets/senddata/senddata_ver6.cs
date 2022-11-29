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
    public class senddata_ver6 : MonoBehaviour
    {
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        [SerializeField] GameObject _righthand;
        [SerializeField] GameObject _lefthand;
        [SerializeField] solofusioncalculator _solofusioncalculator;
        SheetsService service;
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        private string spreadsheetId;
        private string spreadsheetId_full = "10MLYFbZ9PeNR9MnJ4B6YxUCCi1gJItVK-KPNsc7GKfE";
        private string spreadsheetId_static = "1Vr4jWXhglYRZ9dyTcFHmEwt0Pn4PEtDTnjGvNDs3Xhk";
        private string spreadsheetId_decreasing50 = "1DUNzlS5kfgJERFZNj4j6cNOQcFZEs2PRYKvC0pLq5KU";
        private string spreadsheetId_decreasing25 = "1lfXLCQbrJ_HM4SK8Wq849xUyHWpzbLKL6LtpX6L0lqc";
        private string spreadsheetId_decreasing75 = "1XapcM6kxi2uZytD2-yLtdGmt3IqbT2UVpCB4DGFD2WA";
        private string spreadsheetId_decreasing0 = "1NTD-3hmD3sY5RSM6fdhIj1wkyYTzxpZ5sdul1nZ47OU";
        private string spreadsheetId_static25 = "1gboKO1jS6yrIis2tXOso87GFI3SSbRITJ5kL_QXseTc";
        private string spreadsheetId_static75 = "12kjGaUUPxZ6NJJXBvX-4BnpuOusf0sE_hApXosw1sHo";
        private string spreadsheetId_static0 = "1s5orwCVfHhKfDabBfyu3BSAaj2e0828uvlzYPOubhbg";
        string sheetName = "data";
        private bool sending = false;


        List<IList<object>> _orbital = new List<IList<object>>();

        // Use this for initialization
        void Start()
        {

            if (_solofusioncalculator.Experimental_Condition.ToString() == "Full")
            {
                spreadsheetId = spreadsheetId_full;
            }
            else if (_solofusioncalculator.Experimental_Condition.ToString() == "Static")
            {
                spreadsheetId = spreadsheetId_static;
            }
            else if (_solofusioncalculator.Experimental_Condition.ToString() == "Decreasing50")
            {
                spreadsheetId = spreadsheetId_decreasing50;
            }
            else if (_solofusioncalculator.Experimental_Condition.ToString() == "Decreasing25")
            {
                spreadsheetId = spreadsheetId_decreasing25;
            }
            else if (_solofusioncalculator.Experimental_Condition.ToString() == "Decreasing75")
            {
                spreadsheetId = spreadsheetId_decreasing75;
            }
            else if (_solofusioncalculator.Experimental_Condition.ToString() == "Decreasing0")
            {
                spreadsheetId = spreadsheetId_decreasing0;
            }
            else if (_solofusioncalculator.Experimental_Condition.ToString() == "Static25")
            {
                spreadsheetId = spreadsheetId_static25;
            }
            else if (_solofusioncalculator.Experimental_Condition.ToString() == "Static75")
            {
                spreadsheetId = spreadsheetId_static75;
            }
            else if (_solofusioncalculator.Experimental_Condition.ToString() == "Nothing")
            {
                spreadsheetId = spreadsheetId_static0;
            }
            else
            {
                this.GetComponent<senddata_ver6>().enabled = false;
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
                _orbital.Add(new List<object>() { dts,_solofusioncalculator.fusionrate,_solofusioncalculator.howmanypush,_solofusioncalculator.howlongpush, _collision_Judgemnt.collisiontime, _collision_Judgemnt.collisionnumber, _righthand.transform.position.x, _righthand.transform.position.y, _righthand.transform.position.z, _righthand.transform.rotation.x, _righthand.transform.rotation.y, _righthand.transform.rotation.z, _righthand.transform.rotation.w, _lefthand.transform.position.x, _lefthand.transform.position.y, _lefthand.transform.position.z, _lefthand.transform.rotation.x, _lefthand.transform.rotation.y, _lefthand.transform.rotation.z, _lefthand.transform.rotation.w });

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
            wRange = string.Format("{0}!A{1}:T{2}", sheetName, rowNumber, rowNumber + _orbital.Count - 1);  //行を追加
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