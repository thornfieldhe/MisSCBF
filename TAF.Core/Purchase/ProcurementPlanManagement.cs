// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlanManagement.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   招标类型基础属性
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using TAF.Utility;

namespace SCBF.Purchase
{
    /// <summary>
    /// 招标类型基础属性
    /// </summary>
    public class ProcurementPlanManagement
    {
        public ProcurementPlanManagement(string category,DateTime date)
        {
            switch (category)
            {
                case "Yqzb":
                    this.Date11 = date.AddWeekend(-30);
                    this.Date12 = date.AddWeekend(-26);
                    this.Date2 = date.AddWeekend(1);
                    this.Date31 = date.AddWeekend(2);
                    this.Date32 = date.AddWeekend(6);
                    this.Date41 = date.AddWeekend(-25);
                    this.Date42 = date.AddWeekend(-21);
                    this.Date51 = date.AddWeekend(-20);
                    this.Date52 = date.AddWeekend(-1);
                    this.Date6 = date.AddWeekend(7);
                    this.Date71 = date.AddWeekend(7);
                    this.Date72 = date.AddWeekend(14);
                    break;
                case "Jzxtp":
                    this.Date11 = date.AddWeekend(-8);
                    this.Date12 = date.AddWeekend(-6);
                    this.Date2  = date.AddWeekend(1);
                    this.Date31 = date.AddWeekend(2);
                    this.Date32 = date.AddWeekend(6);
                    this.Date41 = date.AddWeekend(-5);
                    this.Date42 = date.AddWeekend(-4);
                    this.Date51 = date.AddWeekend(-3);
                    this.Date52 = date.AddWeekend(-1);
                    this.Date6  = date.AddWeekend(7);
                    this.Date71 = date.AddWeekend(7);
                    this.Date72 = date.AddWeekend(14);
                    break;
                case "Xjcg":
                    this.Date11 = date.AddWeekend(-8);
                    this.Date12 = date.AddWeekend(-6);
                    this.Date2  = date.AddWeekend(1);
                    this.Date31 = date.AddWeekend(2);
                    this.Date32 = date.AddWeekend(6);
                    this.Date41 = date.AddWeekend(-5);
                    this.Date42 = date.AddWeekend(-4);
                    this.Date51 = date.AddWeekend(-3);
                    this.Date52 = date.AddWeekend(-1);
                    this.Date6  = date.AddWeekend(7);
                    this.Date71 = date.AddWeekend(7);
                    this.Date72 = date.AddWeekend(14);
                    break;
                case "Bxcg":
                    this.Date11 = date.AddWeekend(-18);
                    this.Date12 = date.AddWeekend(-16);
                    this.Date2  = date.AddWeekend(1);
                    this.Date31 = date.AddWeekend(2);
                    this.Date32 = date.AddWeekend(6);
                    this.Date41 = date.AddWeekend(-15);
                    this.Date42 = date.AddWeekend(-11);
                    this.Date51 = date.AddWeekend(-10);
                    this.Date52 = date.AddWeekend(-1);
                    this.Date6  = date.AddWeekend(7);
                    this.Date71 = date.AddWeekend(7);
                    this.Date72 = date.AddWeekend(14);
                    break;
                case "GkzbZhpff":
                    this.Date11 = date.AddWeekend(-30);
                    this.Date12 = date.AddWeekend(-26);
                    this.Date2  = date.AddWeekend(1);
                    this.Date31 = date.AddWeekend(2);
                    this.Date32 = date.AddWeekend(6);
                    this.Date41 = date.AddWeekend(-25);
                    this.Date42 = date.AddWeekend(-21);
                    this.Date51 = date.AddWeekend(-20);
                    this.Date52 = date.AddWeekend(-1);
                    this.Date6  = date.AddWeekend(7);
                    this.Date71 = date.AddWeekend(7);
                    this.Date72 = date.AddWeekend(14);
                    break;
                case "GkzbZdjf":
                    this.Date11 = date.AddWeekend(-30);
                    this.Date12 = date.AddWeekend(-26);
                    this.Date2  = date.AddWeekend(1);
                    this.Date31 = date.AddWeekend(2);
                    this.Date32 = date.AddWeekend(6);
                    this.Date41 = date.AddWeekend(-25);
                    this.Date42 = date.AddWeekend(-21);
                    this.Date51 = date.AddWeekend(-20);
                    this.Date52 = date.AddWeekend(-1);
                    this.Date6  = date.AddWeekend(7);
                    this.Date71 = date.AddWeekend(7);
                    this.Date72 = date.AddWeekend(14);
                    break;
                case "Dylycg":
                    this.Date11 = date.AddWeekend(-7);
                    this.Date12 = date.AddWeekend(-5);
                    this.Date2  = date.AddWeekend(1);
                    this.Date31 = date.AddWeekend(2);
                    this.Date32 = date.AddWeekend(6);
                    this.Date41 = date.AddWeekend(-4);
                    this.Date42 = date.AddWeekend(-3);
                    this.Date51 = date.AddWeekend(-2);
                    this.Date52 = date.AddWeekend(-1);
                    this.Date6  = date.AddWeekend(7);
                    this.Date71 = date.AddWeekend(7);
                    this.Date72 = date.AddWeekend(14);
                    break;
            }
        }

        /// <summary>
        /// 招标公告起
        /// </summary>
        public DateTime Date11 { get;  }

        /// <summary>
        /// 招标公告止
        /// </summary>
        public DateTime Date12 { get;  }

        /// <summary>
        /// 招标结果公告期
        /// </summary>
        public DateTime Date2 { get;  }

        /// <summary>
        /// 招标结果公示起
        /// </summary>
        public DateTime Date31 { get;  }

        /// <summary>
        /// 招标结果公示止
        /// </summary>
        public DateTime Date32 { get;  }

        /// <summary>
        /// 标书发售日期起
        /// </summary>
        public DateTime Date41 { get;  }

        /// <summary>
        /// 标书发售日期止
        /// </summary>
        public DateTime Date42 { get;  }

        /// <summary>
        /// 执行周期起
        /// </summary>
        public DateTime Date51 { get;  }

        /// <summary>
        /// 执行周期止
        /// </summary>
        public DateTime Date52 { get;  }

        /// <summary>
        /// 中标通知书时间
        /// </summary>
        public DateTime Date6 { get;  }

        /// <summary>
        /// 合同签订起
        /// </summary>
        public DateTime Date71 { get;  }

        /// <summary>
        /// 合同签订止
        /// </summary>
        public DateTime Date72 { get;  }
    }
}
