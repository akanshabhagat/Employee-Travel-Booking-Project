create database Emp_Travel_Booking;

-- Employee Table
create table Employee
(
  Emp_Id int Primary Key Identity(1,1),
  Emp_FirstName varchar(20) NOT NULL,
  Emp_LastName varchar(20)NOT NULL,
  Emp_DOB Date,
  Emp_Address varchar(20),
  Emp_Contact varchar(20)
)

-- Travel Request Table
create table Travel_Request
( 
 Request_Id int Primary Key Identity(1,1),
 Emp_Id int Foreign Key references Employee(Emp_Id),
 Loc_From varchar(20) NOT NULL,
 Loc_To varchar(20)NOT NULL,
 Approval_Status varchar(20),
 Booking_Status varchar(20),
 Current_Status varchar(20)
)

select * from Employee;
select * from Travel_Request;

-- SP to add employee
create or alter procedure sp_AddEmployee(@FirstName varchar(20), @LastName varchar(20),@DOB Date, @Address varchar(20),@Contact varchar(20))
as
begin
  insert into Employee values(@FirstName,@LastName,@DOB,@Address,@Contact)
end

exec sp_AddEmployee 'Akansha','Bhagat','7/10/2001','Pune','9172444399'
exec sp_AddEmployee 'Sakshi','Bankar','2002-05-18','Mumbai','9423793315'


select * from Employee;
select * from Travel_Request;


-- SP to view all employees
create or alter procedure sp_viewAllEmployee
as
begin
  select * from Employee
end

exec sp_viewAllEmployee


-- SP to view employee by emp_ID
create or alter procedure sp_viewEmployeeById(@Emp_Id int)
as
begin
  select * from Employee where Emp_Id = @Emp_Id
end

exec sp_viewEmployeeById 1

-- SP to edit employee by emp_Id
create or alter procedure sp_editEmpById(@Emp_Id int,@Emp_FName varchar(20),@Emp_LName varchar(20),@DOB varchar(20),@Emp_Address varchar(20),@Emp_Contact varchar(20))
as
begin
   update Employee set Emp_FirstName = @Emp_FName, Emp_LastName = @Emp_LName, Emp_DOB =@DOB, Emp_Address = @Emp_Address, Emp_Contact = @Emp_Contact
   where Emp_Id = @Emp_Id
end


-- SP to edit employee FirstName By ID
create or alter procedure sp_EditEmpNameById(@Emp_Id int,@Emp_FName varchar(20))
as
begin
   update Employee set Emp_FirstName = @Emp_FName
   where Emp_Id = @Emp_Id
end

exec sp_EditEmpNameById 3,'Shrushti'

-- SP to edit employee LastName By ID
create or alter procedure sp_EditEmpNameById(@Emp_Id int,@Emp_LName varchar(20))
as
begin
   update Employee set Emp_LastName = @Emp_LName
   where Emp_Id = @Emp_Id
end


-- SP to edit Employee Contact By ID
create or alter procedure sp_EditEmpContactById(@Emp_Id int, @Emp_Contact varchar(20))
as
begin
  update Employee set Emp_Contact = @Emp_Contact
  where Emp_Id = @Emp_Id
end

-- SP to edit Employee Address By ID
create or alter procedure sp_EditEmpContactById(@Emp_Id int, @Emp_Address varchar(20))
as
begin
  update Employee set Emp_Address = @Emp_Address
  where Emp_Id = @Emp_Id
end

-- SP to edit employee DOB By ID
create or alter procedure sp_EditDOBById(@Emp_Id int,@Emp_DOB varchar(20))
as
begin
   update Employee set Emp_DOB = @Emp_DOB
   where Emp_Id = @Emp_Id
end


-- SP to delete Employee By ID
create or alter procedure sp_deleteEmpById(@Emp_Id int)
as
begin
 delete from Employee where Emp_Id = @Emp_Id
end

exec sp_deleteEmpById 3


-- SP to Raise Travel Request
create or alter procedure sp_RaiseTravelReq(@Emp_Id int, @Loc_From varchar(20),@Loc_To varchar(20))
as
begin
insert into Travel_Request values(@Emp_Id,@Loc_From,@Loc_To)
end

exec sp_RaiseTravelReq 1,'Pune','Banglore'
exec sp_RaiseTravelReq 5,'Chennai','Pune'



-- SP to view Travel Request
create or alter procedure sp_ViewTravelReq(@Emp_Id int)
as
begin
select * from Travel_Request
where Emp_Id = @Emp_Id
end


--ViewAllRequests
create procedure sp_ViewAllRequests
as
begin
	select Request_id, e.Emp_Id, Loc_From, Loc_To, Approval_Status, Booking_Status, 
	Current_Status, e.Emp_FirstName, e.Emp_LastName
	from Employee e inner join Travel_Request t
	on e.Emp_Id=t.Emp_id
end

exec sp_ViewAllRequests


-- SP to view Approved Travel Request
create or alter procedure sp_ViewApprovedTravelReq(@isapproved varchar(20))
as
begin
select * from Travel_Request
where Approval_Status = @isapproved-- @isapproved
end

-- SP to view Open Travel Request
--create or alter procedure sp_ViewOpenTravelReq
--as
--begin
--select * from Travel_Request
--where Current_Status = 'Open'
--end

create procedure sp_ViewOpenRequests
as
begin
	select Request_Id, e.Emp_Id, Loc_From, Loc_To, Approval_Status, Booking_Status, 
	Current_Status, e.Emp_FirstName,e.Emp_LastName 
	from Employee e inner join Travel_Request t
	on e.Emp_Id = t.Emp_Id
	where Current_Status='Open' and Approval_Status is null
	--order by Req_Date
end

exec sp_ViewOpenRequests


-- SP to view Close Travel Request
create or alter procedure sp_ViewCloseTravelReq
as
begin
select * from Travel_Request
where Current_Status = 'Close'
end

-- SP to view Booked Travel Request
create or alter procedure sp_ViewBookedTravelReq
as
begin
select * from Travel_Request
where Booking_Status = 'Booked'
end



-- SP to delete Travel Request By EmpId and RequestId
create or alter procedure sp_deleteTravelReq(@Emp_Id int, @Request_Id int)
as
begin
delete from Travel_Request
where Emp_Id = @Emp_Id and Request_Id = @Request_Id
end

-- SP to delete Travel Request By EmpId
create or alter procedure sp_deleteTravelReqByEmpId(@Emp_Id int)
as
begin
delete from Travel_Request
where Emp_Id = @Emp_Id
end

-- SP to delete Travel Request By Request Id
create or alter procedure sp_deleteTravelReqByReqId(@Request_Id int)
as
begin
delete from Travel_Request
where Request_Id = @Request_Id
end

exec sp_deleteTravelReqByReqId 1
exec sp_deleteTravelReqByReqId 2


-- SP to Approve Travel Request
create or alter procedure sp_ApproveTravelReq(@Request_Id int, @Status varchar(20))
as
begin
update Travel_Request set Approval_Status = @status where Request_Id = @Request_Id
end

-- SP to Confirm Booking
create or alter procedure sp_ConfirmBooking(@Request_Id int, @booking_status varchar(20))
as
begin
update Travel_Request set Booking_Status = @booking_status,Current_Status='Closed' where Request_Id = @Request_Id
end

--exec sp_ConfirmBooking 4,' Not Available'


-- SP to Approve Travel Request and confirm booking
create or alter procedure sp_ApproveTravelReq_ConfirmBooking(@Request_Id int, @Approve_Status varchar(20), @Booking_Status varchar(20),@Current_Status varchar(20))
as
begin
update Travel_Request set Approval_Status = @Approve_Status, Booking_Status = @Booking_Status, Current_Status =@Current_Status where Request_Id = @Request_Id
end



-- 16-10-23

--AddEmployee
--create or alter procedure sp_AddEmployee (
--@e_name varchar(20), @e_addr varchar(50), @e_sal int, @e_dob date)
--as
--begin
--	insert into Employee values(@e_name, @e_addr,@e_sal, @e_dob )
--end

--exec sp_AddEmployee 'Snehal Maydeo', 'Andheri, Mumbai', 20000, '1969-2-15'
--exec sp_AddEmployee 'Pinky Sharma', 'Kothrud, Pune', 30000, '1975-5-16'
--exec sp_AddEmployee 'Shrishti Roy', 'Kormangala, Bangalore', 15000, '1989-10-25'
--exec sp_AddEmployee 'Preetam Shenoi', 'Chengalpattu, Chennai', 28000, '1970-11-30'


--EditEmployee - create or alter procedure sp_EditEmployee
--DelEmployee
--ViewEmployees


--AddRequest
--create or alter procedure sp_AddRequest(@emp_id int, @req_date date, @from_location varchar(15),
--@to_location varchar(15))
--as
--begin
--	insert into TravelRequest (E_id, Req_Date, From_Location, To_Location, Current_Status)
--	values(@emp_id, @req_date, @from_location,@to_location, 'Open')
--end

--select * from Employee

--exec sp_AddRequest 1003, '2023-4-4','Mumbai', 'Bangalore'

--EditRequest
--DeleteRequest


--ApproveRequest - To Update the Approved_Status column for Request
create or Alter procedure sp_ApproveRequest (@req_id int, @is_approved varchar(15))
as 
begin
	if @is_approved='Not Approved'
	begin
		update Travel_Request set Approval_Status=@is_approved, Current_Status='Closed'
		where Request_Id=@req_id
	end
	else
	begin
		update Travel_Request set Approval_Status=@is_approved
		where Request_Id=@req_id
	end
end

--exec sp_ApproveRequest 6, 'Not Approved' 


--ViewAllRequests
--create procedure sp_ViewAllRequests
--as
--begin
--	select REq_id, e.E_id, Req_Date, From_Location, To_Location, Approved_Status, Booking_Status, 
--	Current_Status, e.E_name 
--	from Employee e inner join TravelRequest t
--	on e.E_Id=t.e_id
--	order by Req_Date
--end

--exec sp_ViewAllRequests


--ViewOpenRequests
--create procedure sp_ViewOpenRequests
--as
--begin
--	select REq_id, e.E_id, Req_Date, From_Location, To_Location, Approved_Status, Booking_Status, 
--	Current_Status, e.E_name 
--	from Employee e inner join TravelRequest t
--	on e.E_Id=t.e_id
--	where Current_Status='Open' and Approved_Status is null
--	order by Req_Date
--end

--exec sp_ViewOpenRequests



--ViewApprovedRequests
create procedure sp_ViewApprovedRequests
as
begin
	select Request_Id, e.Emp_id, Loc_From, Loc_To, Approval_Status, Booking_Status, 
	Current_Status, e.Emp_FirstName, e.Emp_LastName 
	from Employee e inner join Travel_Request t
	on e.Emp_Id=t.Emp_Id
	where Current_Status='Open' and Approval_Status ='Approved'
	--order by Req_Date
end

exec sp_ViewApprovedRequests

--ViewConfirmedRequests

--ViewClosedRequests

