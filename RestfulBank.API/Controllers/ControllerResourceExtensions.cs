using Microsoft.AspNetCore.Mvc;
using RestfulBank.API.Resources;

namespace RestfulBank.API.Controllers
{
    public static class ControllerResourceExtensions
    {
        public static NotFoundObjectResult NotFoundResource(this ControllerBase controller, Resource resource)
        {
            var result = controller.NotFound(resource);
            result.ContentTypes.Add(resource.GetMediaType());

            return result;
        }

        public static OkObjectResult OkResource(this ControllerBase controller, Resource resource)
        {
            var result = controller.Ok(resource);
            result.ContentTypes.Add(resource.GetMediaType());

            return result;
        }

        public static BadRequestObjectResult BadRequestResource(this ControllerBase controller, Resource resource)
        {
            var result = controller.BadRequest(resource);
            result.ContentTypes.Add(resource.GetMediaType());

            return result;
        }
    }
}
