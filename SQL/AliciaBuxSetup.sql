CREATE SCHEMA app;
GO

CREATE TABLE app.Podcaster
(
    podcasterID UNIQUEIDENTIFIER PRIMARY KEY,
    podcasterName NVARCHAR(50) UNIQUE NOT NULL,
    podcasterBalance INT NOT NULL,
);

DROP TABLE app.Podcaster;
DELETE FROM app.Podcaster;

ALTER TABLE app.Podcaster ADD hasAccount BIT NOT NULL DEFAULT 0
