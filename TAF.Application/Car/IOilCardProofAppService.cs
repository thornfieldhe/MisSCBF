// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOilCardProofAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡消耗凭证单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// 加油卡消耗凭证单应用接口
    /// </summary>
    public interface IOilCardProofAppService : IBaseEntityApplicationService
    {
        List<OilCardProofListDto> GetAll(string month);

        string GetNote(Guid id);

        Task SaveNote(KeyValuePair<Guid, string> input);

        void LoadProofFile(string path, string month);
    }
}



