CREATE TABLE [dbo].[Items] (
    [ItemID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (64) NOT NULL,
    [Price]  NVARCHAR (32) NOT NULL,
	[CategoryID] INT		NOT NULL
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([ItemID] ASC), 
    CONSTRAINT [FK_Category] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories]([CategoryID])
);

CREATE TABLE [dbo].[Categories] (
    [CategoryID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (32) NOT NULL,
    [Color]  NVARCHAR (32) NOT NULL,


    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryID] ASC),
); 

INSERT INTO [dbo].[Categories] (Name, Color) VALUES
('Food','#3e95cd'),
('Utilities','#8e5ea2'),
('Automobile','#3cba9f'),
('Rent','#e8c3b9'),
('Others','#c45850');

GO