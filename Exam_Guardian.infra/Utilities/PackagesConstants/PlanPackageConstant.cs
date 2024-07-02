using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.Utilities.PackagesConstants
{
    public static class PlanPackageConstant
    {
        public const string PLAN_PACKAGE_CREATE_PLAN = "PLAN_PACKAGE.CREATE_PLAN";
        public const string PLAN_PACKAGE_DELETE_PLAN = "PLAN_PACKAGE.DELETE_PLAN";
        public const string PLAN_PACKAGE_UPDATE_PLAN = "PLAN_PACKAGE.UPDATE_PLAN";
        public const string PLAN_PACKAGE_GET_PLAN_BY_ID = "PLAN_PACKAGE.GET_PLAN_BY_ID";
        public const string PLAN_PACKAGE_GET_ALL_PLANS = "PLAN_PACKAGE.GET_ALL_PLANS";

        // Parameter names matching table column names
        public const string PLAN_ID = "V_plan_id";
        public const string PLAN_NAME = "V_plan_name";
        public const string PLAN_DESCRIPTION = "V_plan_description";
        public const string PLAN_PRICE = "V_plan_price";
        public const string C_id = "p_id";


    }

}
