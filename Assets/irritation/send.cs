﻿using System.Collections;
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

public class send : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        writeSheet();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //****************************************************************
    //Scopeで読み取りのみ、読み書きなど指定する。
    //scopeを変更したら、credentialsしなおすため、
    // ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
    //をいったん削除して再度認証プロセスを通すこと
    //****************************************************************
    static string[] Scopes = { SheetsService.Scope.Spreadsheets };
    static string ApplicationName = "Google Sheets API .NET Quickstart";
    static string spreadsheetId = "1le8PpPgiCwwqFLXqLwuVPY--FrcRiFE7frH1XROUxwU";
    static string sheetName = "alteredfestival";

    //****************************************************************
    //Main - 10秒毎に追加する。終了するときはCtl-Cで。
    //****************************************************************
    void writeSheet()
    {
        var service = OpenSheet();
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
    static void ReadWrite(SheetsService service)
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
        wRange = string.Format("{0}!A{1}:B{1}", sheetName, rowNumber);  //行を追加
        ValueRange valueRange = new ValueRange();
        valueRange.Range = wRange;
        valueRange.MajorDimension = "ROWS";
        DateTime dt = new DateTime();
        dt = DateTime.Now;
        string dts = dt.ToString("HH:mm:ss");
        var oblist = new List<object>() { string.Format("{0}", rowNumber), dts};
        valueRange.Values = new List<IList<object>> { oblist };
        var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, wRange);
        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        var uUVR = updateRequest.Execute();
    }
}