USE master;
GO
DROP DATABASE IF EXISTS [MachineMonitoring];
GO
CREATE DATABASE [MachineMonitoring];
GO

USE [MachineMonitoring];
GO

CREATE TABLE [Machines] (
    [MachineId] int NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(200) NULL,
    CONSTRAINT [PK_Machines] PRIMARY KEY ([MachineId])
);

GO
CREATE TABLE [MachineProductions] (
    [MachineProductionId] int NOT NULL,
    [MachineId] int NOT NULL,
    [TotalProduction] int NOT NULL,
    CONSTRAINT [PK_MachineProductions] PRIMARY KEY ([MachineProductionId]),
    CONSTRAINT [FK_MachineProductions_Machines_MachineId] FOREIGN KEY ([MachineId]) REFERENCES [Machines] ([MachineId]) ON DELETE CASCADE
);

GO
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (1, 'Machine A', 'It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.')
GO
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (2, 'Machine B', 'It is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry.')
GO
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (3, 'Machine C', 'To make a type specimen book.')
GO
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (4, 'Machine D', 'There are many variations of passages of Lorem Ipsum available.')
GO
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (5, 'Machine E', 'Contrary to popular belief, Lorem Ipsum is not simply random text.')
GO
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (6, 'Machine F', 'Generate Lorem Ipsum which looks reasonable.')
GO
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (7, 'Machine G', 'It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.')
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (1, 3, 87)
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (2, 1, 30)
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (3, 2, 54)
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (4, 7, 187)
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (5, 6, 207)
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (6, 5, 98)
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (7, 4, 55)
GO
