﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dictionary.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统字典表
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using SCBF.Car;
    using SCBF.Storage;
    using System.Collections.Generic;

    /// <summary>
    /// 系统字典表
    /// </summary>
    public sealed class SysDictionary : TAFEntity
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

        /// <summary>
        /// Value5
        /// </summary>
        public string Value5
        {
            get; set;
        }

        public string Value6
        {
            get; set;
        }

        public string Value7
        {
            get; set;
        }

        public string Value8
        {
            get; set;
        }

        public string Value9
        {
            get; set;
        }

        /// <summary>
        /// Value10
        /// </summary>
        public string Value10
        {
            get; set;
        }

        public string Value11
        {
            get; set;
        }

        public string Value12
        {
            get; set;
        }

        public string Value13
        {
            get; set;
        }

        public string Value14
        {
            get; set;
        }

        public string Value15
        {
            get; set;
        }

        public string Value16
        {
            get; set;
        }

        public string Value17
        {
            get; set;
        }

        public string Value18
        {
            get; set;
        }

        public string Value19
        {
            get; set;
        }

        public List<Entry> Entries
        {
            get; set;
        }

        public List<Delivery> Deliveries
        {
            get; set;
        }

        public List<Stock> Stocks
        {
            get; set;
        }

        public List<HisStock> HisStocks
        {
            get; set;
        }

        public List<Driver> Drivers
        {
            get; set;
        }

        public List<CarInfo> Cars
        {
            get; set;
        }

        public List<ApplicationForBunkerA> ApplicationForBunkerAs { get; set; }
        public List<ApplicationForBunkerB> ApplicationForBunkerBs { get; set; }
    }
}