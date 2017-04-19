//-----------------------------------------------------------------------
// <copyright file="MastodonData.cs" company="dc1394's software">
//     Copyright ©  2017 @dc1394 All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mastodon_usernum
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    internal sealed class MastodonData
    {
        [DataMember]
        internal Int32 date { get; set; }
        [DataMember]
        internal Double uptime { get; set; }
        [DataMember]
        internal Boolean up { get; set; }
        [DataMember]
        internal Boolean https { get; set; }
        [DataMember]
        internal Boolean ipv6 { get; set; }
        [DataMember]
        internal Int32? https_score { get; set; }
        [DataMember]
        internal String https_rank { get; set; }
        [DataMember]
        internal Int32 users { get; set; }
        [DataMember]
        internal Int32 statuses { get; set; }
        [DataMember]
        internal Int32 connections { get; set; }
        [DataMember]
        internal Boolean openRegistrations { get; set; }
    }
}
