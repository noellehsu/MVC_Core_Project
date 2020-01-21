Employee種子資料 + IRepository -> EmployeeRepository + DI
 (1)以Migration建立Employee種子資料
 (2)建立IRepository -> EmployeeRepository,建立一個EF讀取所有員工資料的方法
 (3)以DI註冊IRepository ,EmployeeRepository
 (4)建立EmployeesController API控制器, 建立GET方法,以DI注入IRepository,然後顯示所有員工資料

# GitHub -- CoreWebApi_TodoApi
https://github.com/apprunner/CoreWebApi_TodoApi.git


1.EmployeesEFSyncController : 使用EF Core同步 + EmployeeContext（用Scaffolding建立）
 (1)使用EF Core同步
 (2)明確相依Employee模型
 (3)直接相依明確的EmployeeContext
 
2.EmployeesRepoController : 
 (1)使用EmployeeRepositoryAsync(非同步)
 (2)明確相依Employee模型
 (3)DbContext名稱以專屬特定EmployeeContext命名
 
3.EmployeesGenericRepoController : 
 (1)使用GenericRepositoryAsync泛型(非同步)，
 (2)完全沒有相依任何Model模型， 可接受任何型別
 (3)DbContext名稱也改為更通用化HRContext，而不是EmployeeContext

 4.IActionResult , ActionResult, ObjectResult