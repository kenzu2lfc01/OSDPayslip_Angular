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
    constructor(
        public PayslipForMonth: number,
        public File: any
    ) { }
}
