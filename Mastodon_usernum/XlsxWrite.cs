//-----------------------------------------------------------------------
// <copyright file="XlsxWrite.cs" company="dc1394's software">
//     Copyright ©  2017 @dc1394 All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mastodon_usernum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ClosedXML.Excel;
    
    internal sealed class XlsxWrite
    {
        #region フィールド

        /// <summary>
        /// xlsxファイルのファイル名
        /// </summary>
        private static readonly String XLSXFILENAME = "Mastodonの各インスタンスにおけるユーザー数の推移.xlsx";

        /// <summary>
        /// インスタンス名をキー、Mastodonのデータを値としたDictionary
        /// </summary>
        private Dictionary<String, List<MastodonData>> jsondata;

        #endregion フィールド

        #region 構築

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="jsondata">インスタンス名をキー、Mastodonのデータを値としたDictionary</param>
        internal XlsxWrite(Dictionary<String, List<MastodonData>> jsondata)
        {
            // jsonデータをコピー
            this.jsondata = jsondata;
        }

        #endregion 構築

        #region メソッド

        /// <summary>
        /// xlsxファイルに書き込む
        /// </summary>
        internal void WriteXlsx()
        {
            // Wookbookを生成
            var wbook = new XLWorkbook(XlsxWrite.XLSXFILENAME);

            jsondata.ToList()
                    .ForEach(jsonpair =>
                    {
                        // 記入するシート
                        var wsheet = wbook.Worksheet(jsonpair.Key);

                        jsonpair.Value
                                .Select((v, i) => (value: v, index: i + 1))
                                .ForEach(item =>
                                {
                                    var localtime = DateTimeOffset.FromUnixTimeSeconds(item.value.date).ToLocalTime();
                                    wsheet.Cell(item.index, 1).Value = localtime.DateTime.ToString("yyyy/M/dd H:m");
                                    wsheet.Cell(item.index, 2).Value = item.value.users;
                                });
                    });

            wbook.Save();
        }

        #endregion メソッド
    }
}
