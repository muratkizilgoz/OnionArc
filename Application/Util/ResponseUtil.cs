using System;
using Application.Models.Common;

namespace Application.Util
{
    public static class ResponseUtil
    {
        public static BaseResponseModel ResponseResult(int result)
        {
            return new BaseResponseModel
            {
                Status = result > 0 ? true : false,
                Message = result > 0 ? "done" : "error"
            };
        }
    }
}

