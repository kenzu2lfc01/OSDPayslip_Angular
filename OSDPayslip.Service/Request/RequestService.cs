using AutoMapper;
using OSDPayslip.Application.Reponsitories;
using OSDPayslip.Application.Reponsitories.Interfaces;
using OSDPayslip.Models.Models;
using OSDPayslip.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSDPayslip.Service.Request
{
    public class RequestService : IRequestService
    {
        private readonly IRequestDetailReponsitory _requestDetailReponsitory;
        private readonly Mapper _mapper;

        public RequestService(IRequestDetailReponsitory requestDetailReponsitory, Mapper mapper)
        {
            _requestDetailReponsitory = requestDetailReponsitory;
            _mapper = mapper;
        }

        public RequestDetailViewModel Add(RequestDetailViewModel requestDetail)
        {
            var temp = _mapper.Map<RequestDetailViewModel, RequestDetail>(requestDetail);
            _requestDetailReponsitory.Add(temp);
            return requestDetail;
        }

        public void Delete(int id)
        {
            _requestDetailReponsitory.Remove(id);
        }

        public IEnumerable<RequestDetailViewModel> GetAll()
        {
            var lst = _requestDetailReponsitory.FindAll().ToList();
            IEnumerable<RequestDetailViewModel> requestDetailViewModels = new List<RequestDetailViewModel>();
            return requestDetailViewModels = _mapper.Map<List<RequestDetail>, List<RequestDetailViewModel>>(lst);
        }

        public IEnumerable<RequestDetailViewModel> GetAllById(int id)
        {
            var lst = _requestDetailReponsitory.FindAll().Where(x => x.RequestID == id).ToList();
            IEnumerable<RequestDetailViewModel> requestDetailViewModels = new List<RequestDetailViewModel>();
            return requestDetailViewModels = _mapper.Map<List<RequestDetail>, List<RequestDetailViewModel>>(lst);
        }

        public RequestDetailViewModel GetById(int id)
        {
            var item = _requestDetailReponsitory.FindAll().Where(x => x.RequestID == id).FirstOrDefault();
            RequestDetailViewModel requestDetailViewModel = new RequestDetailViewModel();
            return requestDetailViewModel = _mapper.Map<RequestDetail, RequestDetailViewModel>(item);
        }

        public void Save()
        {
            _requestDetailReponsitory.Commit();
        }

        public RequestDetailViewModel Update(RequestDetailViewModel requestDetail)
        {
            var temp = _mapper.Map<RequestDetailViewModel, RequestDetail>(requestDetail);
            _requestDetailReponsitory.Update(temp);
            return requestDetail;
        }
        public void UpdateNoOfDeployee(int n, int id)
        {
            var Request = GetById(id);
            Request.NoOfDeployee = n;
            Save();
        }
        public int CreateNewRequest(int month)
        {
            RequestDetailViewModel requestDetail = new RequestDetailViewModel()
            {
                NoOfDeployee = 0,
                PayslipForMonth = month,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                CreateBy = "",
                ModifyBy = "",
                Status = 0
            };
            Add(requestDetail);
            Save();
            return GetAll().Max(x => x.RequestID);
        }
    }
}