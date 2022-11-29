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
    public class modelmove : MonoBehaviour
    {
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        [SerializeField] Transform realpos;
        SheetsService service;
        public int course;
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private string spreadsheetId = "18T-vZJ3P_TxPQd054YUjxgYKAWNzfSah8c9v7p9szo4";
        private string spreadsheetId1 = "18T-vZJ3P_TxPQd054YUjxgYKAWNzfSah8c9v7p9szo4";
        private string spreadsheetId2 = "1T8n2AbSOlJTM7luMGlHMPWKIclPfCr5yocjdGpdC7Mo";
        private string spreadsheetId3 = "1w89kdzO66aeBfSamlU-PJOE82wjVVM_S_3tzagksooU";
        private string spreadsheetId4 = "1scVul4eeI6TS0RImIDjeCLQLFj2ZqmasskISSCCMU3I";
        private string spreadsheetId5 = "1r4XyUXGNCNUhYXmf_l0Yu4swyXUEUH6L_Bh5pqZC_MM";
        private string spreadsheetId6 = "1I1R_VtW55ScL9x5YZWcSSMqfDsSWHoZUezV2h-OGNZw";
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        string sheetName = "data";
        List<Vector3> modelpos = new List<Vector3>();
        List<Quaternion> modelrot = new List<Quaternion>();
        int pos_number = 0;
        public int fusionlength = 0;



        List<IList<object>> _orbital = new List<IList<object>>();

        // Use this for initialization
        void Start()
        {
            if (course == 1)
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
            }else if(course == 6)
            {
                spreadsheetId = spreadsheetId6;
            }
            service = OpenSheet();
            ReadWrite(service);
            //Debug.Log(modelpos[0]);
            //Debug.Log(modelpos.Count);
            fusionlength = modelpos.Count;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_collision_Judgemnt.readyforgame_me)
            {
                if (pos_number < modelpos.Count)
                {
                    this.transform.position = modelpos[pos_number];
                    this.transform.rotation = modelrot[pos_number];
                    pos_number += 1;
                }
                else
                {
                    this.transform.position = realpos.position;
                    this.transform.rotation = realpos.rotation; 
                }
            }
            else
            {
                this.transform.position = realpos.position;
                this.transform.rotation = realpos.rotation;
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
            int rowNumber = 2;

            wRange = string.Format("{0}!A{1}:G", sheetName, rowNumber); //行を全部読む
            SpreadsheetsResource.ValuesResource.GetRequest getRequest
                = service.Spreadsheets.Values.Get(spreadsheetId, wRange);
            rVR = getRequest.Execute();
            for(int i = 0;i < rVR.Values.Count; i++)
            {
                modelpos.Add(new Vector3(System.Convert.ToSingle(rVR.Values[i][0]), System.Convert.ToSingle(rVR.Values[i][1]), System.Convert.ToSingle(rVR.Values[i][2])));
                modelrot.Add(new Quaternion(System.Convert.ToSingle(rVR.Values[i][3]), System.Convert.ToSingle(rVR.Values[i][4]), System.Convert.ToSingle(rVR.Values[i][5]), System.Convert.ToSingle(rVR.Values[i][6])));
            }


            /*var values = rVR.Values;
            if (values != null && values.Count > 0) rowNumber = values.Count + 1;
            //空行に新たにデータを書き込む
            wRange = string.Format("{0}!A{1}:Q{2}", sheetName, rowNumber, rowNumber + _orbital.Count - 1);  //行を追加
            ValueRange valueRange = new ValueRange();
            valueRange.Range = wRange;
            valueRange.MajorDimension = "ROWS";
            valueRange.Values = _orbital;
            var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, wRange);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var uUVR = updateRequest.Execute();*/
        }

    }
}