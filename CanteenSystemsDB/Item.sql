CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Title] VARCHAR(2000) NOT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    [Amount] INT NOT NULL, 
    [IsHidden] BIT NOT NULL, 
    [ItemGroup] INT NOT NULL, 
    CONSTRAINT [FK_Item_ItemGroup] FOREIGN KEY ([ItemGroup]) REFERENCES [ItemGroup]([Id])
)

GO

CREATE INDEX [IX_Item_Title] ON [dbo].[Item] ([Title])
