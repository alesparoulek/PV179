using AutoMapper;
using JobsPortal.BusinessLayer.DataTransferObjects;
using JobsPortal.BusinessLayer.DataTransferObjects.Filters;
using JobsPortal.BusinessLayer.QueryObjects.Common;
using JobsPortal.DataAccessLayer.EntityFramework.Entities;
using JobsPortal.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.BusinessLayer.QueryObjects
{
    public class ApplicationQueryObject : QueryObjectBase<ApplicationDto, Application, ApplicationFilterDto, IQuery<Application>>
    {
        public ApplicationQueryObject(IMapper mapper, IQuery<Application> query) : base(mapper, query) { }

        protected override IQuery<Application> ApplyWhereClause(IQuery<Application> query, ApplicationFilterDto filter)
        {
            throw new NotImplementedException();
        }
    }
}
