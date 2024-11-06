namespace Core.Domain.Constants;

public class BaseConstants
{
    #region Roles

    public const string RoleAdmin = "Administrator";
    public const string RoleCompanyAdmin = "Company Administrator";
    public const string RoleHR = "HR";
    public const string RoleEmployee = "Employee";     

    public const string NonEmployeeRoles = RoleAdmin + "," + RoleCompanyAdmin + "," + RoleHR;

    #endregion
}
