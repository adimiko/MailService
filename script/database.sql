CREATE DATABASE MailService
GO
USE MailService
GO
CREATE TABLE EmailSettings
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    SmtpHost NVARCHAR(100) NOT NULL,
    SmtpPort INT NOT NULL,
    DisplayName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL
)
GO
USE MailService
GO
CREATE TABLE Mails
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [From] NVARCHAR(100) NOT NULL,
    [To] NVARCHAR(100) NOT NULL,
    Subject NVARCHAR(100) NOT NULL,
    Body NVARCHAR(100) NOT NULL,
    SentAt DATETIME NOT NULL
)

USE MailService
GO
SELECT * FROM Mails