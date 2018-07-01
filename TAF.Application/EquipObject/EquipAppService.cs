// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquipAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   装备管理应用服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Linq;

namespace SCBF.EquipObject
{
    using System;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using Abp.AutoMapper;

    using AutoMapper;

    using SCBF.EquipObject.Dto;

    /// <summary>
    /// 装备管理应用服务
    /// </summary>
    [AbpAuthorize]
    public class EquipAppService : TAFAppServiceBase, IEquipAppService
    {
        private readonly IEquipRepository _equipRepository;

        public EquipAppService(IEquipRepository equipRepository)
        {
            this._equipRepository = equipRepository;
        }



        public EquipEditDto Get(Guid id)
        {
            var output = this._equipRepository.Get(r=>r.LayerId==id).FirstOrDefault();
            return output==null?new EquipEditDto(){LayerId = id} :output.MapTo<EquipEditDto>();
        }

        public async Task SaveAsync(EquipEditDto input)
        {


            if (!input.Id.HasValue)
            {
                var item = input.MapTo<Equip>();
                await this._equipRepository.InsertAsync(item);
            }
            else
            {
                var old = this._equipRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._equipRepository.UpdateAsync(old);
            }

        }

        public void Delete(Guid id)
        {
            this._equipRepository.Delete(r=>r.LayerId==id);
        }
    }
}



