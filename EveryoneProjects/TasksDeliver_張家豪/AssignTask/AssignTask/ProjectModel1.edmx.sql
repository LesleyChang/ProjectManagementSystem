
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/18/2018 20:33:24
-- Generated from EDMX file: C:\Users\III\Desktop\作業配置_ver13\AssignTask\AssignTask\ProjectModel1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjectManagement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ActivityList_ProjectWork]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_ActivityList_ProjectWork];
GO
IF OBJECT_ID(N'[dbo].[FK_ActivityList_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_ActivityList_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Department_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Department] DROP CONSTRAINT [FK_Department_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Department1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Department1];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Employee1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Employee1];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Employee2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Employee2];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectWork_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Works] DROP CONSTRAINT [FK_ProjectWork_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectWork_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Works] DROP CONSTRAINT [FK_ProjectWork_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectWork_ProjectWork]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Works] DROP CONSTRAINT [FK_ProjectWork_ProjectWork];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectWork_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Works] DROP CONSTRAINT [FK_ProjectWork_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Tasks_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_Tasks_Employee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO
IF OBJECT_ID(N'[dbo].[Works]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Works];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DepartmentID] int  NOT NULL,
    [DepartmentName] nvarchar(max)  NULL,
    [ParentDepartmentID] int  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int  NOT NULL,
    [EmployeeName] nvarchar(max)  NULL,
    [ManagerID] int  NULL,
    [DepartmentID] int  NULL,
    [TitleID] int  NULL,
    [Picture] varbinary(max)  NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ProjectID] nchar(10)  NOT NULL,
    [RequiredDeptID] int  NULL,
    [RequiredDeptPMID] int  NULL,
    [ProjectName] nvarchar(max)  NULL,
    [EstStartDate] datetime  NULL,
    [EstEndDate] datetime  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [InChargeDeptID] int  NULL,
    [InChargeDeptPMID] int  NULL,
    [ProjectStatusID] int  NULL,
    [ProjectCategoryID] int  NULL,
    [ProjectSupervisorID] int  NULL,
    [IsGeneralManagerConcerned] bit  NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [StatusID] int  NOT NULL,
    [StatusCategoryID] nchar(10)  NULL,
    [StatusName] nvarchar(max)  NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [WorkID] int  NULL,
    [TaskID] int  NOT NULL,
    [TaskName] nvarchar(max)  NULL,
    [EstStartDate] datetime  NULL,
    [EstEndDate] datetime  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [EstWorkTime] int  NULL,
    [WorkTime] int  NULL,
    [TaskStatusID] int  NULL,
    [EmployeeID] int  NULL,
    [Tag] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [TaskStatusIDChanged] int  NULL
);
GO

-- Creating table 'Works'
CREATE TABLE [dbo].[Works] (
    [ProjectID] nchar(10)  NULL,
    [EmployeeID] int  NULL,
    [ParentWorkID] int  NULL,
    [WorkID] int  NOT NULL,
    [WorkName] nvarchar(max)  NULL,
    [WorkEstStartDate] datetime  NULL,
    [WorkEstEndDate] datetime  NULL,
    [WorkStartDate] datetime  NULL,
    [WorkEndDate] datetime  NULL,
    [Description] nvarchar(max)  NULL,
    [WorkStatusID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DepartmentID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DepartmentID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [ProjectID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ProjectID] ASC);
GO

-- Creating primary key on [StatusID] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([StatusID] ASC);
GO

-- Creating primary key on [TaskID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([TaskID] ASC);
GO

-- Creating primary key on [WorkID] in table 'Works'
ALTER TABLE [dbo].[Works]
ADD CONSTRAINT [PK_Works]
    PRIMARY KEY CLUSTERED ([WorkID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ParentDepartmentID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [FK_Department_Department]
    FOREIGN KEY ([ParentDepartmentID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Department_Department'
CREATE INDEX [IX_FK_Department_Department]
ON [dbo].[Departments]
    ([ParentDepartmentID]);
GO

-- Creating foreign key on [DepartmentID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Department]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Department'
CREATE INDEX [IX_FK_Employee_Department]
ON [dbo].[Employees]
    ([DepartmentID]);
GO

-- Creating foreign key on [RequiredDeptID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_Department]
    FOREIGN KEY ([RequiredDeptID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Department'
CREATE INDEX [IX_FK_Project_Department]
ON [dbo].[Projects]
    ([RequiredDeptID]);
GO

-- Creating foreign key on [InChargeDeptID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_Department1]
    FOREIGN KEY ([InChargeDeptID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Department1'
CREATE INDEX [IX_FK_Project_Department1]
ON [dbo].[Projects]
    ([InChargeDeptID]);
GO

-- Creating foreign key on [ManagerID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Employee]
    FOREIGN KEY ([ManagerID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Employee'
CREATE INDEX [IX_FK_Employee_Employee]
ON [dbo].[Employees]
    ([ManagerID]);
GO

-- Creating foreign key on [RequiredDeptPMID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_Employee]
    FOREIGN KEY ([RequiredDeptPMID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Employee'
CREATE INDEX [IX_FK_Project_Employee]
ON [dbo].[Projects]
    ([RequiredDeptPMID]);
GO

-- Creating foreign key on [InChargeDeptPMID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_Employee1]
    FOREIGN KEY ([InChargeDeptPMID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Employee1'
CREATE INDEX [IX_FK_Project_Employee1]
ON [dbo].[Projects]
    ([InChargeDeptPMID]);
GO

-- Creating foreign key on [ProjectSupervisorID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_Employee2]
    FOREIGN KEY ([ProjectSupervisorID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Employee2'
CREATE INDEX [IX_FK_Project_Employee2]
ON [dbo].[Projects]
    ([ProjectSupervisorID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_Tasks_Employee]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tasks_Employee'
CREATE INDEX [IX_FK_Tasks_Employee]
ON [dbo].[Tasks]
    ([EmployeeID]);
GO

-- Creating foreign key on [ProjectStatusID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_Status]
    FOREIGN KEY ([ProjectStatusID])
    REFERENCES [dbo].[Status]
        ([StatusID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Status'
CREATE INDEX [IX_FK_Project_Status]
ON [dbo].[Projects]
    ([ProjectStatusID]);
GO

-- Creating foreign key on [TaskStatusID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_ActivityList_Status]
    FOREIGN KEY ([TaskStatusID])
    REFERENCES [dbo].[Status]
        ([StatusID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityList_Status'
CREATE INDEX [IX_FK_ActivityList_Status]
ON [dbo].[Tasks]
    ([TaskStatusID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Works'
ALTER TABLE [dbo].[Works]
ADD CONSTRAINT [FK_ProjectWork_Employee]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectWork_Employee'
CREATE INDEX [IX_FK_ProjectWork_Employee]
ON [dbo].[Works]
    ([EmployeeID]);
GO

-- Creating foreign key on [ProjectID] in table 'Works'
ALTER TABLE [dbo].[Works]
ADD CONSTRAINT [FK_ProjectWork_Project]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ProjectID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectWork_Project'
CREATE INDEX [IX_FK_ProjectWork_Project]
ON [dbo].[Works]
    ([ProjectID]);
GO

-- Creating foreign key on [WorkStatusID] in table 'Works'
ALTER TABLE [dbo].[Works]
ADD CONSTRAINT [FK_ProjectWork_Status]
    FOREIGN KEY ([WorkStatusID])
    REFERENCES [dbo].[Status]
        ([StatusID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectWork_Status'
CREATE INDEX [IX_FK_ProjectWork_Status]
ON [dbo].[Works]
    ([WorkStatusID]);
GO

-- Creating foreign key on [WorkID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_ActivityList_ProjectWork]
    FOREIGN KEY ([WorkID])
    REFERENCES [dbo].[Works]
        ([WorkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityList_ProjectWork'
CREATE INDEX [IX_FK_ActivityList_ProjectWork]
ON [dbo].[Tasks]
    ([WorkID]);
GO

-- Creating foreign key on [ParentWorkID] in table 'Works'
ALTER TABLE [dbo].[Works]
ADD CONSTRAINT [FK_ProjectWork_ProjectWork]
    FOREIGN KEY ([ParentWorkID])
    REFERENCES [dbo].[Works]
        ([WorkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectWork_ProjectWork'
CREATE INDEX [IX_FK_ProjectWork_ProjectWork]
ON [dbo].[Works]
    ([ParentWorkID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------