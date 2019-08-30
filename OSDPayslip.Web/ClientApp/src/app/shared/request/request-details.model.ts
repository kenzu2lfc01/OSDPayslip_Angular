export class RequestDetails {
    Id: number;
    NoOfDeployee: number
    PayslipForMonth: number
    CreateDate: Date
    CreateBy: string
    ModifyDate: Date
    ModifyBy: string
    Status: number
}
export class CreateRequestInput {
    PayslipForMonth: number
    File: any
}
