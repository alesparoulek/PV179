using JobsPortal.BusinessLayer.DataTransferObjects.Common;

namespace JobsPortal.BusinessLayer.DataTransferObjects.Filters
{
    class UserFilterDto : FilterDtoBase
    {
        public string Email { get; set; }
    }
}