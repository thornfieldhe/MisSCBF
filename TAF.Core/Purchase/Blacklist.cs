// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Blacklist.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   黑名单
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    /// <summary>
    /// 黑名单
    /// </summary>
    public class Blacklist: TAFEntity
    {
        /// <summary>
        /// 名称，可以是Id，也可以是名称
        /// </summary>
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
