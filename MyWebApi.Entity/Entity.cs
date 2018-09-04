using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace MyWebApi.Entity
{
    /// <summary>
    /// DB表基底
    /// </summary>
    [Serializable]
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumState State { get; set; }
    }

    /// <summary>
    /// 状态
    /// </summary>
    public enum EnumState
    {
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 1,

        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
    }
}