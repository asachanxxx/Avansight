ALTER PROCEDURE [cts].[StudyImport]
    @Study AS [cts].[StudyTableType] READONLY
AS
BEGIN
    MERGE [cts].[Study]  AS Target
    USING @Study AS Source  
    ON (Target.StudyId = Source.StudyId)
    WHEN NOT MATCHED BY Target THEN
        INSERT ([StudyIdentifier],[StudyName],[ProjectNumber],[Type])  
        VALUES (Source.StudyIdentifier,Source.StudyName,Source.ProjectNumber,Source.Type);
END
GO





