export class PayslipDetails {
    Id:number;
    StandardWorkingDay:number;
    ActualWorkingDay: number;
    UnpaidLeave: number;
    LeaveBalance: number;
    Holidays: number;
    BasicSalary: number;
    GrossSalary: number;
    ActuaSalary:number;
    Allowance:number;
    Bonus:number;
    Salary13Th: number;
    IncomeOther: number;
    OtherDeductions: number;
    SocialInsurance: number;
    HealthInsurance: number;
    UnemploymentInsurance: number;
    NoOfDependants: number;
    PersonalIncomeTax: number;
    PaymentFromSocialInsurance: number;
    FinalizationOfPIT: number;
    PaymentOther: number;
    NetIncome: number;
    EmployeeID:string;
    RequestID: number;
    CreateDate:Date;
    CreateBy:string;
    ModifyDate:Date;
    ModifyBy:string;
    Status:number;
}
export class OutputEmployeePayslipList {
      Stt:number;
      EmployeeId:string;
      EmployeeName:string;
      Email:string;
      Status:number;
}