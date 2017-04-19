//-----------------------------------------------------------------------
// <copyright file="DownloadJsonAndToList.cs" company="dc1394's software">
//     Copyright ©  2017 @dc1394 All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mastodon_usernum
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// JSONデータをダウンロードして、メモリ上（List）に保存するクラス
    /// </summary>
    internal sealed class DownloadJsonAndToList
    {
        #region フィールド

        /// <summary>
        /// JSONデータのダウンロード先のURL1
        /// </summary>
        private static readonly String GETJSONSTR1 = "https://instances.mastodon.xyz/api/instances/history.json?instance=";

        /// <summary>
        /// JSONデータのダウンロード先のURL2
        /// </summary>
        private static readonly String GETJSONSTR2 = "&start=0&end=";

        /// <summary>
        /// インスタンス名
        /// </summary>
        private String instancename;

        /// <summary>
        /// JSONデータを格納した文字列
        /// </summary>
        private String jsonstring;

        #endregion フィールド

        #region 構築

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="instance_name">インスタンス名</param>
        internal DownloadJsonAndToList(String instance_name)
        {
            this.instancename = instance_name;
        }

        #endregion 構築

        #region メソッド

        /// <summary>
        /// JSONデータを文字列形式でダウンロードする
        /// </summary>
        internal void DownloadJson()
        {
            var targeturl = Mastodon_usernum.DownloadJsonAndToList.GETJSONSTR1 +
                            this.instancename +
                            Mastodon_usernum.DownloadJsonAndToList.GETJSONSTR2 +
                            (new DateTimeOffset(DateTime.Now)).ToUnixTimeSeconds().ToString();

            using (var reader = new StreamReader(WebRequest.Create(targeturl).GetResponse().GetResponseStream()))
            {
                this.jsonstring = reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 文字列形式のJSONデータをList_MastodonDataに変換する
        /// </summary>
        internal List<MastodonData> JsonToList()
        {
            return JsonConvert.DeserializeObject<List<MastodonData>>(this.jsonstring);
        }

        #endregion メソッド
    }
}
