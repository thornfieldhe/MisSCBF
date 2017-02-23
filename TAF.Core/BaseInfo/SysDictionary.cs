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
    }
}