CREATE TABLE [dbo].[Catering]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [UserId] VARCHAR(MAX) NOT NULL, 
    [ReferenceNumber] INT NULL, 
    [Amount] INT NOT NULL, 
    [Time] DATETIME NOT NULL, 
    [Category] INT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [MeetingRoom] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Catering_CateringCategory] FOREIGN KEY ([Category]) REFERENCES [CateringCategory]([Id])
)
