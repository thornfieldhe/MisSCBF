// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PwdEditDto.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the PwdEditDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Users.Dto
{
    public class PwdEditDto
    {
        /// <summary>
        ///  ”√ªßId
        /// </summary>
        public long UserId
        {
            get; set;
        }

        /// <summary>
        /// æ…√‹¬Î
        /// </summary>
        public string OldPwd
        {
            get; set;
        }

        /// <summary>
        /// –¬√‹¬Î
        /// </summary>
        public string NewPwd
        {
            get; set;
        }
    }
}