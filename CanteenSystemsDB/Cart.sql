CREATE TABLE [dbo].[Cart]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [UserId] VARCHAR(MAX) NOT NULL, 
    [Item] INT NOT NULL, 
    [Amount] INT NOT NULL, 
    CONSTRAINT [FK_Cart_Item] FOREIGN KEY ([Item]) REFERENCES [Item]([Id])
)
