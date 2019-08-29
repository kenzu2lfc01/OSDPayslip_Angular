using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSDPayslip.Data;
using OSDPayslip.Models.Models;
using OSDPayslip.Models.ViewModels;
using OSDPayslip.Service.Payslip;
using OSDPayslip.Service.Request;
using OSDPayslip.Service.Request.DTO;

namespace OSDPayslip.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDetailController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IPayslipService _payslipService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public RequestDetailController(IRequestService requestService, IHostingEnvironment hostingEnvironment, IPayslipService payslipService)
        {
            _requestService = requestService;
            _hostingEnvironment = hostingEnvironment;
            _payslipService = payslipService;
        }

        // GET: api/RequestDetail
        [HttpGet]
        public ActionResult<IEnumerable<RequestDetailViewModel>> GetRequestDetail()
        {
            return _requestService.GetAll().ToList();
        }

        [HttpPost]
        [Route("Read")]
        public void ReadExcelFile(FileInfoInputDTO input)
        {
            var requestId = _requestService.CreateNewRequest(input.Month);
            _payslipService.MoveFile(input.FileBase64);
            var noOfEmployee = _payslipService.HandleExcelFile();
            _requestService.UpdateNoOfDeployee(noOfEmployee, requestId);
        }

        // GET: api/RequestDetail/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RequestDetailViewModel>> GetRequestDetail(int id)
        {
            var requestDetail = _requestService.GetAllById(id).ToList();

            if (requestDetail == null)
            {
                return NotFound();
            }

            return requestDetail;
        }

        // POST: api/RequestDetail
        [HttpPost]
        public ActionResult<RequestDetailViewModel> PostRequestDetail(RequestDetailViewModel requestDetail)
        {
            _requestService.Add(requestDetail);
            _requestService.Save();
            return CreatedAtAction("GetRequestDetail", new { id = requestDetail.Id }, requestDetail);
        }

        // DELETE: api/RequestDetail/5
        [HttpDelete("{id}")]
        public ActionResult<RequestDetailViewModel> DeleteRequestDetail(int id)
        {
            var requestDetail = _requestService.GetById(id);
            if (RequestDetailExists(id) == false)
            {
                return NotFound();
            }

            _requestService.Delete(id);
            _requestService.Save();
            return requestDetail;
        }

        private bool RequestDetailExists(int id)
        {
            var requestDetail = _requestService.GetById(id);
            if (requestDetail != null)
            {
                return true;
            }
            return false;
        }
    }
}
