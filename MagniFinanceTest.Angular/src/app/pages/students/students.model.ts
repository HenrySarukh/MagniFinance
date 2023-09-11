export interface StudentInfromation
{
    studentFirstName: string,
    studentLastName: string,
    registrationNumber: string,
    subjectRespectiveGrades: SubjectRespectiveGrade[]
}

export interface SubjectRespectiveGrade
{
    subjectName: string 
    respectiveGrade: number 
}
