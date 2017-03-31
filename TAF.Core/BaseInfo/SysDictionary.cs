// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dictionary.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统字典表
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System.Collections.Generic;

    using SCBF.Storage;

    /// <summary>
    /// 系统字典表
    /// </summary>
    public class SysDictionary : TAFEntity
    {
        public string Value
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }

        public string Category
        {
            get; set;
        }

        public string Value2
        {
            get; set;
        }

        public string Value3
        {
            get; set;
        }

        public string Value4
        {
            get; set;
        }

        public virtual List<Entry> Entries
        {
            get; set;
        }

        public virtual List<Delivery> Deliveries
        {
            get; set;
        }

        public virtual List<Stock> Stocks
        {
            get; set;
        }
    }
}