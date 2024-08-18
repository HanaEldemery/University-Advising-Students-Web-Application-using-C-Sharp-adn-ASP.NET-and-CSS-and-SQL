<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="Advising_System.AdminHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800;900&family=Poppins:wght@300;400;500;600;700&display=swap" rel="stylesheet">
</head>
<body>
    <div class="formContainerHome">
        <form id="form2" runat="server">
            <div>
                <label for="course">Delete Course Page</label>
                <asp:Button ID="course" CssClass="button" runat="server" OnClick="courseFn" Text="Visit" />
            </div>
            <div>
                <label for="slot">Delete Slot Page</label>
                <asp:Button ID="slot" CssClass="button" runat="server" OnClick="slotFn" Text="Visit" />
            </div>
            <div>
                <label for="makeup">Add MakeUp Page</label>
                <asp:Button ID="makeup" CssClass="button" runat="server" OnClick="makeupFn" Text="Visit" />
            </div>
            <div>
                <label for="payment">View All Payments Page</label>
                <asp:Button ID="payment" CssClass="button" runat="server" OnClick="paymentsFn" Text="Visit" />
            </div>
            <div>
                <label for="installment">Issue Installments for Payment Page</label>
                <asp:Button ID="installment" CssClass="button" runat="server" OnClick="installmentFn" Text="Visit" />
            </div>
            <div>
                <label for="studentstatus">Update Student Financial Status Page</label>
                <asp:Button ID="studentstatus" CssClass="button" runat="server" OnClick="studentStatusFn" Text="Visit" />
            </div>
            <div>
                <label for="students">All Students Details Page</label>
                <asp:Button ID="students" CssClass="button" runat="server" OnClick="studentsDetailsFn" Text="Visit" />
            </div>
            <div>
                <label for="gplans">All Graduation Plans Page</label>
                <asp:Button ID="gplans" CssClass="button" runat="server" OnClick="gplansFn" Text="Visit" />
            </div>
            <div>
                <label for="transcript">All Students With Their Transcripts Page</label>
                <asp:Button ID="transcript" CssClass="button" runat="server" OnClick="transcriptFn" Text="Visit" />
            </div>
            <div>
                <label for="semesters">All Semesters and Their Courses Page</label>
                <asp:Button ID="semesters" CssClass="button" runat="server" OnClick="semestersFn" Text="Visit" />
            </div>
            <div>
                <label for="advisors">All Advisors Page</label>
                <asp:Button ID="advisors" CssClass="button" runat="server" OnClick="advisorsFn" Text="Visit" />
            </div>
            <div>
                <label for="studentAdvisors">All Students With Their Advisor Page</label>
                <asp:Button ID="studentAdvisors" CssClass="button" runat="server" OnClick="studentAdvisorsFn" Text="Visit" />
            </div>
            <div>
                <label for="pendingRequests">All Pending Requests Page</label>
                <asp:Button ID="pendingRequests" CssClass="button" runat="server" OnClick="pendingRequestsFn" Text="Visit" />
            </div>
            <div>
                <label for="addSemester">Add Semester Page</label>
                <asp:Button ID="addSemester" CssClass="button" runat="server" OnClick="addSemesterFn" Text="Visit" />
            </div>
            <div>
                <label for="addCourses">Add Course Page</label>
                <asp:Button ID="addCourse" CssClass="button" runat="server" OnClick="addCourseFn" Text="Visit" />
            </div>
            <div>
                <label for="addInstructorLinkCourse">Link Instructor With Course on Slot Page</label>
                <asp:Button ID="addInstructorLinkCourse" CssClass="button" runat="server" OnClick="addInstructorLinkCourseFn" Text="Visit" />
            </div>
            <div>
                <label for="addStudentLinkAdvisor">Link Student With Advisor Page</label>
                <asp:Button ID="addStudentLinkAdvisor" CssClass="button" runat="server" OnClick="addStudentLinkAdvisorFn" Text="Visit" />
            </div>
            <div>
                <label for="addStudentLinkCourseInstructor">Link Student With Course and Instructor Page</label>
                <asp:Button ID="addStudentLinkCourseInstructor" CssClass="button" runat="server" OnClick="addStudentLinkCourseInstructorFn" Text="Visit" />
            </div>
            <div>
                <label for="viewInstructors">View Instructors Page</label>
                <asp:Button ID="viewInstructors" CssClass="button" runat="server" OnClick="viewInstructorsFn" Text="Visit" />
            </div>
        </form>
    </div>
</body>
</html>
