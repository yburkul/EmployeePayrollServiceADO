use [EmployeePayrollService]

Create PROCEDURE GetAllEmployeeData
AS
SET XACT_ABORT ON;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;

DECLARE @result bit = 0;
  
  select EmployeePayroll.ID, Name,Gender, PhoneNumber, Address,StartDate , Department,BasicPay,Deduction,TaxablePay, IncomeTax, NetPay from
EmployeePayroll left join DepartmentTable on EmployeePayroll.ID = DepartmentTable.Id left join Payroll on EmployeePayroll.ID = Payroll.ID


COMMIT TRANSACTION;
SET @result = 1;
return @result;
END TRY
BEGIN CATCH

IF(XACT_STATE()) = -1
 BEGIN
  PRINT
   'transaction is uncommitable' + 'rolling back transaction'
   ROLLBACK TRANSACTION;
   return @result;
 END;
ELSE IF (XACT_STATE()) = 1
 BEGIN
  PRINT
   'transaction is  commitable' + ' commiting back transaction'
   COMMIT TRANSACTION;
   SET @result =1;
   return @result;
 END;
END CATCH
END

exec GetAllEmployeeData
