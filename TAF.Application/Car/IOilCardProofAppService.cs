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

    using TAF.Utility;

    /// <summary>
    /// 加油卡消耗凭证单应用接口
    /// </summary>
    public interface IOilCardProofAppService : IBaseEntityApplicationService
    {
        List<OilCardProofListDto> GetAll(string month);

        string GetNote(Guid id);

        Task SaveNote(KeyValuePair<Guid, string> input);

        Guid LoadProofFile(string path, object month);

        List<ApplicationForBunkerAListDto> GetApplicationForBunkerAList(string month);

        List<UploadOilCarRoofListDto> GetUploadOilCarRoof(string month);

        void Link(KeyValue<Guid, Guid, string> item);
    }
}



