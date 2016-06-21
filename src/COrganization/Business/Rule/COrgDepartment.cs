
namespace COrganization.Business.Rule
{
    using System.ComponentModel.DataAnnotations;
    using CAM.Core.Business.Rule;
    using CAM.Core.Model.Validation;
    using CAM.Common.Data;
    using Model.Entity;

    public class DepartmentCannotWithOutBranchRule : BaseRule<COrgDepartment>
    {
        public DepartmentCannotWithOutBranchRule(IRepository<COrgDepartment> res, COrgDepartment checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            if (_checkObj.BranchId == 0)
            {
                result = createValidationResult("BranchId", string.Format("部门【{0}】必须属于一个分子公司！", _checkObj.NameStruct.Name));
            }
            return result;
        }
    }


    public class DepartmentCannotDeleteWhenExistsUserRule : BaseRule<COrgDepartment>
    {
        public DepartmentCannotDeleteWhenExistsUserRule(IRepository<COrgDepartment> res, COrgDepartment checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            if (_checkObj.UserCount > 0)
            {
                result = createValidationResult("UserCount", string.Format("部门【{0}】下还有 {1} 名员工，删除前请先将这些员工转移到其他部门内！", _checkObj.NameStruct.Name, _checkObj.UserCount));
            }
            return result;
        }
    }
}
