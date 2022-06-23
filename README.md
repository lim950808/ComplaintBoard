# ComplaintBoard
Getting Return Value from Stored Procedure using Dapper ORM in ASP.NET MVC
<br>

</br>
<h2>Senario</h2>
Let's consider ABC housing society provides different services to their flat owners.  Since ABC housing society is very big it's difficult to manage complaints manually of their flat customers, so they decided to build the sample application which covers the following scenario. 

1. User can raise the complaint type and short description using Text boxes.
2. The unique ComplaintId need to be generated instantly after raising the complaint to track status.
3. The ComplaintId should be the combination of first four characters of complaint type text and Database auto generated number.
<br>

</br>
<h2>Table (Sql Server)</h2>
CREATE TABLE [dbo].[ComplaintDetails]<br>
(<br>
	[Id] [int] NOT NULL,<br>
	[ComplaintId] [varchar](20) NULL,<br>
	[ComplaintType] [varchar](100) NULL,<br>
	[ComplaintDesc] [varchar](150) NULL,<br>
 CONSTRAINT [PK_ComplaintDetails] PRIMARY KEY<br>
 );
 <br>
 
 </br>
 <h2>Stored Procedure (Sql Server)</h2>
 Create PROCEDURE AddComplaint  <br>
(  <br>
@ComplaintType varchar(100),  <br>
@ComplaintDesc varchar(150),  <br>
@ComplaintId varchar(20)=null out  <br>
)  <br>
AS  <br>
BEGIN<br>
SET NOCOUNT ON;  <br>
  
Declare @ComplaintRef varchar(30)  <br>
--Getting unquie Id  <br>
select @ComplaintRef=isnull(max(Id),0)+1 from ComplaintDetails  <br>
--Generating the unique reference number and seeting to output parameter  <br>
Set @ComplaintId=Upper(LEFT(@ComplaintType,4))+convert(Varchar,@ComplaintRef)  <br>
  
INSERT INTO [dbo].[ComplaintDetails]  <br>
           (  <br>
            [ComplaintId]  <br>
           ,[ComplaintType]  <br>
           ,[ComplaintDesc]  <br>
           )  <br>
     VALUES  <br>
           (  <br>
          @ComplaintId,  <br>
          @ComplaintType,  <br>
          @ComplaintDesc  <br>
           )  <br>
END;<br>
