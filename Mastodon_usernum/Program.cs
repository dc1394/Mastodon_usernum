//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="dc1394's software">
//     Copyright ©  2017 @dc1394 All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mastodon_usernum
{
    using System;
    using System.Linq;

    /// <summary>
    /// エントリポイントのクラス
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Mastodonのインスタンス名の文字列が格納された配列
        /// </summary>
        private static readonly String[] INSTANCES = new String[] { "mstdn.jp", "pawoo.net", "mastodon.cloud", "friends.nico" };

        /// <summary>
        /// エントリポイント
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        internal static void Main(string[] args)
        {
            var jsondata = Program.INSTANCES.ToDictionary(
                item => item,
                item =>
            {
                var djl = new DownloadJsonAndToList(item);
                djl.DownloadJson();
                return djl.JsonToList();
            });

            (new XlsxWrite(jsondata)).WriteXlsx();
        }
    }
}
