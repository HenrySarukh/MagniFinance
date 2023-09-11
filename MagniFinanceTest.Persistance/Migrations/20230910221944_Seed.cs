using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagniFinanceTest.Persistance.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                IF NOT EXISTS (SELECT 1 FROM Users)
                BEGIN
                    INSERT INTO Users(UserId,FirstName,LastName,Email,ContactNumber)
                    VALUES
                        ('a79fabab-7571-45c7-b2a5-005f68e81912','MagniFinance','Admin','magniFinance.admin@MagniFinance.com','088 8895')

                    INSERT INTO Teachers (FirstName, LastName, Birthday, Salary, CreatedDate)
                    VALUES
                        ('Teacher', '1', '1980-01-15', 50000, '2000-12-12'),
                        ('Teacher', '2', '1985-03-20', 55000, '2000-12-12' ),
                        ('Teacher', '3', '1990-06-10', 60000, '2000-12-12');


                    INSERT INTO Students (FirstName, LastName, Birthday, RegistrationNumber, CreatedDate)
                    VALUES
                        ('Student', '1', '2000-02-25', 'S12345', '2000-12-12'),
                        ('Student', '2', '2001-04-30', 'S54321', '2000-12-12'),
                        ('Student', '3', '1999-11-05', 'S98765', '2000-12-12');

                    INSERT INTO Courses (Name, Code, Description, CreatedDate)
                    VALUES
                        ('Course A', 'C123', 'Interesting Course 1', '2000-12-12'),
                        ('Course B', 'C456', 'Interesting Course 2', '2000-12-12'),
                        ('Course C', 'C789', 'Interesting Course 3', '2000-12-12');

                    INSERT INTO Subjects (Name, TeacherId, CourseId, CreatedDate)
                    VALUES
                        ('Subject 1', 1, 1, '2000-12-12'),
                        ('Subject 2', 2, 1, '2000-12-12'),
                        ('Subject 3', 3, 2, '2000-12-12');

                    INSERT INTO Grades (SubjectId, StudentId, GradeValue, CreatedDate)
                    VALUES
                        (1, 1, 18.5, '2000-12-12'),
                        (1, 2, 16.0, '2000-12-12'),
                        (2, 1, 19.0, '2000-12-12'),
                        (2, 2, 17.5, '2000-12-12'),
                        (3, 1, 20.0, '2000-12-12'),
                        (3, 3, 15.5, '2000-12-12');
				END";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"DELETE FROM Teachers
            GO
            DELETE FROM Students
            GO
            DELETE FROM Subjects
            GO
            DELETE FROM Courses
            GO
            DELETE FROM Grades
            GO
            DELETE FROM Users
            GO");
        }
    }
}
