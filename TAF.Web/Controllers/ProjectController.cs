namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Projects;
    using SCBF.Projects.Dto;
    using SCBF.Utility;

    [AbpMvcAuthorize]
    public class ProjectController : TAFControllerBase
    {
        private readonly IProjectAppService projectAppService;

        public ProjectController(IProjectAppService projectAppService)
        {
            this.projectAppService = projectAppService;
        }

        public ActionResult ProjectList()
        {
            return PartialView("_ProjectIndex");
        }

        public ActionResult ProjectStatistic()
        {
            return PartialView("_ProjectStatistic");
        }


        public ActionResult LoadStatistic(DateTimeQueryDto query)
        {
            var scripts = new KeyValue<string, string>(
                this.projectAppService.GetStatisticForProjet(query),
                this.projectAppService.GetStatisticForUser(query));
            return PartialView("_LoadStatistic", scripts);
        }
    }
}