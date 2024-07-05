using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMGatewaye.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController : ControllerBase
    {
        ServiceMetier.Service1Client service = new ServiceMetier.Service1Client();

        public  bool AddExpert(ServiceMetier.Expert expert) { 
            service.AddExpertAsync(expert).Wait();
        { }
            
        }
     
    }
}
