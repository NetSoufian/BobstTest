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
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (1, N'Machine A', N'Le Lorem Ipsum est simplement du faux texte employé dans la composition et la mise en page avant impression.')
GO
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (2, N'Machine B', N'Quand un imprimeur anonyme assembla ensemble des morceaux de texte pour réaliser un livre.')
GO
INSERT [dbo].[Machines] ([MachineId], [Name], [Description]) VALUES (3, N'Machine C', N'Il a été popularisé dans les années 1960 grâce à la vente de feuilles Letraset contenant des passages du Lorem Ipsum.')
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (1, 3, 87)
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (2, 1, 30)
GO
INSERT [dbo].[MachineProductions] ([MachineProductionId], [MachineId], [TotalProduction]) VALUES (3, 2, 54)
GO
