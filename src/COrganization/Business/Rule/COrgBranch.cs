
namespace COrganization.Business.Rule
{
    using System.ComponentModel.DataAnnotations;
    using CAM.Core.Business.Rule;
    using CAM.Core.Model.Validation;
    using CAM.Common.Data;
    using Model.Entity;

    public class BranchCannotWithOutOrganizationRule : BaseRule<COrgBranch>
    {
        public BranchCannotWithOutOrganizationRule(IRepository<COrgBranch> res, COrgBranch checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            if (_checkObj.OrganizationId == 0)
            {
                result = createValidationResult("OrganizationId", string.Format("分子公司【{0}】必须属于一个组织机构！", _checkObj.NameStruct.Name));
            }
            return result;
        }
    }

    public class BranchCannotDeleteWhenExistsUserRule : BaseRule<COrgBranch>
    {
        public BranchCannotDeleteWhenExistsUserRule(IRepository<COrgBranch> res, COrgBranch checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            if (_checkObj.UserCount > 0)
            {
                result = createValidationResult("UserCount", string.Format("分子公司【{0}】下还有 {1} 名员工，删除前请先将这些员工转移到其他分子公司内！", _checkObj.NameStruct.Name, _checkObj.UserCount));
            }
            return result;
        }
    }



    public class BranchCannotDeleteWhenExistsDepartmentRule : BaseRule<COrgBranch>
    {
        public BranchCannotDeleteWhenExistsDepartmentRule(IRepository<COrgBranch> res, COrgBranch checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            if (_checkObj.DepartmentCount > 0)
            {
                result = createValidationResult("DepartmentCount", string.Format("分子公司【{0}】下还有 {1} 个子部门，删除分子公司前请先删除掉这些子部门！", _checkObj.NameStruct.Name, _checkObj.DepartmentCount));
            }
            return result;
        }
    }

}
